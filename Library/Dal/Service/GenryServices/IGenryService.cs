using DAL.Entitys.Dto;
using DAL.Entitys.Model;
using DAL.Service.GynericRepositorys;
using System.Collections.Generic;

namespace DAL.Service.GenryServices
{
    public interface IGenryService: IRepository<GenryModel,GenryDto>
    {
        Dictionary<string,int> GetStatistic();
    }

    public interface IGenryServiceBase : IRepository<GenryModel, GenryBaseDto>
    {
    }
}
