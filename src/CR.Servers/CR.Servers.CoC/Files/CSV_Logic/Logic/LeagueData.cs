namespace CR.Servers.CoC.Files.CSV_Logic.Logic
{
    using CR.Servers.CoC.Files.CSV_Helpers;
    using CR.Servers.Files.CSV_Reader;

    internal class LeagueData : Data
    {
        public LeagueData(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
        }

        public override string Name { get; set; }
        public string TID { get; set; }
        public string TIDShort { get; set; }
        public string IconSWF { get; set; }
        public string IconExportName { get; set; }
        public string LeagueBannerIcon { get; set; }
        public string LeagueBannerIconNum { get; set; }
        public string LeagueBannerIconHUD { get; set; }
        public int GoldReward { get; set; }
        public int ElixirReward { get; set; }
        public int DarkElixirReward { get; set; }
        public bool UseStarBonus { get; set; }
        public int GoldRewardStarBonus { get; set; }
        public int ElixirRewardStarBonus { get; set; }
        public int DarkElixirRewardStarBonus { get; set; }
        public int PlacementLimitLow { get; set; }
        public int PlacementLimitHigh { get; set; }
        public int DemoteLimit { get; set; }
        public int PromoteLimit { get; set; }
        public int[] BucketPlacementRangeLow { get; set; }
        public int[] BucketPlacementRangeHigh { get; set; }
        public int[] BucketPlacementSoftLimit { get; set; }
        public int[] BucketPlacementHardLimit { get; set; }
        public bool IgnoredByServer { get; set; }
        public bool DemoteEnabled { get; set; }
        public bool PromoteEnabled { get; set; }
        public int AllocateAmount { get; set; }
        public int SaverCount { get; set; }
    }
}