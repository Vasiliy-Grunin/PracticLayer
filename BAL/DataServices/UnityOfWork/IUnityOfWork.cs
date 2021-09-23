using DataServices.AuthorServices;
using DataServices.BookServices;
using DataServices.GenryServices;
using DataServices.ReaderServices;

namespace DataServices.UnityOfwork
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
