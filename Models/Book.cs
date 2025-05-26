using System;
using System.Collections.Generic;

namespace LAB_two.Models;

public partial class Book
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? PublishedYear { get; set; }

    public int? AuthorId { get; set; }

    public virtual Author? Author { get; set; }

    public virtual ICollection<BookCheckout> BookCheckouts { get; set; } = new List<BookCheckout>();
}
