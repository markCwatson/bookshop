using Bookstore.Data;

namespace Bookstore.Repositories.IRepository
{
    public interface IRepositoryManager
    {
        public ICategoryRepository CategoryRepo { get; }

        public void Save();
    }
}
