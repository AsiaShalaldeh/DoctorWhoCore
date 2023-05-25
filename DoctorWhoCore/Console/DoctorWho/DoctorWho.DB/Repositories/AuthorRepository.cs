namespace DoctorWho.DB.Repositories
{
    public class AuthorRepository
    {
        private readonly DoctorWhoCoreDbContext _context;
        public AuthorRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }
        public void CreateAuthor()
        {
            var author = new Author { AuthorName = "Leonardo Dicaprio" };
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
        public void UpdateAuthor()
        {
            var author = _context.Authors.Where(a => a.AuthorId == 6).FirstOrDefault();
            author.AuthorName = "Leo Dicaprio";
            _context.SaveChanges();
        }
        public void DeleteAuthor()
        {
            var author = _context.Authors.Where(a => a.AuthorId == 6).FirstOrDefault();
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
