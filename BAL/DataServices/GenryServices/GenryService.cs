using AutoMapper;
using DAL.Data;
using DAL.Entitys.Dto;
using DAL.Entitys.Model;
using DataServices.GynericRepositorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;

namespace DataServices.GenryServices
{
    public class GenryService : GynericRepository<GenryModel,GenryDto>, IGenryService
    {
        public GenryService(LibraryDbContext context, IMapper mapper, IMemoryCache cache)
            : base(context, mapper, cache)
        {
        }

        public override IEnumerable<GenryDto> Get()
        {
            var result = mapper
               .Map<IEnumerable<GenryModel>, IEnumerable<GenryDto>>
               (context.Genries.Include(entity => entity.Books)
               .AsEnumerable());
            return result;
        }

        public Dictionary<string, int> GetStatistic()
            => context.Genries
            .Include(entity => entity.Books)
            .ToDictionary(genry => genry.Name, genry => genry.Books.Count);
    }

    public class GenryServiceBase : GynericRepository<GenryModel, GenryBaseDto>, IGenryServiceBase
    {
        public GenryServiceBase(LibraryDbContext context, IMapper mapper, IMemoryCache cache)
            : base(context, mapper, cache)
        {
        }
    }
}
