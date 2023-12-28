﻿using Assignment.Interfaces;
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

        [ObservableProperty]
        private ObservableCollection<IContact> _contactList;

        public ContactListViewModel(IServiceProvider sp)
        {
            _sp = sp;

            var _fileService = _sp.GetRequiredService<IFileService>(); //Använder service providern för att hämta FileService, och därmed få listan därifrån
            //var _mainViewModel = _sp.GetRequiredService<MainViewModel>();  /////LÄRORIKT FEL INTRÄFFADE HÄR: När MainViewModel körs igenom, så måste denna constructorn köras igenom eftersom den blir kallad i en required service i MainViewModel. Men eftersom denna constructorn kallar på MainViewModel på samma sätt, måste den gå tillbaka till MainViewModel, sen tillbaka hit igen, osv... Oändlighets loop ungefär. MainViewModel (eller vad som helst) måste alltså köras igenom helt innan man kan referera till den igen på detta sättet förstår jag det som.

            ContactList = new ObservableCollection<IContact>(_fileService.ReadFile(@"..\..\..\..\contactList.json")); //Här importeras listan från filen, och görs om till en ny ObservableCollection.

        }

        [RelayCommand]
        private void ToContactView(IContact contact)
        {
            var _mainViewModel = _sp.GetRequiredService<MainViewModel>();
            var contactViewModel = _sp.GetRequiredService<ContactViewModel>(); //NOTE TO SELF: Jag tror problemet kan bero på att jag instansierar denna där nere igen, eller nåt sånt. transient kanske
            contactViewModel.Contact = contact;
            contactViewModel.OriginalContact = new Contact() { FirstName = contact.FirstName, LastName = contact.LastName, PhoneNumber = contact.PhoneNumber, Email = contact.Email, Address = contact.Address }; //Riktigt stökigt, men jag satt i flera timmar och försökte lista ut något smidigare sätt att lagra de ursprungliga värdena på. Listade inte ut nåt.

            _mainViewModel.CurrentViewModel = contactViewModel;
        }
    }
}
