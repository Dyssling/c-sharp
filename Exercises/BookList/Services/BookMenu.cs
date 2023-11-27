using BookList.Interfaces;
using BookList.Models;
namespace BookList.Services
{
    internal class BookMenu
    {
        public void Run()
        {
            var bookList = new List<IBook>();
            bool run = true;

            while (run == true)
            {
                Console.Clear();
                Console.WriteLine("Boklistan:");
                foreach (var book in bookList)
                {
                    if (book is Book x)
                    {
                        Console.WriteLine($"{x.Type}en {x.Title} av {x.Author} med ISBN {x.ISBN}");
                        Console.WriteLine();
                    }

                    else if (book is AudioBook y)
                    {
                        Console.WriteLine($"{y.Type}en {y.Title} av {y.Author} med filtypen {y.FileType}");
                        Console.WriteLine();
                    }
                }

                Console.WriteLine("1: Lägg till en bok.");
                Console.WriteLine("2: Lägg till en ljudbok.");
                Console.WriteLine("3: Avsluta.");
                Console.WriteLine();
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Bokens titel: ");
                        string title = Console.ReadLine()!;

                        Console.Write("Bokens författare: ");
                        string author = Console.ReadLine()!;

                        Console.Write("Bokens ID: ");
                        int isbn = int.Parse(Console.ReadLine()!);

                        bookList.Add(new Book(title, author, isbn, "Bok"));

                        break;

                    case "2":
                        Console.Clear();
                        Console.Write("Ljudbokens titel: ");
                        title = Console.ReadLine()!;

                        Console.Write("Bokens författare: ");
                        author = Console.ReadLine()!;

                        Console.Write("Bokens ID: ");
                        string fileType = Console.ReadLine()!;

                        bookList.Add(new AudioBook(title, author, fileType, "Ljudbok"));

                        break;

                    case "3":
                        run = false;
                        break;
                }
            }
        }
    }
}
