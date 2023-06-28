using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneLink.Database.Models
{
    public class Groups
    {
        [Key]
        public int GroupId { get; set; }
        public int groupName { get; set; }
        public IEnumerable<ContactGroups> ContactGroups { get; set; }
    }
}
