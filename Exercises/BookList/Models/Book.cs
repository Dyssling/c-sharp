﻿using BookList.Interfaces;

namespace BookList.Models
{
    internal class Book : IBook
    {
        public Book(string title, string author, int isbn, string type)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Type = type;
        }
        public string? Title { get; set; } 
        public string? Author { get; set; }
        public string? Type { get; set; }
        public int? ISBN { get; set; }
    }
}
