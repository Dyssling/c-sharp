using Assignment.Interfaces;
using Assignment.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

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
            IContactService _contactService = new ContactService();
            _contactListViewModel.ContactList = _contactService.RemoveByEmail(_contactListViewModel.ContactList, EmailInput!);

            var _mainViewModel = _sp.GetRequiredService<MainViewModel>();
            _mainViewModel.CurrentViewModel = _contactListViewModel;
        }
    }
}
