using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PhoneLink.Database;
using PhoneLink.viewModel;

namespace PhoneLink
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var context = new PhoneLinkDbContext();
            DataContext = new LoginViewModel(context);
        }

        private void Username_focus(object sender, MouseButtonEventArgs e)
        {
            Username.Focus();
        }

        private void Password_focus(object sender, MouseButtonEventArgs e)
        {
            Password.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
