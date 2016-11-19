using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task1;
using BookListStorage;

namespace Service
{
    public class BookListService
    {
        public List<Book> Books { get; }

        public BookListService(List<Book> books)
        {
            if (books != null)
                Books = books;
        }

        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
                throw new ArgumentNullException();

            bool contains = Books.Contains(book);
            if (!contains)
                Books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
                throw new ArgumentNullException();

            bool contains = Books.Contains(book);
            if (contains)
                Books.Remove(book);
        }

        public void SortBooksByTag(IComparer<Book> comparer)
        {
            Books.Sort(comparer);
        }

        public Book FindBookByAuthor(string author) =>
            FindBookByTag(n => n.Author == author);

        public Book FindBookByTitle(string title) =>
            FindBookByTag(n => n.Title == title);

        public Book FindBookByPages(int countPages) =>
            FindBookByTag(n => n.CountPages == countPages);

        public Book FindBookByPublicationYear(int publicationYear) =>
            FindBookByTag(n => n.PublicationYear == publicationYear);

        private Book FindBookByTag(Func<Book, bool> match)
        {
            if (ReferenceEquals(match, null))
                throw new ArgumentException();

            return Books.First(match);
        }

        public void Save(IBookListStorage bookListStorage)
        { 
            if (ReferenceEquals(bookListStorage, null))
                throw new ArgumentNullException(); 

            bookListStorage.SaveBooks(Books); 
        }
    }
}
