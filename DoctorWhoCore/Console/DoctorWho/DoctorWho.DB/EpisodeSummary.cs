using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorWho.DB
{
    [NotMapped]
    public class EpisodeSummary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string Type { get; set; }
    }
}
