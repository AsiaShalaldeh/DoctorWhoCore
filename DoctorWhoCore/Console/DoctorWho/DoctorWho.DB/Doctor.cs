namespace DoctorWho.DB
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public int DoctorNumber { get; set; }
        public string DoctorName { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateOnly FirstEpisodeDate { get; set; }
        public DateOnly LastEpisodeDate { get; set; }
        public List<Episode> Episodes { get; set; }
    }
}
