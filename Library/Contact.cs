using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Contact
    {
        public Contact(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string lastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Group { get; set; }
        public DateTime dateOfBirth { get; set; }




        public override string ToString()
        {
            return $"Name: {Name}, Phone Number: {PhoneNumber}";
        }
    }
}
