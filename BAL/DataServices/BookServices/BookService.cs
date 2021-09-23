using DAL.Data;
using DAL.Entitys.Model;
using DAL.Entitys.Dto;
using DataServices.GynericRepositorys;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using System.Data.Entity;

namespace DataServices.BookServices
{
    public class BookService : GynericRepository<BookModel, BookDto>, IBookService
    {
        public BookService(LibraryDbContext context, IMapper mapper, IMemoryCache cache)
            : base(context, mapper, cache)
        {
        }

        public override IEnumerable<BookDto> Get()
        {
            var result = mapper
               .Map<IEnumerable<BookModel>, IEnumerable<BookDto>>
               (context.Books.Include(entity => entity.Author)
               .AsEnumerable());
            return result;
        }

        public override bool Remove(BookDto dtos)
        {
            var master = context.Peoples
                .Where(x => x.Books.Contains(GetEntity(dtos)));
            if (master is not null)
                return false;

            return base.Remove(dtos);
        }

        public override bool Remove(int id)
        {
            if (id < 0 || id > context.Books.Count())
                return false;

            var entity = GetEntity(id);
            if (entity is null)
                return false;

            var master = context.Peoples
                .Where(x => x.Books.Contains(entity)).ToList();
            if (master.Any())
                return false;

            context.Set<BookModel>().Remove(entity);
            return true;
        }

        public override bool RemoveRange(IEnumerable<BookDto> dtos)
        {
            var entitys = GetEntities(dtos);
            foreach (var entity in entitys)
                if (context.Peoples
                .Where(x => x.Books.Contains(entity)) is not null)
                    return false;

            return base.RemoveRange(dtos);
        }
    }

    public class BookServiceBase : GynericRepository<BookModel, BookBaseDto>, IBookServiceBase
    {
        public BookServiceBase(LibraryDbContext context, IMapper mapper, IMemoryCache cache)
            : base(context, mapper, cache)
        {
        }

        public override bool Remove(BookBaseDto dtos)
        {
            var master = context.Peoples
                .Where(x => x.Books.Contains(GetEntity(dtos)));
            if (master is not null)
                return false;

            return base.Remove(dtos);
        }

        public override bool Remove(int id)
        {
            var master = context.Peoples
                .Where(x => x.Books.Contains(GetEntity(id)));
            if (master is not null)
                return false;

            return base.Remove(id);
        }

        public override bool RemoveRange(IEnumerable<BookBaseDto> dtos)
        {
            var entitys = GetEntities(dtos);
            foreach (var entity in entitys)
                if (context.Peoples
                .Where(x => x.Books
                .Contains(entity)) is not null)
                    return false;

            return base.RemoveRange(dtos);
        }
    }
}
