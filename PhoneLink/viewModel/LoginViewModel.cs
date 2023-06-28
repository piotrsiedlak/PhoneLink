using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PhoneLink.Database;
using SQLitePCL;

namespace PhoneLink.viewModel
{
    class LoginViewModel : BasicViewModel 
    {
        private readonly PhoneLinkDbContext _context;

        public LoginViewModel(PhoneLinkDbContext context)
        {
            _context = context;
            Login = new Command(LoginMethod);
        }

        private void LoginMethod()
        {
            if (Username is null || Password is null)
            {
                MessageBox.Show("Invalid username or password");
                return;
            }

            var user = _context.Users.FirstOrDefault(u => u.userName == Username);
            if (user == null)
            {
                MessageBox.Show("Invalid username");
                return;
            }

            if (user.password == Password)
            {
                MessageBox.Show("Logged in");
            }
            else
            {
                MessageBox.Show("Invalid password");
            }

        }

        private string _username;

        public string Username
        {
            get
            {
                return _username;
            } set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }
        private string _password;

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }
        public ICommand Login { get; }

    }
}
