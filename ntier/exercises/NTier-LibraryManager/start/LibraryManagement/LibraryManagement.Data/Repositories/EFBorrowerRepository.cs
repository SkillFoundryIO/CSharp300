using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces.Repositories;

namespace LibraryManagement.Data.Repositories
{
    public class EFBorrowerRepository : IBorrowerRepository
    {
        private LibraryContext _dbContext;

        public EFBorrowerRepository(string connectionString)
        {
            _dbContext = new LibraryContext(connectionString);
        }

        public void Add(Borrower b)
        {
            _dbContext.Borrower.Add(b);
            _dbContext.SaveChanges();
        }

        public List<Borrower> GetAll()
        {
            return _dbContext.Borrower.ToList();
        }

        public Borrower? GetByEmail(string email)
        {
            return _dbContext.Borrower.FirstOrDefault(b => b.Email == email);
        }

        public Borrower? GetById(int id)
        {
            return _dbContext.Borrower.FirstOrDefault(b => b.BorrowerID == id);
        }

        public void Update(Borrower b)
        {
            _dbContext.Borrower.Update(b);
            _dbContext.SaveChanges();
        }
    }
}
