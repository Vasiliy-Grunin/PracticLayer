using AutoMapper;
using DAL.Data;
using DAL.Service.AuthorServices;
using DAL.Service.BookServices;
using DAL.Service.GenryServices;
using DAL.Service.ReaderServices;
using Microsoft.Extensions.Caching.Memory;

namespace DAL.Service.UnityOfwork
{
    public class UnitOfWork : IUnityOfWork
    {
        private readonly LibraryDbContext context;
        private readonly IMapper mapper;
        private readonly IMemoryCache cache;

        public UnitOfWork(LibraryDbContext context, IMapper mapper, IMemoryCache cache)
        {
            this.context = context;
            this.mapper = mapper;
            this.cache = cache;
            Readers = new ReaderService (this.context,this.mapper,this.cache);
            Genrys = new GenryService (this.context, this.mapper, this.cache);
            Authors = new AuthorService(this.context, this.mapper, this.cache);
            Books = new BookService (this.context, this.mapper, this.cache);
            BaseAuthors = new AuthorServiceBase(this.context, this.mapper, this.cache);
            BaseBooks = new BookServiceBase(this.context, this.mapper, this.cache);
            BaseGenrys = new GenryServiceBase(this.context, this.mapper, this.cache);
            BaseReaders = new ReaderServiceBase(this.context, this.mapper, this.cache);
        }

        public IReaderService Readers { get; private set; }

        public IGenryService Genrys { get; private set; }

        public IAuthorService Authors { get; private set; }

        public IBookService Books { get; private set; }

        public IReaderServiceBase BaseReaders { get; private set; }

        public IGenryServiceBase BaseGenrys { get; private set; }

        public IAuthorServiceBase BaseAuthors { get; private set; }

        public IBookServiceBase BaseBooks { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }
    }
}
