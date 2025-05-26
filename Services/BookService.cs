using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB_two.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB_two.Services
{
    internal class BookService
    {
        public static void AddBooksForAuthor(string authorName)
        {
            using (var context = new LibraryDbContext())
            {
                var author = context.Authors.AsNoTracking().FirstOrDefault(a => a.Name == authorName);
                if (author == null)
                {
                    Console.WriteLine($"Author '{authorName}' not found.");
                    return;
                }

                var booksToAdd = new List<Book>
                {
                new Book
                {
                    Title = "C#",
                    PublishedYear = 1977,
                    AuthorId = author.Id
                },
                new Book
                {
                    Title = "It",
                    PublishedYear = 1986,
                    AuthorId = author.Id
                },
                new Book
                {
                    Title = "Sql Server",
                    PublishedYear = 1974,
                    AuthorId = author.Id
                }
                 };

                context.Books.AddRange(booksToAdd);
                context.SaveChanges();
            }
        }

        public static void AddBookWithNewAuthorWithNanvigation(string bookTitle, int publishedYear, string authorName)
        {
            using (var context = new LibraryDbContext())
            {
                var newAuthor = new Author
                {
                    Name = authorName
                };

                var newBook = new Book
                {
                    Title = bookTitle,
                    PublishedYear = publishedYear,
                    Author = newAuthor 
                };

                context.Books.Add(newBook);
                context.SaveChanges();
            }
        }

        public static void UpdateBookTitle(string currentTitle, string newTitle)
        {
            using (var context = new LibraryDbContext())
            {
                var bookToUpdate = context.Books.FirstOrDefault(b => b.Title == currentTitle);
                if (bookToUpdate != null)
                {
                    bookToUpdate.Title = newTitle;
                    context.SaveChanges();
                    Console.WriteLine($"Updated Book ID {bookToUpdate.Id} to new title: {bookToUpdate.Title}");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
        }

    }
}
