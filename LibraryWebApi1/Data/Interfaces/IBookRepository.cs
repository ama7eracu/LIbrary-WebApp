using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryWebApi1.Models;

namespace LibraryWebApi1.Data.Interfaces
{
    public interface IBookRepository
    {
        Task<bool> BookExists(long bookId);
        Task<ICollection<Book>> GetAllBook();
        Task<Book?> GetBook(long id);
        Task<bool> AddBook (Book book);
        Task<bool> DeleteBook(Book book);
        Task<bool> EditBook(long id ,Book book);
        Task<bool> Save();
    }
}