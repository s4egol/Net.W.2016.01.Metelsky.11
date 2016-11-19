using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookListStorage;
using Task1;
using System.IO;

namespace Storage
{
    public class BookListStorage : IBookListStorage
    {
        private readonly string pathFile;

        public BookListStorage(string pathFile)
        {
            this.pathFile = pathFile;
        }

        public void SaveBooks(List<Book> books)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(pathFile, FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < books.Count; i++)
                {
                    writer.Write(books[i].Author);
                    writer.Write(books[i].CountPages);
                    writer.Write(books[i].PublicationYear);
                    writer.Write(books[i].Title);
                }
            }
        }

        public List<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();

            using (BinaryReader reader = new BinaryReader(File.Open(pathFile, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string Author = reader.ReadString();
                    int CountOfPages = reader.ReadInt32();
                    int PublicationYear = reader.ReadInt32();
                    string Title = reader.ReadString();
                    books.Add(new Book(Title, CountOfPages, PublicationYear, Author));
                }
            }

            return books;
        }
    }
}
