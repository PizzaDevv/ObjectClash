namespace CR.Servers.CoC.Files.CSV_Logic.Logic
{
    using System;
    using CR.Servers.CoC.Files.CSV_Helpers;
    using CR.Servers.CoC.Logic.Enums;
    using CR.Servers.Files.CSV_Reader;

    internal class BuildingData : Data
    {
        internal BuildingData gearUpBuildingData;
        internal BuildingClassData BuildingClassData;
        internal BuildingClassData secondaryTargetingClassData;
        internal BuildingClassData shopBuildingClassData;
        internal ResourceData BuildResourceData;
        internal ResourceData ProducesResourceData;

        public BuildingData(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
        }


        public override string Name { get; set; }
        public string TID { get; set; }
        public string InfoTID { get; set; }
        public string BuildingClass { get; set; }
        public string SecondaryTargetingClass { get; set; }
        public string ShopBuildingClass { get; set; }
        public string SWF { get; set; }
        public string[] ExportName { get; set; }
        public string ExportNameNpc { get; set; }
        public string ExportNameConstruction { get; set; }
        public string ExportNameLocked { get; set; }
        public int[] BuildTimeD { get; set; }
        public int[] BuildTimeH { get; set; }
        public int[] BuildTimeM { get; set; }
        public int[] BuildTimeS { get; set; }
        public string BuildResource { get; set; }
        public int[] BuildCost { get; set; }
        public int[] TownHallLevel { get; set; }
        public int[] TownHallLevel2 { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Icon { get; set; }
        public string[] ExportNameBuildAnim { get; set; }
        public string[] ExportNameUpgradeAnim { get; set; }
        public int[] MaxStoredGold { get; set; }
        public int[] MaxStoredElixir { get; set; }
        public int[] MaxStoredDarkElixir { get; set; }
        public int[] MaxStoredWarGold { get; set; }
        public int[] MaxStoredWarElixir { get; set; }
        public int[] MaxStoredWarDarkElixir { get; set; }
        public int[] MaxStoredGold2 { get; set; }
        public int[] MaxStoredElixir2 { get; set; }
        public int PercentageStoredGold { get; set; }
        public int PercentageStoredElixir { get; set; }
        public int[] PercentageStoredDarkElixir { get; set; }
        public bool LootOnDestruction { get; set; }
        public bool Bunker { get; set; }
        public int Village2Housing { get; set; }
        public int[] HousingSpace { get; set; }
        public int[] HousingSpaceAlt { get; set; }
        public string ProducesResource { get; set; }
        public int[] ResourcePer100Hours { get; set; }
        public int[] ResourceMax { get; set; }
        public int[] ResourceIconLimit { get; set; }
        public int[] UnitProduction { get; set; }
        public bool UpgradesUnits { get; set; }
        public int ProducesUnitsOfType { get; set; }
        public int[] BoostCost { get; set; }
        public bool FreeBoost { get; set; }
        public int[] Hitpoints { get; set; }
        public int[] RegenTime { get; set; }
        public int AttackRange { get; set; }
        public bool AltAttackMode { get; set; }
        public int AltAttackRange { get; set; }
        public int PrepareSpeed { get; set; }
        public int AttackSpeed { get; set; }
        public int AltAttackSpeed { get; set; }
        public int CoolDownOverride { get; set; }
        public int[] DPS { get; set; }
        public int[] AltDPS { get; set; }
        public int[] Damage { get; set; }
        public string PreferredTarget { get; set; }
        public int PreferredTargetDamageMod { get; set; }
        public bool RandomHitPosition { get; set; }
        public string[] DestroyEffect { get; set; }
        public string[] DestroyDamageEffect { get; set; }
        public string[] AttackEffect { get; set; }
        public string[] AttackEffect2 { get; set; }
        public int ChainAttackDistance { get; set; }
        public string AttackEffectAlt { get; set; }
        public string[] HitEffect { get; set; }
        public string[] Projectile { get; set; }
        public string[] AltProjectile { get; set; }
        public string[] ExportNameDamaged { get; set; }
        public int BuildingW { get; set; }
        public int BuildingH { get; set; }
        public int BaseGfx { get; set; }
        public string[] ExportNameBase { get; set; }
        public bool AirTargets { get; set; }
        public bool GroundTargets { get; set; }
        public bool AltAirTargets { get; set; }
        public bool AltGroundTargets { get; set; }
        public bool AltMultiTargets { get; set; }
        public int AmmoCount { get; set; }
        public string AmmoResource { get; set; }
        public int[] AmmoCost { get; set; }
        public int MinAttackRange { get; set; }
        public int DamageRadius { get; set; }
        public int PushBack { get; set; }
        public bool[] WallCornerPieces { get; set; }
        public string LoadAmmoEffect { get; set; }
        public string NoAmmoEffect { get; set; }
        public string ToggleAttackModeEffect { get; set; }
        public string PickUpEffect { get; set; }
        public string PlacingEffect { get; set; }
        public bool CanNotSellLast { get; set; }
        public string[] DefenderCharacter { get; set; }
        public int[] DefenderCount { get; set; }
        public int[] DefenderZ { get; set; }
        public int[] AltDefenderZ { get; set; }
        public int[] DestructionXP { get; set; }
        public bool Locked { get; set; }
        public int StartingHomeCount { get; set; }
        public bool Hidden { get; set; }
        public string AOESpell { get; set; }
        public string AOESpellAlternate { get; set; }
        public int TriggerRadius { get; set; }
        public string[] ExportNameTriggered { get; set; }
        public string AppearEffect { get; set; }
        public bool ForgesSpells { get; set; }
        public bool ForgesMiniSpells { get; set; }
        public bool IsHeroBarrack { get; set; }
        public string HeroType { get; set; }
        public bool IncreasingDamage { get; set; }
        public int[] DPSLv2 { get; set; }
        public int[] DPSLv3 { get; set; }
        public int[] DPSMulti { get; set; }
        public int[] Lv2SwitchTime { get; set; }
        public int[] Lv3SwitchTime { get; set; }
        public string[] AttackEffectLv2 { get; set; }
        public string[] AttackEffectLv3 { get; set; }
        public string TransitionEffectLv2 { get; set; }
        public string TransitionEffectLv3 { get; set; }
        public int[] AltNumMultiTargets { get; set; }
        public bool PreventsHealing { get; set; }
        public int[] StrengthWeight { get; set; }
        public int AlternatePickNewTargetDelay { get; set; }
        public string[] AltBuildResource { get; set; }
        public int SpeedMod { get; set; }
        public int StatusEffectTime { get; set; }
        public int[] ShockwavePushStrength { get; set; }
        public int ShockwaveArcLength { get; set; }
        public int ShockwaveExpandRadius { get; set; }
        public int TargetingConeAngle { get; set; }
        public int AimRotateStep { get; set; }
        public bool PenetratingProjectile { get; set; }
        public int PenetratingRadius { get; set; }
        public int PenetratingExtraRange { get; set; }
        public int TurnSpeed { get; set; }
        public bool NeedsAim { get; set; }
        public bool TargetGroups { get; set; }
        public int TargetGroupsRadius { get; set; }
        public string HitSpell { get; set; }
        public int HitSpellLevel { get; set; }
        public string ExportNameBeamStart { get; set; }
        public string ExportNameBeamEnd { get; set; }
        public int Damage2 { get; set; }
        public int Damage2Radius { get; set; }
        public int Damage2Delay { get; set; }
        public int Damage2Min { get; set; }
        public int Damage2FalloffStart { get; set; }
        public int Damage2FalloffEnd { get; set; }
        public string HitEffect2 { get; set; }
        public int WakeUpSpeed { get; set; }
        public int WakeUpSpace { get; set; }
        public string PreAttackEffect { get; set; }
        public bool ShareHeroCombatData { get; set; }
        public int BurstCount { get; set; }
        public int BurstDelay { get; set; }
        public int AltBurstCount { get; set; }
        public int AltBurstDelay { get; set; }
        public int DummyProjectileCount { get; set; }
        public int[] DieDamage { get; set; }
        public int DieDamageRadius { get; set; }
        public string DieDamageEffect { get; set; }
        public int DieDamageDelay { get; set; }
        public bool IsRed { get; set; }
        public int VillageType { get; set; }
        public string WallBlockX { get; set; }
        public string WallBlockY { get; set; }
        public int RedMul { get; set; }
        public int GreenMul { get; set; }
        public int BlueMul { get; set; }
        public int RedAdd { get; set; }
        public int GreenAdd { get; set; }
        public int BlueAdd { get; set; }
        public int[] DefenceTroopCount { get; set; }
        public string DefenceTroopCharacter { get; set; }
        public string DefenceTroopCharacter2 { get; set; }
        public int[] DefenceTroopLevel { get; set; }
        public int[] AmountCanBeUpgraded { get; set; }
        public bool SelfAsAoeCenter { get; set; }
        public int NewTargetAttackDelay { get; set; }
        public string GearUpBuilding { get; set; }
        public int GearUpLevelRequirement { get; set; }
        public string GearUpResource { get; set; }
        public int[] GearUpCost { get; set; }
        public int[] GearUpTime { get; set; }

        internal int MaxLevel
        {
            get
            {
                return this.BuildCost.Length - 1;
            }
        }

        internal bool IsTownHall
        {
            get
            {
                return this.BuildingClass == "Town Hall";
            }
        }

        internal bool IsTownHall2
        {
            get
            {
                return this.BuildingClass == "Town Hall2";
            }
        }

        internal bool IsWorker
        {
            get
            {
                return this.BuildingClass == "Worker";
            }
        }

        internal bool IsWorker2
        {
            get
            {
                return this.BuildingClass == "Worker2";
            }
        }

        internal bool IsDefense
        {
            get
            {
                return this.BuildingClass == "Defense";
            }
        }

        internal bool IsWall
        {
            get
            {
                return this.BuildingClass == "Wall";
            }
        }

        internal bool IsSpellForge
        {
            get
            {
                return this.ForgesSpells && this.ProducesUnitsOfType == 1;
            }
        }

        internal bool IsMiniSpellForge
        {
            get
            {
                return this.ForgesMiniSpells && this.ProducesUnitsOfType == 2;
            }
        }

        internal bool IsLaboratory
        {
            get
            {
                return this.UpgradesUnits;
            }
        }

        internal bool IsBarrack
        {
            get
            {
                return this.UnitProduction[0] > 0 && this.ProducesUnitsOfType == 1 && !this.ForgesSpells;
            }
        }

        internal bool IsDarkBarrack
        {
            get
            {
                return this.UnitProduction[0] > 0 && this.ProducesUnitsOfType == 2 && !this.ForgesSpells;
            }
        }

        internal bool IsBarrack2
        {
            get
            {
                return this.Name == "Barrack2";
            }
        }

        internal bool IsTrainingHousing
        {
            get
            {
                return this.HousingSpace[0] > 0 && !this.Bunker;
            }
        }

        internal bool IsAllianceCastle
        {
            get
            {
                return this.Name == "Alliance Castle";
            }
        }

        internal bool IsTroopHousingV2
        {
            get
            {
                return this.Name == "Troop Housing2";
            }
        }

        internal bool IsWallStraight
        {
            get
            {
                return this.Name == "WallStraight";
            }
        }

        internal bool CanStoreResources
        {
            get
            {
                return this.MaxStoredGold[0] > 0
                       || this.MaxStoredElixir[0] > 0
                       || this.MaxStoredDarkElixir[0] > 0
                       || this.MaxStoredWarGold[0] > 0
                       || this.MaxStoredWarElixir[0] > 0
                       || this.MaxStoredWarDarkElixir[0] > 0
                       || this.MaxStoredGold2[0] > 0
                       || this.MaxStoredElixir2[0] > 0;
            }
        }

        internal ResourceData GearUpResourceData
        {
            get
            {
                return (ResourceData) CSV.Tables.Get(Gamefile.Resources).GetData(this.GearUpResource);
            }
        }

        internal override void Process()
        {
            this.gearUpBuildingData = DataTables.GetBuildingByName(this.GearUpBuilding);

            this.BuildingClassData = DataTables.GetBuildingClassByName(this.BuildingClass);
            this.secondaryTargetingClassData = DataTables.GetBuildingClassByName(this.SecondaryTargetingClass);
            this.shopBuildingClassData = DataTables.GetBuildingClassByName(this.ShopBuildingClass);
            this.BuildResourceData = DataTables.GetResourceByName(this.BuildResource);
            this.ProducesResourceData = DataTables.GetResourceByName(this.ProducesResource);

            if (this.BuildingClassData == null)
            {
                throw new Exception("Buildings.csv: Building Class does not exist.");
            }

            if (this.BuildResourceData == null)
            {
                throw new Exception("Buildings.csv: Build Resource is invalid!.");
            }
        }

        internal int GetBuildTime(int Level)
        {
            return this.BuildTimeD[Level] * 86400 + this.BuildTimeH[Level] * 3600 + this.BuildTimeM[Level] * 60 + this.BuildTimeS[Level];
        }

        internal int GetGearUpTime(int Level)
        {
            return this.GearUpTime[Level] * 60;
        }

        internal ResourceData AltBuildResourceData(int Level)
        {
            return (ResourceData) CSV.Tables.Get(Gamefile.Resources).GetData(this.AltBuildResource[Level]);
        }

        internal int[] GetResourceMaxArray(int Level)
        {
            int[] MaxArray = new int[9];

            MaxArray[1] = this.MaxStoredGold[Level];
            MaxArray[2] = this.MaxStoredElixir[Level];
            MaxArray[3] = this.MaxStoredDarkElixir[Level];

            MaxArray[4] = this.MaxStoredWarGold[Level];
            MaxArray[5] = this.MaxStoredWarElixir[Level];
            MaxArray[6] = this.MaxStoredWarDarkElixir[Level];

            MaxArray[7] = this.MaxStoredGold2[Level];
            MaxArray[8] = this.MaxStoredElixir2[Level];

            return MaxArray;
        }
    }
}
