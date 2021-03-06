namespace CR.Servers.CoC.Logic.Battles
{
    using System;
    using System.Collections.Generic;
    using CR.Servers.CoC.Core;
    using CR.Servers.CoC.Core.Database.Models.Mongo;
    using CR.Servers.CoC.Core.Network;
    using CR.Servers.CoC.Extensions.Game;
    using CR.Servers.CoC.Packets;
    using CR.Servers.CoC.Packets.Commands.Client.Battle;
    using CR.Servers.CoC.Packets.Messages.Server.Battle;
    using CR.Servers.CoC.Packets.Messages.Server.Home;
    using Timer = System.Timers.Timer;
    using System.Threading.Tasks;
    using CR.Servers.CoC.Extensions;
    using Newtonsoft.Json;
    using System.Runtime.CompilerServices;

    internal class Battle
    {
        internal Battles Replay;
        internal Level Attacker;
        internal List<Command> Commands;
        internal Level Defender;
        internal Battle _Battle;
        internal Device Device;
        internal bool Started;
        internal bool Ended;
        internal bool Duel;

        internal int EndSubTick;
        internal DateTime LastClientTurn;
        internal BattleLog BattleLog;
        internal BattleRecorder Recorder;

        internal List<Device> Viewers;

        internal Timer Timer;
        internal int WinScore;
        internal int LostScore;

        internal int AttackTime;
        internal int PreparationTime;
        internal int RemainingBattleTime;
        internal int WinDuelScore;

        internal int RemainingBattleTimeSecs
        {
            get
            {
                return 16 * this.RemainingBattleTime / 1000;
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Battle" /> class.
        /// </summary>
        internal Battle(Device device, Level attacker, Level defender, bool duel)
        {
            this.Duel = duel;

            this.Device = device;
            this.Attacker = attacker;
            this.Defender = defender;
            this.BattleLog = new BattleLog(this);
            this.Recorder = new BattleRecorder(this);
            this.Commands = new List<Command>(64);
            this.Viewers = new List<Device>(32);

            this.AttackTime = Globals.AttackLength;
            this.PreparationTime = duel ? Globals.AttackPrepartionLength2 : Globals.AttackPrepartionLength;
            this.RemainingBattleTime = 1000 * (this.AttackTime + this.PreparationTime) / 16;
            this.WinScore = this.Attacker.Player.Score + Core.Resources.Random2.Next(10, 20);//_Battle.Defender.Player.Score + 1
            this.WinDuelScore = this.Attacker.Player.DuelScore + Core.Resources.Random2.Next(10, 20);
            this.LostScore = this.Attacker.Player.Score - Core.Resources.Random2.Next(10, 20);

            this.EndClientTurn();
        }

        internal void AddViewer(Device device)
        {
            if (!this.Viewers.Contains(device) && !this.Ended)
            {
                this.Viewers.Add(device);

                new LiveReplayMessage(device, this.Recorder.Save().ToString(), this.Commands, this.EndSubTick).Send();
            }
        }

        internal async Task EndBattleAsync()
        {
            if (this.Ended)
            {
                return;
            }

            this.Timer.Dispose();
            Task savePlayer = null;
            Task saveHome = null;

            //Score = Defender.Player;

            if (this.Started)
            {
                this.Replay = await Resources.Battles.Save(this);
                if (!this.Duel)
                {
                    this.Defender.Player.Inbox.Add(new BattleReportStreamEntry(this.Attacker.Player, this, ((long)this.Replay.HighId << 32) | (uint)this.Replay.LowId, 2));
                    this.Attacker.Player.Inbox.Add(new BattleReportStreamEntry(this.Defender.Player, this, ((long)this.Replay.HighId << 32) | (uint)this.Replay.LowId, 7));
                }


                if (this.Commands.Count > 0)
                {    
                        savePlayer = Resources.Accounts.SavePlayer(this.Defender.Player);
                        saveHome = Resources.Accounts.SaveHome(this.Defender.Home);
                }

            }

            for (int i = 0; i < this.Viewers.Count; i++)
            {
                if (this.Viewers[i].Connected)
                {
                    if (this.Viewers[i].GameMode.Level.Player.UserId == this.Defender.Player.UserId)
                    {
                        new OwnHomeDataMessage(this.Viewers[i]).Send();
                    }
                }
            }

            if (saveHome != null && savePlayer != null)
                await Task.WhenAll(saveHome, savePlayer);
            this.Ended = true;
        }
#if ClashLandlogic
        /*internal static double WinTrophies()
        {
            Battle _Battle = null;
            double Difference = (Player.Score - _Battle.Score) < 0
       ? +(Player.Score - _Battle.Score)
       : (Player.Score - _Battle.Score);
            //double Difference = (AttackerTrophies - DefenderTrophies) < 0 ? +(DefenderTrophies - AttackerTrophies) : (AttackerTrophies - DefenderTrophies);
            if (Difference >= 13 && Difference <= 34)
            {
                return Math.Round((-0.0794 * (Player.Score - _Battle.Score)) + 29.35838);
            }
            return Core.Resources.Random2.Next(10, 15);//clash land logic not work
            
        }*/

        /*internal static double LoseTrophies()
        {
            Battle _Battle = null;
            if (Player.Score >= 1000 && _Battle.Defender.Player.Score >= 1000)
            {
                return Math.Round((0.0531 * (Player.Score - _Battle.Defender.Player.Score)) + 19.60453);
            }
            return Core.Resources.Random2.Next(10, 15);//clash land logic not work

        }*/
#endif

        internal bool RemoveViewer(Device device)
        {
            return this.Viewers.Remove(device);
        }
        internal async Task Trofeislogichlost()
        {
            Player Player = null;
            int lost = (int)this.Device.Account.Battle.LostScore;
            Player.Score -= (int)this.Device.Account.Battle.WinScore;

            if (Player.Score >= lost)
                Player.Score -= (int)this.Device.Account.Battle.LostScore;
            else
              Player.Score = 0;
        }
        internal async Task Trofeislogichwin()
        {
            Player Player = null;
            int lost = (int)this.Device.Account.Battle.LostScore;
            Player.Score += (int)this.Device.Account.Battle.WinScore;

            if (Player.Score >= lost)
                Player.Score -= (int)this.Device.Account.Battle.LostScore;
            else
                Player.Score = 0;
        }
        internal void HandleCommands(int subTick, List<Command> commands)
        {
            this.RemainingBattleTime -= subTick - this.EndSubTick;

            this.EndSubTick = subTick;
            this.Recorder.EndTick = subTick;
            this.LastClientTurn = DateTime.UtcNow;

            if (commands != null)
            {
                for (int i = 0; i < commands.Count; i++)
                {
                    if (commands[i].Type != 800)
                    {
                        if (!this.Started)
                        {
                            this.Started = true;

                            if (this.RemainingBattleTime > this.AttackTime)
                            {
                                this.RemainingBattleTime = 1000 * this.AttackTime / 16;
                            }
                        }

                        this.Recorder.Commands.Add(commands[i].Save());
                        this.Commands.Add(commands[i]);
                    }
                }
            }

            for (int i = 0; i < this.Viewers.Count; i++)
            {
                if (this.Viewers[i].Connected)
                {
                    new LiveReplayDataMessage(this.Viewers[i])
                    {
                        EndSubTick = subTick,
                        Commands = commands,
                        SpectatorTeam1 = this.Viewers.Count
                    }.Send();
                }
                else
                {
                    if (this.RemoveViewer(this.Viewers[i]))
                    {
                        --i;
                    }
                }
            }

            if (commands != null)
            {
                for (int i = 0; i < commands.Count; i++)
                {
                    switch (commands[i].Type)
                    {
                        case 700:
                            {
                                Place_Attacker placeAttacker = (Place_Attacker)commands[i];
                                this.BattleLog.IncrementUnit(placeAttacker.Character);
                                break;
                            }

                        case 701:
                            {
                                this.BattleLog.AlliancePortalDeployed();
                                break;
                            }

                        case 703:
                            {
                                var _ = this.EndBattleAsync();
                                break;
                            }

                        case 704:
                            {
                                Place_Spell placeSpell = (Place_Spell)commands[i];
                                this.BattleLog.IncrementSpell(placeSpell.Spell);
                                break;
                            }

                        case 705:
                            {
                                Place_Hero placeHero = (Place_Hero)commands[i];
                                this.BattleLog.HeroDeployed(placeHero.Hero);
                                break;
                            }
                    }
                }
            }
        }

        internal void EndClientTurn()
        {
            if (this.Ended)
            {
                return;
            }

            this.Timer = new Timer();
            this.Timer.Interval = 2000;
            this.Timer.AutoReset = true;
            this.Timer.Elapsed += (Aidid, Mike) =>
            {
                int LastClientTurnSeconds = (int)DateTime.UtcNow.Subtract(this.LastClientTurn).TotalSeconds;
                if (LastClientTurnSeconds > 5)
                {
                    var _ = this.EndBattleAsync();

                    if (this.Device.TimeSinceLastKeepAlive > 5)
                    {
                        Resources.Gateway.Disconnect(this.Device.Token.Args);
                    }

                    this.Timer.Stop();
                }
            };

            this.Timer.Start();
        }
    }
}