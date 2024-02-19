using Microsoft.EntityFrameworkCore;
using Net.PC.Contacts.Repository.Entities;

namespace Net.PC.Contacts.Repository.Repository
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAll();
        Contact GetDetails(Guid id);
        void Add(Contact contact);
        void Delete(Guid id);
    }

    public class ContactRepository : IContactRepository
    {
        protected ContactDbContext context;

        public ContactRepository(ContactDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Contact> GetAll()
        {
            var result = context.Contacts?.ToList();

            return result;
        }

        public Contact GetDetails(Guid id)
        {
            var result = context.Contacts?
                .Include(c => c.Caategory)
                .Where(c => c.Id == id).FirstOrDefault();

            return result;
        }

        public void Add(Contact contact)
        {
            context.Contacts?.Add(contact);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var contact = context.Contacts?
                .Where(c => c.Id == id).FirstOrDefault();

            if (contact != null)
            {
                context.Contacts?.Remove(contact);
                context.SaveChanges();
            }
        }
    }
}
