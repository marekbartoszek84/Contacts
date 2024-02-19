using System.ComponentModel.DataAnnotations.Schema;

namespace Net.PC.Contacts.Repository.Entities
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        [ForeignKey(nameof(Caategory))]
        public Guid? CategoryId { get; set; }
        public Category? Caategory { get; set; }
        public string? Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
