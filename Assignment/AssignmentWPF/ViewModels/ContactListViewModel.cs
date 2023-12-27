using Assignment.Interfaces;
using Assignment.Models;
using Assignment.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace AssignmentWPF.ViewModels
{
    public partial class ContactListViewModel : ObservableObject
    {
        private readonly IServiceProvider _sp;
        private readonly IFileService _fileService;

        [ObservableProperty]
        private ObservableCollection<IContact> _contactList;

        public ContactListViewModel(IServiceProvider sp)
        {
            _sp = sp;

            _fileService = _sp.GetRequiredService<IFileService>(); //Använder service providern för att hämta FileService, och därmed få listan därifrån

            ContactList = _fileService.GetContacts(); //Här kör jag funktionen som faktiskt returnerar listan så jag kan använda den i applikationen

        }

        [RelayCommand]
        private void ToContactView()
        {
            var mainViewModel = _sp.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactViewModel>();
        }
    }
}
