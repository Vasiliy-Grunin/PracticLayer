using DAL.Data;
using DAL.Entitys.Model;
using DAL.Entitys.Dto;
using DAL.Service.GynericRepositorys;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;

namespace DAL.Service.BookServices
{
    public class BookService : GynericRepository<BookModel, BookDto>, IBookService
    {
        public BookService(LibraryDbContext context, IMapper mapper, IMemoryCache cache)
            : base(context, mapper, cache)
        {
        }

        public override bool Remove(BookDto entity)
        {
            if (GetEntity(entity).Master.Count > 0)
                return false;

            return base.Remove(entity);
        }

        public override bool Remove(int id)
        {
            if (GetEntity(id).Master.Any())
                return false;

            return base.Remove(id);
        }

        public override bool RemoveRange(IEnumerable<BookDto> entitys)
        {
            if (GetEntities(entitys)
                .Select(entity => entity.Master.Any())
                .Any())
                return false;

            return base.RemoveRange(entitys);
        }
    }
    public class BookServiceBase : GynericRepository<BookModel, BookBaseDto>, IBookServiceBase
    {
        public BookServiceBase(LibraryDbContext context, IMapper mapper, IMemoryCache cache)
            : base(context, mapper, cache)
        {
        }

        public override bool Remove(BookBaseDto entity)
        {
            if (GetEntity(entity).Master.Count > 0)
                return false;

            return base.Remove(entity);
        }

        public override bool Remove(int id)
        {
            if (GetEntity(id).Master.Any())
                return false;

            return base.Remove(id);
        }

        public override bool RemoveRange(IEnumerable<BookBaseDto> entitys)
        {
            if (GetEntities(entitys)
                .Select(entity => entity.Master.Any())
                .Any())
                return false;

            return base.RemoveRange(entitys);
        }
    }
}
