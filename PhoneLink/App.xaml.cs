using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using PhoneLink.Database;

namespace PhoneLink
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            using (var context = new PhoneLinkDbContext())
            {
                context.Database.Migrate();

                var seeder = new DaneBazy(context);
                seeder.WypelnijBaze();
            }
        }
    }
}
