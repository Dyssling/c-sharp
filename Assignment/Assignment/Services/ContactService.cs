using Assignment.Interfaces;
using Assignment.Models;

namespace Assignment.Services
{
    /// <summary>
    /// Add contact.
    /// </summary>
    public class ContactService : IContactService
    {
        public void ShowContacts(List<IContact> contactList)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("KONTAKTER");
            Console.WriteLine("------------------------------");
            Console.WriteLine();

            for (int i = 0; i < contactList.Count(); i++) //Gör en vanlig for-loop istället för foreach, p.g.a att jag även vill ha ett index.
            {
                Console.WriteLine($"{contactList[i].FirstName} {contactList[i].LastName}");
            }
        }

        public void AddContact(List<IContact> contactList)
        {
            bool exit = false;
            IContact newContact = new Contact();

            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("LÄGG TILL KONTAKT");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
            Console.WriteLine("(Skriv 'exit' för att gå tillbaka)");
            Console.WriteLine();

            Console.Write("Förnamn: ");
            newContact.FirstName = Console.ReadLine()!;
            Console.WriteLine();
            if (newContact.FirstName == "exit")
            {
                exit = true;
            }

            if (!exit)
            {
                Console.Write("Efternamn: ");
                newContact.LastName = Console.ReadLine()!;
                Console.WriteLine();

                if (newContact.LastName == "exit")
                {
                    exit = true;
                }
            }

            if (!exit)
            {
                Console.Write("Telefonnummer: ");
                newContact.PhoneNumber = Console.ReadLine()!;
                Console.WriteLine();

                if (newContact.PhoneNumber == "exit")
                {
                    exit = true;
                }
            }

            if (!exit)
            {
                Console.Write("E-post: ");
                newContact.Email = Console.ReadLine()!;
                Console.WriteLine();

                if (newContact.Email == "exit")
                {
                    exit = true;
                }
            }

            if (!exit)
            {
                Console.Write("Adress: ");
                newContact.Address = Console.ReadLine()!;
                Console.WriteLine();

                if (newContact.Address == "exit")
                {
                    exit = true;
                }
            }

            if (!exit)
            {
                contactList.Add(newContact);
            }
        }

        public int ChooseContact(List<IContact> contactList)
        {
            bool exit = false;
            int contactChoice = 0;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine("VÄLJ EN KONTAKT");
                Console.WriteLine("------------------------------");
                Console.WriteLine();

                for (int i = 0; i < contactList.Count(); i++) //Gör en vanlig for-loop istället för foreach, p.g.a att jag även vill ha ett index.
                {
                    if (contactChoice == i)
                    {
                        Console.WriteLine($">> {contactList[i].FirstName} {contactList[i].LastName}");
                    }
                    else
                    {
                        Console.WriteLine($"{contactList[i].FirstName} {contactList[i].LastName}");
                    }
                }

                Console.WriteLine();

                if (contactChoice == contactList.Count()) //Om siffran för alternativet är samma siffra som mängden kontakter i listan, så kan man garantera att man är ett steg under kontakterna, alltså på "tillbaka" knappen
                {
                    Console.WriteLine("<< Tillbaka");
                }
                else
                {
                    Console.WriteLine("Tillbaka");
                }

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        if (contactChoice == 0)
                        {
                            contactChoice = contactList.Count(); //Här hamnar pilen på tillbaka knappen
                        }
                        else
                        {
                            contactChoice--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (contactChoice == contactList.Count()) //Om man däremot redan är på tillbaka knappen, så kan man inte komma längre ner. Man hamnar istället högst upp i listan
                        {
                            contactChoice = 0;
                        }
                        else
                        {
                            contactChoice++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (contactChoice == contactList.Count())
                        {
                            exit = true;
                        }
                        else
                        {
                            ViewContactInformation(contactList, contactChoice);
                        }
                        break;
                }
            }
            return contactChoice;
            
        }

        public void ViewContactInformation(List<IContact> contactList, int contactInteger)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine("KONTAKTINFORMATION");
                Console.WriteLine("------------------------------");
                Console.WriteLine();

                Console.WriteLine($"Förnamn: {contactList[contactInteger].FirstName}");
                Console.WriteLine();
                Console.WriteLine($"Efternamn: {contactList[contactInteger].LastName}");
                Console.WriteLine();
                Console.WriteLine($"Telefonnummer: {contactList[contactInteger].PhoneNumber}");
                Console.WriteLine();
                Console.WriteLine($"E-post: {contactList[contactInteger].Email}");
                Console.WriteLine();
                Console.WriteLine($"Adress: {contactList[contactInteger].Address}");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("<< Tillbaka");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    exit = true;
                }
            }
        }

        public void RemoveContact(List<IContact> contactList)
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("TA BORT KONTAKT");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
            Console.WriteLine("För att ta bort en kontakt måste du skriva in deras e-postadress.");
            Console.WriteLine();
            Console.Write("Kontaktens e-postadress: ");

            string email = Console.ReadLine()!;

            contactList.RemoveAll(contact => contact.Email == email); //Använder RemoveAll metoden, där jag använder en lambda/arrow operator för att skicka in en parameter som i detta fallet är ett enskilt kontakt-objekt i listan. Alla objekt med en Email property som matchar email strängen tas bort.

        }
    }
}
