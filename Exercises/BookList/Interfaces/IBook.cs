namespace BookList.Interfaces
{
    internal interface IBook
    {
        string? Type { get; set; }
        string? Author { get; set; }
        string? Title { get; set; }
    }
}
