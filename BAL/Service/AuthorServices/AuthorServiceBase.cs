using AutoMapper;
using DAL.Data;
using DAL.Entitys.Dto;
using DAL.Entitys.Model;
using Service.GynericRepositorys;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;

namespace Service.AuthorServices
{
    public class AuthorService : GynericRepository<AuthorModel, AuthorDto>, IAuthorService
    {
        public AuthorService(LibraryDbContext context, IMapper mapper, IMemoryCache cache)
            : base(context, mapper, cache)
        {
        }

        public override bool Remove(AuthorDto author)
        {
            if (GetEntity(author).Books.Any())
                return false;

            return base.Remove(author);
        }

        public override bool Remove(int id)
        {
            if (id < 0 
                || id > context.Set<AuthorModel>().Count() 
                ||  context.Authors.Find(id).Books.Any())
                return false;

            return base.Remove(id);
        }

        public override bool RemoveRange(IEnumerable<AuthorDto> entitys)
        {
            if (GetEntities(entitys)
                .Select(entity => entity.Books.Any())
                .Any())
                return false;

            return base.RemoveRange(entitys);
        }
    }


    public class AuthorServiceBase : GynericRepository<AuthorModel, AuthorBaseDto>, IAuthorServiceBase
    {
        public AuthorServiceBase(LibraryDbContext context, IMapper mapper, IMemoryCache cache)
            : base(context, mapper, cache)
        {
        }

        public override bool Remove(AuthorBaseDto author)
        {
            if (GetEntity(author).Books.Any())
                return false;

            return base.Remove(author);
        }

        public override bool Remove(int id)
        {
            if (GetEntity(id).Books.Any())
                return false;

            return base.Remove(id);
        }

        public override bool RemoveRange(IEnumerable<AuthorBaseDto> entitys)
        {
            if (GetEntities(entitys)
                .Select(entity => entity.Books.Any())
                .Any())
                return false;

            return base.RemoveRange(entitys);
        }
    }
}
