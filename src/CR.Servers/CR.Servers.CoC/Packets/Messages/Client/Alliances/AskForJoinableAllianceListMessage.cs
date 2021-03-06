namespace CR.Servers.CoC.Packets.Messages.Client.Alliances
{
    using System.Linq;
    using CR.Servers.CoC.Core;
    using CR.Servers.CoC.Core.Network;
    using CR.Servers.CoC.Logic;
    using CR.Servers.CoC.Logic.Clan;
    using CR.Servers.CoC.Packets.Enums;
    using CR.Servers.CoC.Packets.Messages.Server.Alliances;
    using CR.Servers.Extensions.Binary;
    using CR.Servers.Logic.Enums;

    internal class AskForJoinableAllianceListMessage : Message
    {
      


        public AskForJoinableAllianceListMessage(Device Device, Reader Reader) : base(Device, Reader)
        {
        }


        internal override short Type
        {
            get
            {
                return 14303;
            }
        }
   
        internal  ServiceNode Node
        {
            get
            {
                return ServiceNode.Alliance;
            }
        }


        internal override void Process()
        {
            
            new JoinableAllianceListMessage(this.Device)
            {
                Alliances = Resources.Clans.GetAllClans().Where(T =>
                        T.Header.Type == Hiring.OPEN &&
                        T.Header.NumberOfMembers > 0 &&
                        T.Header.NumberOfMembers < 50 &&
                        T.Header.RequiredScore <= this.Device.GameMode.Level.Player.Score)
                     .Take(64).OrderByDescending(T => T.Header.Score).ToArray()
            }.Send();
        }

    }
}