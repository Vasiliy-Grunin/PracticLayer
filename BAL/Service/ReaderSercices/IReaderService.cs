﻿using DAL.Entitys.Dto;
using DAL.Entitys.Model;
using Service.GynericRepositorys;
using System.Collections.Generic;

namespace Service.ReaderServices
{
    public interface IReaderService : IRepository<PeopleModel, ReaderDto>
    {
        public IEnumerable<ReaderDto> GetLibraryCard();
        public bool RemoveBook(ReaderDto entity);
        public bool RemoveRangeBook(IEnumerable<ReaderDto> entitys);
        public bool AddBook(ReaderDto entity);
    }
    public interface IReaderServiceBase : IRepository<PeopleModel, ReaderBaseDto>
    {
    }
}