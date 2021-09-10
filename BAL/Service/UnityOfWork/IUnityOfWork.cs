using Service.AuthorServices;
using Service.BookServices;
using Service.GenryServices;
using Service.ReaderServices;

namespace Service.UnityOfwork
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
