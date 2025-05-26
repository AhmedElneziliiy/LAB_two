# 
**Features / What this project does:**
**Add Author**
Add a new author to the database using MemberService.AddAuthor.

**Add Books for an Existing Author**
Add multiple books related to an existing author with BookService.AddBooksForAuthor.

**Add Book with New Author and Navigation Property**
Create a new author and a book linked to that author in one transaction using BookService.AddBookWithNewAuthorWithNavigation.

**Update Book Title**
Update the title of an existing book with BookService.UpdateBookTitle.

**Add Author with Entity State Management**
Add a new author by explicitly managing the entity state using MemberService.AddAuthorWithEntityState.

**Delete Books by Author Name**
Delete all books written by a specific author via MemberService.DeleteBooksByAuthorName.

**Performance Comparison**
Compare the performance of Lazy Loading vs Eager Loading with PerformanceService.CompareLazyAndEagerLoading.

**Attach Entity to Update Without Retrieval**
Attach an existing author entity to the context and update it without fetching from the database first, using MemberService.AttachAuthor.

**Create and Use Stored Procedure**
Create a stored procedure GetBookByAuthorId with MemberService.CreateGetBookByAuthorIdProcedure and execute it to retrieve books by author ID.

