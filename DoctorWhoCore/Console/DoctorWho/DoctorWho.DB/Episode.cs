namespace DoctorWho.DB
{
    public class Episode
    {
        public int EpisodeId { get; set; }
        public int SeriesNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeType { get; set; }
        public string Title { get; set; }
        public DateTime EpisodeDate { get; set; }
        public string Notes { get; set; }
        public int AuthorId { get; set; }
        public int DoctorId { get; set; }
        public IList<EpisodeCompanion> EpisodeCompanions { get; set; }
        public IList<EpisodeEnemy> EpisodeEnemies { get; set; }
    }
}
