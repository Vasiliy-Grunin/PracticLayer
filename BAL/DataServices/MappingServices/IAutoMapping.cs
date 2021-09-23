using System;
using DAL.Entitys.Dto;
using DAL.Entitys.Model;
using AutoMapper;


namespace DAL.Service.MappingService
{
    public interface IAutoMapping
        : IMapper,
        IMapperBase
    {
    }
}
