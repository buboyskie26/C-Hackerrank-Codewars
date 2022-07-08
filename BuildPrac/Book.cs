using System.Collections.Generic;

namespace BuildPrac
{
 
        public class Book
        {
            public int BookID { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
        }
     
        public class Samp
    {
        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();

            books.Add(new Book { BookID = 1, Title = "Book Title 1", Author = "Author 1" });
            books.Add(new Book { BookID = 2, Title = " Book Title 2", Author = "Author 2" });
            books.Add(new Book { BookID = 3, Title = " Book Title 3", Author = "Author 1" });
            books.Add(new Book { BookID = 4, Title = " Book Title 4", Author = "Author 2" });
            books.Add(new Book { BookID = 5, Title = " Book Title 5", Author = "Author 8" });
            books.Add(new Book { BookID = 6, Title = " Book Title 4", Author = "Author 2" });
            books.Add(new Book { BookID = 7, Title = " Book Title 6", Author = "Author 4" });
            books.Add(new Book { BookID = 8, Title = " Book Title 8", Author = "Author 2" });
            books.Add(new Book { BookID = 9, Title = " Book Title 3", Author = "Author 3" });
            books.Add(new Book { BookID = 10, Title = " Book Title 5", Author = "Author 1" });

            return books;
        }

    }


}
