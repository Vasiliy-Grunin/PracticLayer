using AutoMapper;
using DAL.Data;
using DAL.Entitys.Dto;
using DAL.Entitys.Model;
using DAL.Service.GynericRepositorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Service.ReaderServices
{
    public class ReaderService : GynericRepository<PeopleModel,ReaderDto>, IReaderService
    {
        public ReaderService(LibraryDbContext context, IMapper mapper, IMemoryCache cache)
            : base(context, mapper, cache)
        { 
        }

        public IEnumerable<ReaderDto> GetLibraryCard()
        {
            return mapper.Map<IEnumerable<PeopleModel>, IEnumerable<ReaderDto>>(context.Set<PeopleModel>()
                .Include(entity => entity.Books)
                .AsEnumerable());
        }

        public override bool Remove(int id)
        {
            if (GetEntity(id).Books.Any())
                return false;

            return base.Remove(id);
        }

        public bool RemoveBook(ReaderDto entity)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveRangeBook(IEnumerable<ReaderDto> entitys)
        {
            throw new System.NotImplementedException();
        }

        public bool AddBook(ReaderDto entity)
        {
            throw new System.NotImplementedException();
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
