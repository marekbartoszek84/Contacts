using Microsoft.AspNetCore.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net.PC.Contacts.Repository.Entities
{
    public class User : IdentityUser
    {
    }
}
