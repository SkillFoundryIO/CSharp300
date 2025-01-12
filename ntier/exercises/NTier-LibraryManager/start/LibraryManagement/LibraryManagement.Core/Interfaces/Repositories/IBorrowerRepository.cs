using LibraryManagement.Core.Entities;

namespace LibraryManagement.Core.Interfaces.Repositories
{
    public interface IBorrowerRepository
    {
        void Add(Borrower b);
        void Update(Borrower b);
        List<Borrower> GetAll();
        Borrower? GetById(int id);
        Borrower? GetByEmail(string email);
    }
}
