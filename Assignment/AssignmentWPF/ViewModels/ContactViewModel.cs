using Assignment.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AssignmentWPF.ViewModels
{
    public partial class ContactViewModel : ObservableObject
    {
        [ObservableProperty]
        private IContact? _contact;
    }
}
