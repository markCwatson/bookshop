using Bookstore.Data;
using Bookstore.Repositories.IRepository;

namespace Bookstore.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private AppDbContext _db;
        public ICategoryRepository CategoryRepo { get; private set; }

        public RepositoryManager(AppDbContext db)
        {
            _db = db;
            CategoryRepo = new CategoryRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
