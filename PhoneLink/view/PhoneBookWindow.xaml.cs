﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PhoneLink.Database;
using PhoneLink.viewModel;

namespace PhoneLink.view
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class PhoneBookWindow : Window
    {
        public PhoneBookWindow()
        {
            InitializeComponent();
            DataContext = new PhoneBookViewModel(new PhoneLinkDbContext());
        }
    }


}
