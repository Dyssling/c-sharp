using Assignment.Interfaces;
using Assignment.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace AssignmentWPF.ViewModels
{
    public partial class RemoveViewModel : ObservableObject
    {
        private readonly IServiceProvider _sp;

        public string? EmailInput { get; set; }

        public RemoveViewModel(IServiceProvider sp)
        {
            _sp = sp;
        }

        [RelayCommand]
        private void ToContactList()
        {
            var _mainViewModel = _sp.GetRequiredService<MainViewModel>();
            _mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
        }

        [RelayCommand]
        private void RemoveByEmail()
        {
            var _contactListViewModel = _sp.GetRequiredService<ContactListViewModel>();
            var _fileService = _sp.GetRequiredService<IFileService>();
            IContactService _contactService = new ContactService(); //Skapar en vanlig instans av denna service, då jag inte ser någon anledning till att göra dependency injection varianten.
            _contactListViewModel.ContactList = _contactService.RemoveByEmail(_contactListViewModel.ContactList, EmailInput!);
            _fileService.SaveContactListWPF(_contactListViewModel.ContactList, @"..\..\..\..\contactList.json");

            var _mainViewModel = _sp.GetRequiredService<MainViewModel>();
            _mainViewModel.CurrentViewModel = _contactListViewModel;
        }
    }
}
