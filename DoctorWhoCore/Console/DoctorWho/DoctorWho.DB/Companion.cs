namespace DoctorWho.DB
{
    public class Companion
    {
        public int CompanionId { get; set; }
        public string CompanionName { get; set; }
        public string WhoPlayed { get; set; }
        public IList<EpisodeCompanion> EpisodeCompanions { get; set; }
    }
}
