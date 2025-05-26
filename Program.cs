using System.Diagnostics;
using LAB_two.Models;
using LAB_two.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LAB_two
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            MemberService.AddAuthor("Ahmed Gamal");

            //2
            BookService.AddBooksForAuthor("Ahmed Elneziliy");

            //3
            BookService.AddBookWithNewAuthorWithNanvigation("Salam ya sa7by", 1990, "Chritofar Nolan");

            //4 update
            BookService.UpdateBookTitle("Java", "C#");

            //5
            MemberService.AddAuthorWithEntityState("Salma Elneziliiy");

            //6 dedlet books by author
            MemberService.DeleteBooksByAuthorName("Chritofar Nolan");

            //7 Performance
            PerformanceService.CompareLazyAndEagerLoading();

            //8 Attach to update objects without retrieving them first.
            var author = new Author
            {
                Id = 1,
                Name = "أحمد النزيلي"
            };

            MemberService.AttachAuthor(author);

            //9 CReate storedf proc
            MemberService.CreateGetBookByAuthorIdProcedure();

            int authorId = 1;
            using (var context = new LibraryDbContext())
            {
                var books = context.Books
                    .FromSqlRaw("EXEC GetBookByAuthorId @AuthorId = {0}", authorId)
                    .ToList();

                foreach (var book in books)
                {
                    Console.WriteLine(book.Title);
                }
            }


        }
    }
}
