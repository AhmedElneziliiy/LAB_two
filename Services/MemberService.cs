using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB_two.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB_two.Services
{
    internal class MemberService
    {
        public static void AddAuthor(string authorName)
        {
            using (var context = new LibraryDbContext())
            {
                var newAuthor = new Author
                {
                    Name = authorName
                };
                context.Authors.Add(newAuthor);
                context.SaveChanges();
            }
        }

        public static void UpdateMemberName(string currentName, string newName)
        {
            using (var context = new LibraryDbContext())
            {
                var memberToUpdate = context.Members.FirstOrDefault(m => m.FullName == currentName);
                if (memberToUpdate != null)
                {
                    memberToUpdate.FullName = newName;
                    context.SaveChanges();
                    Console.WriteLine($"Updated Member ID {memberToUpdate.Id} to new name: {memberToUpdate.FullName}");
                }
                else
                {
                    Console.WriteLine("Member not found.");
                }
            }
        }

        public static void AddAuthorWithEntityState(string authorName)
        {
            using (var context = new LibraryDbContext())
            {
                var anotherAuthor = new Author
                {
                    Name = authorName
                };

                context.Entry(anotherAuthor).State = EntityState.Added;
                context.SaveChanges();

                Console.WriteLine($"Author '{anotherAuthor.Name}' added with ID: {anotherAuthor.Id}");
            }
        }

        public static void DeleteBooksByAuthorName(string authorName)
        {
            using (var context = new LibraryDbContext())
            {
                var authorToCheck = context.Authors.AsNoTracking().FirstOrDefault(a => a.Name == authorName);
                if (authorToCheck == null)
                {
                    Console.WriteLine($"Author '{authorName}' not found.");
                    return;
                }

                var booksToDelete = context.Books
                    .Where(b => b.AuthorId == authorToCheck.Id)
                    .ToList();

                if (booksToDelete.Any())
                {
                    foreach (var book in booksToDelete)
                    {
                        context.Entry(book).State = EntityState.Deleted;
                    }

                    context.SaveChanges();
                    Console.WriteLine($"Deleted {booksToDelete.Count} book(s) by author '{authorName}'.");
                }
                else
                {
                    Console.WriteLine($"No books found for author '{authorName}'.");
                }
            }
        }

        public static void AttachAuthor(Author author)
        {
            using (var context = new LibraryDbContext())
            {
                context.Authors.Attach(author);
                context.Entry(author).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public static void CreateGetBookByAuthorIdProcedure()
        {
            using (var context = new LibraryDbContext())
            {
                string createProcSql = @"
                 CREATE PROCEDURE GetBookByAuthorId
                     @AuthorId INT
                  AS
                 BEGIN
                      SELECT * FROM Books WHERE AuthorId = @AuthorId
                  END";

                context.Database.ExecuteSqlRaw(createProcSql);
            }
        }
    }
}
