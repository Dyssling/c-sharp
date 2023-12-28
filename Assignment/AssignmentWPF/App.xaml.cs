using Assignment.Interfaces;
using Assignment.Models;
using Assignment.Services;
using AssignmentWPF.ViewModels;
using AssignmentWPF.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace AssignmentWPF
{
    public partial class App : Application
    {
        private static IHost? builder;

        public App()
        {
            builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<IFileService, FileService>();
                services.AddSingleton<ContactListViewModel>();
                services.AddSingleton<ContactListView>();
                services.AddTransient<ContactViewModel>();
                services.AddTransient<ContactView>();
                services.AddTransient<RemoveViewModel>();
                services.AddTransient<RemoveView>();
                services.AddTransient<AddContactViewModel>();
                services.AddTransient<AddContactView>();
            })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            builder!.Start();

            var mainWindow = builder!.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
