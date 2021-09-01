using DAL.Service.AuthorServices;
using DAL.Service.BookServices;
using DAL.Service.GenryServices;
using DAL.Service.ReaderServices;

namespace DAL.Service.UnityOfwork
{
    public interface IUnityOfWork
    {
        IReaderService Readers { get; }
        IGenryService Genrys { get; }
        IAuthorService Authors { get; }
        IBookService Books { get; }
        IReaderServiceBase BaseReaders { get; }
        IGenryServiceBase BaseGenrys { get; }
        IAuthorServiceBase BaseAuthors { get; }
        IBookServiceBase BaseBooks { get; }

        int Complete();
    }
}
