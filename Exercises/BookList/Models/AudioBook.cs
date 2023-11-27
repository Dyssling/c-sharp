using BookList.Interfaces;

namespace BookList.Models
{
    internal class AudioBook : IBook
    {
        public AudioBook(string title, string author, string fileType, string type)
        {
            Title = title;
            Author = author;
            FileType = fileType;
            Type = type;
        }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Type { get; set; }
        public string? FileType { get; set; }
    }
}
