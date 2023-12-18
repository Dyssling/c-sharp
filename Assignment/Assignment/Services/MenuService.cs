using Assignment.Interfaces;

namespace Assignment.Services
{
    public class MenuService : IMenuService
    {
        public void Menu()
        {
            IFileService fileService = new FileService();
            IContactService contactService = new ContactService();

            List<IContact> contactList = fileService.ReadFile();

            bool exit = false;
            List<string> menuChoices = new List<string>() { "Lägg till kontakt", "Visa kontaktinformation", "Ta bort kontakt", "Avsluta" };
            int menuNum = 0;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine("ADRESSBOK");
                Console.WriteLine("------------------------------");
                Console.WriteLine();
                for (int i = 0; i < menuChoices.Count(); i++)
                {
                    if (menuNum == i)
                    {
                        Console.WriteLine($">> {menuChoices[i]}");
                    }
                    else
                    {
                        Console.WriteLine($"{menuChoices[i]}");
                    }
                    Console.WriteLine();
                }
                contactService.ShowContacts(contactList);

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        if (menuNum == 0)
                        {
                            menuNum = menuChoices.Count() - 1;
                        }
                        else
                        {
                            menuNum--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (menuNum == menuChoices.Count() - 1)
                        {
                            menuNum = 0;
                        }
                        else
                        {
                            menuNum++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        switch (menuNum) //En switch i en switch... tjooooo
                        {
                            case 0:
                                contactService.AddContact(contactList);
                                break;
                            case 1:
                                contactService.ChooseContact(contactList);
                                break;
                            case 2:
                                contactService.RemoveContact(contactList);
                                break;
                            case 3:
                                exit = true;
                                break;
                        }
                        break;
                }
            }
            fileService.SaveContactList(contactList); //Innan programmet avslutas så sparas listan ned i filen. Alla ändringar sparas alltså endast i slutet av programmet.
        }
    }
}
