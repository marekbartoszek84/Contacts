using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.PC.Contacts.Repository.Entities
{
    public class SubCategory
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        [ForeignKey(nameof(Caategory))]
        public Guid? CategoryId { get; set; }
        public Category? Caategory { get; set; }
    }
}
