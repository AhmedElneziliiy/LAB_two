using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB_two.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB_two.Services
{
    internal class PerformanceService
    {
        public static void CompareLazyAndEagerLoading()
        {
            using (var context = new LibraryDbContext())
            {
                var stopwatch = new Stopwatch();

                // Lazy Loading
                stopwatch.Start();
                var lazyAuthors = context.Authors.AsNoTracking().ToList();
                foreach (var author in lazyAuthors)
                {
                    var books = author.Books.ToList();
                }
                stopwatch.Stop();
                Console.WriteLine("Lazy loading: " + stopwatch.ElapsedMilliseconds + " ms");

                // Eager Loading
                stopwatch.Restart();
                var eagerAuthors = context.Authors.AsNoTracking().Include(a => a.Books).ToList();
                stopwatch.Stop();
                Console.WriteLine("Eager loading: " + stopwatch.ElapsedMilliseconds + " ms");
            }
        }
    }
}
