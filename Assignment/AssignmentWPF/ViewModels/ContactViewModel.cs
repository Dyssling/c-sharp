using Assignment.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace AssignmentWPF.ViewModels
{
    public partial class ContactViewModel : ObservableObject
    {
        private readonly IServiceProvider _sp;
        public IContact? OriginalContact { get; set; }
        public IContact? Contact { get; set; }

        public ContactViewModel(IServiceProvider sp)
        {
            _sp = sp;
        }

        [RelayCommand]
        public void CancelToContactListView()
        {
            Contact!.FirstName = OriginalContact!.FirstName; //Detta känns onödigt stökigt. Jag satt i flera timmar och försökte få detta att funka, och det enda sättet som funkade var att "öppna upp" objektet på detta viset. Det har någonting med objekt referenser att göra förstår jag det som...
            Contact!.LastName = OriginalContact!.LastName;
            Contact!.PhoneNumber = OriginalContact!.PhoneNumber;
            Contact!.Email = OriginalContact!.Email;
            Contact!.Address = OriginalContact!.Address;

            var _mainViewModel = _sp.GetRequiredService<MainViewModel>();
            _mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
        }

        [RelayCommand]
        public void SaveToContactListView()
        {
            var _mainViewModel = _sp.GetRequiredService<MainViewModel>();
            _mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
        }

        [RelayCommand]
        public void RemoveToContactListView()
        {
            var _contactList = _sp.GetRequiredService<ContactListViewModel>();
            _contactList.ContactList.Remove(Contact!);

            var _mainViewModel = _sp.GetRequiredService<MainViewModel>();
            _mainViewModel.CurrentViewModel = _contactList;
        }
    }
}
