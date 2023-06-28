using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneLink.Database.Models
{
    public class Favorite
    {
        [Key]
        public int FavoriteId { get; set; }
        public int ContactId { get; set; }
        public Contacts Contact { get; set; }
    }
}
