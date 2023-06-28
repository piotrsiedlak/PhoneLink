using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneLink.Database.Models
{
    public class Contacts
    {
        [Key]
        public int ContactId { get; set; }
        public int UserId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int phoneNumber { get; set; }
        public string address { get; set; }
        public DateTime dateOfBirth { get; set; }
        public IEnumerable<Favorite> Favorites { get; set; }
        public Users User { get; set; }
        public IEnumerable<ContactGroups> ContactGroups { get; set; }
    }
}
