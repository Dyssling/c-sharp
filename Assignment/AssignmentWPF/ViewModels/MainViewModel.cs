using Assignment.Interfaces;
using Assignment.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace AssignmentWPF.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject? _currentViewModel;

        [ObservableProperty]
        private ObservableCollection<IContact> _contactList; //Skapar en null instans av en ObservableCollection som sedan kommer bli listan som importeras från filen

        private readonly IServiceProvider _sp;
        private readonly IFileService _fileService;

        public MainViewModel(IServiceProvider sp) //NOTE TO SELF: Här vill jag istället lägga in så den läser in listan från filen, så det görs en enda gång
        {
            _sp = sp;
            _fileService = _sp.GetRequiredService<IFileService>(); //Använder service providern för att hämta FileService, och därmed få listan därifrån

            ContactList = new ObservableCollection<IContact>(_fileService.ReadFile(@"..\..\..\..\contactList.json")); //Här importeras listan från filen, och görs om till en ny ObservableCollection.

            CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
        }

    }
}
