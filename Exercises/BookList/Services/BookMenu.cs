using BookList.Models;
namespace BookList.Services
{
    internal class BookMenu
    {
        public void Run()
        {
            var bookList = new List<Book>();
            bool run = true;

            while (run == true)
            {
                Console.Clear();
                Console.WriteLine("Boklistan:");
                foreach (Book book in bookList)
                {
                    Console.WriteLine($"{book.Title} av {book.Author} med ISBN {book.ISBN}");
                    Console.WriteLine();
                }

                Console.WriteLine("1: Lägg till en bok.");
                Console.WriteLine("2: Avsluta.");
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

                        bookList.Add(new Book(title, author, isbn));

                        break;

                    case "2":
                        run = false;
                        break;
                }
            }
        }
    }
}
