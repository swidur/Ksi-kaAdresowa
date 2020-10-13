using KADataAccess;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace KsiążkaAdresowaGUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            KAContext context = new KAContext();

            context.Database.Migrate();
        }
    }
}
