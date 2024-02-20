using Microsoft.EntityFrameworkCore;
using Net.PC.Contacts.Repository.Entities;

namespace Net.PC.Contacts.Repository.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        void AddSubcategory(SubCategory subCategory);
    }

    public class CategoryRepository : ICategoryRepository
    {
        protected ContactDbContext context;

        public CategoryRepository(ContactDbContext _context)
        {
            context = _context;
        }

        public IEnumerable<Category> GetAll()
        {
            var result = context.Categories?
                .Include(c => c.SubCategories)
                .ToList();

            return result;
        }

        public void AddSubcategory(SubCategory subCategory)
        {
            context.SubCategories?.Add(subCategory);
            context.SaveChanges();
        }
    }
}
