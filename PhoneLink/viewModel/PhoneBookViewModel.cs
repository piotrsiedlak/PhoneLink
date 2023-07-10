using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using PhoneLink.Database;
using PhoneLink.Database.Models;
using PhoneLink.view;

namespace PhoneLink.viewModel;

internal class PhoneBookViewModel : BasicViewModel
{
    private readonly PhoneLinkDbContext _context;
    private string _password;


    private ObservableCollection<presentContact> _showContacts;
    private string _idToRemove;

    public PhoneBookViewModel(PhoneLinkDbContext context)
    {
        _context = context;
        AboutUs = new Command(ShowAboutUs);
        AddContact = new Command(ShowAddContact);
        LogOut = new Command(DoLogOut);
        Refresh = new Command(updateContacts);
        RemoveContact = new Command(DoRemoveContact);
        updateContacts();

    }

    public Command Refresh { get; set; }


    public Command RemoveContact { get; set; }

    private void DoRemoveContact()
    {
        var contactToRemove = _context.Set<Contacts>().Find(Convert.ToInt32(IDToRemove));

        if (contactToRemove != null)
        {
            _context.Set<Contacts>().Remove(contactToRemove);
            _context.SaveChanges();

        }
        updateContacts();
    }

    public ObservableCollection<presentContact> ContactsList
    {
        get => _showContacts;
        set
        {
            _showContacts = value;
            OnPropertyChanged();
        }
    }

    public void updateContacts()
    {
        ContactsList = new ObservableCollection<presentContact>(GetContacts());
    }
    private IEnumerable<presentContact> GetContacts()
    {

        List<presentContact> contacts = new List<presentContact>();
        foreach (Contacts contact in _context.Contacts)
        {
            var contactperson = new presentContact
            {
                ContactId = contact.ContactId,
                Name = contact.firstName,
                SecondName = contact.lastName
            };
            contacts.Add(contactperson);
        }
        return contacts;
    }

    public Command LogOut { get; set; }

    public Command EditContact { get; set; }

    public Command AddContact { get; set; }

    public string IDToRemove
    {
        get => _idToRemove;
        set
        {
            if (_idToRemove != value)
            {
                _idToRemove = value;
                OnPropertyChanged(IDToRemove);
            }
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            if (_password != value)
            {
                _password = value;
                OnPropertyChanged();
            }
        }
    }

    public ICommand AboutUs { get; }

    private void DoLogOut()
    {
        var window = new MainWindow();
        if (Application.Current.MainWindow != null) Application.Current.MainWindow.Close();
        Application.Current.MainWindow = window;
        window.Show();
    }



    private void ShowAddContact()
    {
        var window = new AddWindow();
        Application.Current.MainWindow = window;
        window.Show();
    }

    private void ShowAboutUs()
    {
        var window = new AboutUs();
        Application.Current.MainWindow = window;
        window.Show();
    }

    public class presentContact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public bool IsFavorite { get; set; }
        public string Group { get; set; }
    }
}