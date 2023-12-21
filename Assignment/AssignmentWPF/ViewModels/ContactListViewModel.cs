using Assignment.Interfaces;
using Assignment.Models;
using Assignment.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace AssignmentWPF.ViewModels
{
    public partial class ContactListViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<IContact> _contactList; //Skapar en null instans av en ObservableCollection som sedan kommer bli listan som importeras från filen

        private readonly IServiceProvider _sp;
        private readonly IFileService _fileService;

        public ContactListViewModel(IServiceProvider sp)
        {
            _sp = sp;

            _fileService = _sp.GetRequiredService<IFileService>(); //Använder service providern för att hämta FileService, och därmed få listan därifrån

            ContactList = new ObservableCollection<IContact>(_fileService.ReadFile(@"..\..\..\..\contactList.json")); //Importerar listan från filen till min ObservableCollection. Tyvärr görs detta varje gång, eftersom omvandlingen från en vanlig lista till en ObservableCollection måste ske på nåt vis, och jag har inte implementerat nån annan lösning på det
        }
    }
}
