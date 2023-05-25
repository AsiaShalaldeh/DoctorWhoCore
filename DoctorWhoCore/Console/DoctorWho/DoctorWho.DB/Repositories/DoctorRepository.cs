namespace DoctorWho.DB.Repositories
{
    public class DoctorRepository
    {
        private readonly DoctorWhoCoreDbContext _context;
        public DoctorRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }
        public void GetAllDoctors()
        {
            var doctors = _context.Doctors.ToList();
            foreach (var doctor in doctors)
            {
                Console.WriteLine("Doctor Name: " + doctor.DoctorName);
            }
        }
        public void CreateDoctor()
        {
            var doctor = new Doctor
            {
                DoctorNumber = 5378,
                DoctorName = "Will Smith",
                BirthDate = new DateTime(1975, 5, 10),
                FirstEpisodeDate = new DateTime(2020, 2, 1),
                LastEpisodeDate = new DateTime(2020, 2, 15)
            };
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }
        public void UpdateDoctor()
        {
            var doctor = _context.Doctors.Where(d => d.DoctorId == 6).FirstOrDefault();
            doctor.DoctorNumber = 3844;
            _context.SaveChanges();
        }
        public void DeleteDoctor()
        {
            var doctor = _context.Doctors.Where(d => d.DoctorId == 6).FirstOrDefault();
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }
    }
}
