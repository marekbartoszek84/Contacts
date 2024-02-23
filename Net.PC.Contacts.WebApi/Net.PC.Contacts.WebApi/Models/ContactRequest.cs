using Net.PC.Contacts.Repository.Entities;

namespace Net.PC.Contacts.WebApi.Models
{
    public class ContactRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? SubCategoryId { get; set; }
        public SubCategoryRequest? SubCategoryRequest { get; set;}
        public string? Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
