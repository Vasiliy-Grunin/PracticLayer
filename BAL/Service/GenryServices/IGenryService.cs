using DAL.Entitys.Dto;
using DAL.Entitys.Model;
using Service.GynericRepositorys;
using System.Collections.Generic;

namespace Service.GenryServices
{
    public interface IGenryService: IRepository<GenryModel,GenryDto>
    {
        Dictionary<string,int> GetStatistic();
    }

    public interface IGenryServiceBase : IRepository<GenryModel, GenryBaseDto>
    {
    }

    public interface IGenryServiceInheritance : IRepository<GenryModel, GenryInheritanceDto>
    {
    }
}
