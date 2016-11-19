using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace BookListStorage
{
    public interface IBookListStorage
    {
        void SaveBooks(List<Book> books);
        List<Book> LoadBooks();
    }
}
