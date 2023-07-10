using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneLink.Database.Models;

namespace PhoneLink.Database
{
    public class DaneBazy
    {
        private readonly PhoneLinkDbContext _context;

        public DaneBazy(PhoneLinkDbContext context)
        {
            _context = context;
        }

        public void WypelnijBaze()
        {
            if (!_context.Users.Any())
            {
                var user = new Users()
                {
                    userName = "admin",
                    password = "admin1",
                    email = "admin@phonelink.com"
                };
                _context.Users.Add(user);
                _context.SaveChanges();
            }

            if (!_context.Contacts.Any())
            {
                List<Contacts> contacts = new List<Contacts>
                {
                    new Contacts
                    {
                        UserId = 1,
                        firstName = "Jan",
                        lastName = "Kowalski",
                        email = "jan.kowalski@example.com",
                        phoneNumber = 123456789,
                        address = "ul. Kwiatowa 1, Warszawa",
                        dateOfBirth = new DateTime(1990, 5, 10),
                        Favorites = true,
                        User = null,
                        ContactGroups = "friend"
                    },
                    new Contacts
                    {
                        UserId = 1,
                        firstName = "Anna",
                        lastName = "Nowak",
                        email = "anna.nowak@example.com",
                        phoneNumber = 987654321,
                        address = "ul. Główna 2, Kraków",
                        dateOfBirth = new DateTime(1985, 12, 15),
                        Favorites = false,
                        User = null,
                        ContactGroups = "normal"
                    }
                };
                _context.Contacts.AddRange(contacts);
                _context.SaveChanges();
            }

        }
    }
}
