using Net.PC.Contacts.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Net.PC.Contacts.Repository.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
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
            var result = context.Categories?.ToList();

            return result;
        }
    }
}
