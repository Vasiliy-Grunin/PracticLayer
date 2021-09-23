using AutoMapper;
using DAL.Data;
using DAL.Entitys.Dto;
using DAL.Entitys.Model;
using DataServices.GynericRepositorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DataServices.ReaderServices
{
    public class ReaderService : GynericRepository<PeopleModel,ReaderDto>, IReaderService
    {
        public ReaderService(LibraryDbContext context, IMapper mapper, IMemoryCache cache)
            : base(context, mapper, cache)
        { 
        }

        public bool AddBook(ReaderBaseDto reader, BookBaseDto dto)
        {
            var entityPeople = GetEntity(reader.Id);
            var entityBook = context.Books
                .Where(b => b.Id == dto.Id);
            if (entityPeople is null || entityBook is null)
                return false;

            entityPeople.Books.Add(entityBook.First());
            return context.SaveChanges() == 0;
        }

        public IEnumerable<ReaderDto> GetLibraryCard()
        {
            return mapper.Map<IEnumerable<PeopleModel>, IEnumerable<ReaderDto>>
                (context.Set<PeopleModel>()
                .Include(entity => entity.Books)
                .AsEnumerable());
        }

        public override bool Remove(int id)
        {
            if (id < 0 || context.Set<PeopleModel>().Count() < id)
                return false;

            var entity = GetEntity(id);
            if (entity.Books.Any())
                return false;

            context.Set<PeopleModel>().Remove(entity);
            return true;
        }

        public bool RemoveBook(ReaderBaseDto reader, BookBaseDto book)
        {
            var entityPeople = GetEntity(reader.Id);
            var entityBook = context.Books
                .Where(b => b.Id == book.Id).FirstOrDefault();
            if (entityPeople is null || entityBook is null)
                return false;

            entityPeople.Books.Remove(entityBook);
            return context.SaveChanges() == 0;
        }
    }

    public class ReaderServiceBase : GynericRepository<PeopleModel, ReaderBaseDto>, IReaderServiceBase
    {
        public ReaderServiceBase(LibraryDbContext context, IMapper mapper, IMemoryCache cache)
            : base(context, mapper, cache)
        {
        }
    }
}
