using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneLink.Database.Models
{
    public class ContactGroups
    {
        public int GroupId { get; set; }
        public int ContactId { get; set; }
        public Groups Group { get; set; }
        public Contacts Contact { get; set; }
    }
}
