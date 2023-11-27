namespace BookList.Models
{
    internal class Book
    {
        public Book(string title, string author, int isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }
        public string? Title { get; set; } 
        public string? Author { get; set; }
        public int? ISBN { get; set; }
    }
}
