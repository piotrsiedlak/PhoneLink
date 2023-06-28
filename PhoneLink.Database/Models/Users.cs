using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneLink.Database.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public IEnumerable<Contacts> UserContacts { get; set; }
    }
}
