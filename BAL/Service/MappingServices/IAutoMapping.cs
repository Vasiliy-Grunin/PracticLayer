using System;
using DAL.Entitys.Dto;
using DAL.Entitys.Model;
using DAL.Entitys.Model.Inheritance;
using AutoMapper;


namespace DAL.Service.MappingService
{
    public interface IAutoMapping
        : IMapper,
        //IMappingAction<GenryModel, GenryBaseDto>,
        //IMappingAction<GenryModel, GenryDto>,
        //IMappingAction<GenryModel,GenryInheritanceDto>,
        IMapperBase
    {
    }
}
