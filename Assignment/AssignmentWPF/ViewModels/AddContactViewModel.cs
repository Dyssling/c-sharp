using Assignment.Interfaces;
using Assignment.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace AssignmentWPF.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {
        private readonly IServiceProvider _sp;

        public IContact Contact { get; set; } = new Contact();

        public AddContactViewModel(IServiceProvider sp)
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
        private void SaveToContactList()
        {
            var _contactListViewModel = _sp.GetRequiredService<ContactListViewModel>();
            var _mainViewModel = _sp.GetRequiredService<MainViewModel>();
            var _fileService = _sp.GetRequiredService<IFileService>();

            _contactListViewModel.ContactList.Add(Contact); //Kontakten med värdena som är bindade till TextBoxarna läggs till i listan.
            _fileService.SaveContactListWPF(_contactListViewModel.ContactList, @"..\..\..\..\contactList.json");
            _mainViewModel.CurrentViewModel = _contactListViewModel;
        }
    }
}
