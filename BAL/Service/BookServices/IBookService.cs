using DAL.Entitys.Dto;
using DAL.Entitys.Model;
using Service.GynericRepositorys;

namespace Service.BookServices
{
    public interface IBookService : IRepository<BookModel, BookDto>
    {
    }
    public interface IBookServiceBase : IRepository<BookModel, BookBaseDto>
    {
    }
}