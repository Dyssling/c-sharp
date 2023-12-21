using Assignment.Interfaces;
using Assignment.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace AssignmentWPF.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        //[ObservableProperty]
        //public ObservableCollection<IContact> _contactList;
        //private IFileService _fileService = new FileService();

        //public MainViewModel()
        //{
        //    ContactList = new ObservableCollection<IContact>(_fileService.ReadFile(@"c:\Education\c-sharp\Assignment\contactList.json"));
        //}

        [ObservableProperty]
        private ObservableObject? _currentViewModel;

        private readonly IServiceProvider _sp;

        public MainViewModel(IServiceProvider sp)
        {
            _sp = sp;

            CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
        }

    }
}
