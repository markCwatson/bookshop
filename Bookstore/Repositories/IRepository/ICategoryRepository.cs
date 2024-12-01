using Bookstore.Models;

namespace Bookstore.Repositories.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
        void Save();
    }
}
