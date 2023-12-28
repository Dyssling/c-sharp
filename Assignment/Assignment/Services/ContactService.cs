using Assignment.Interfaces;
using System.Collections.ObjectModel;

namespace Assignment.Services
{
    public class ContactService : IContactService
    {
        public ObservableCollection<IContact> RemoveByEmail(ObservableCollection<IContact> contactList, string emailInput)
        {
            var _contactList = new List<IContact>(contactList); //Jag skapar en vanlig lista av en ObservableCollection, bara för att jag ska kunna använda RemoveAll metoden

            _contactList.RemoveAll(contact => contact.Email == emailInput); //Använder RemoveAll metoden, där jag använder en lambda/arrow operator för att skicka in en parameter som i detta fallet är ett enskilt kontakt-objekt i listan. Alla objekt med en Email property som matchar email strängen tas bort. //Använder RemoveAll metoden, där jag använder en lambda/arrow operator för att skicka in en parameter som i detta fallet är ett enskilt kontakt-objekt i listan. Alla objekt med en Email property som matchar email strängen tas bort.

            return new ObservableCollection<IContact>(_contactList); //Listan konverteras tillbaka till en ObservableCollection
        }
    }
}
