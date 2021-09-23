using DAL.Entitys.Dto;
using DAL.Entitys.Model;
using DataServices.GynericRepositorys;

namespace DataServices.BookServices
{
    public interface IBookService : IRepository<BookModel, BookDto>
    {
    }
    public interface IBookServiceBase : IRepository<BookModel, BookBaseDto>
    {
    }
}