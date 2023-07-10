using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PhoneLink.Database;
using PhoneLink.Database.Models;

namespace PhoneLink.viewModel
{
    public class AddWindowViewModel : BasicViewModel
    {
        private readonly PhoneLinkDbContext _context;
        private readonly Command _add;

        public AddWindowViewModel(PhoneLinkDbContext context)
        {
            _context = context;
            Add = new Command(AddContact);

        }

        public Command Add { get; set; }

        #region firstName

        private string _firstName;
        public string firstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(firstName));
                }
            }
        }

        #endregion

        #region lastName
        private string _lastName;
        public string lastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(lastName));
                }
            }
        }
        #endregion

        #region email
        private string _email;

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }
        #endregion

        #region phone

        private string _phone;

        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged(nameof(Phone));
                }
            }
        }

        #endregion

        #region DateOfBirth

        private string _dateOfBirth;

        public string DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                if (_dateOfBirth != value)
                {
                    _dateOfBirth = value;
                    OnPropertyChanged(nameof(DateOfBirth));
                }
            }
        }

        #endregion

        #region address
        private string _address;

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }
        #endregion

        #region isFavorite
        private bool _isFavorite;
        public bool IsFavorite
        {
            get { return _isFavorite; }
            set
            {
                _isFavorite = value;
                OnPropertyChanged(nameof(IsFavorite));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion
        #region ContactGroups
        private string _contactGroups;

        public string ContactGroups
        {
            get
            {
                return _contactGroups;
            }
            set
            {
                if (_contactGroups != value)
                {
                    _contactGroups = value;
                    OnPropertyChanged(nameof(ContactGroups));
                }
            }
        }
        #endregion

        private void UpdateGroup()
        {
            int? groupNumbers = ContactGroups switch
            {
                "System.Windows.Controls.ComboBoxItem: Normal" => 1,
                "System.Windows.Controls.ComboBoxItem: Friend" => 2,
                "System.Windows.Controls.ComboBoxItem: Work" => 3,
                _ => null
            };
        }

        private void AddContact()
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Phone) || string.IsNullOrWhiteSpace(Address) || string.IsNullOrWhiteSpace(DateOfBirth) || string.IsNullOrWhiteSpace(ContactGroups))
            {
                MessageBox.Show("Please fill in all the required fields.", "Error");
                return; 
            }

            var contact = new Contacts
            {
                UserId = 1,
                firstName = firstName,
                lastName = lastName,
                email = Email,
                phoneNumber = int.Parse(Phone),
                address = Address,
                dateOfBirth = DateTime.Parse(DateOfBirth),
                Favorites = IsFavorite,
                User = null,
                ContactGroups = ContactGroups
            };

            _context.Add(contact);
            _context.SaveChanges();
            MessageBox.Show("Contact added successfully.", "Success");
            firstName = "";
            lastName = "";
            Email = "";
            Phone = "";
            Address = "";
            DateOfBirth = "";

        }
    }
}
