using DAL.Entitys.Dto;
using DAL.Entitys.Model;
using DataServices.GynericRepositorys;
using System.Collections.Generic;

namespace DataServices.ReaderServices
{
    public interface IReaderService : IRepository<PeopleModel, ReaderDto>
    {
        public IEnumerable<ReaderDto> GetLibraryCard();
        public bool RemoveBook(ReaderBaseDto reader, BookBaseDto book);
        public bool AddBook(ReaderBaseDto reader, BookBaseDto dto);
    }
    public interface IReaderServiceBase : IRepository<PeopleModel, ReaderBaseDto>
    {
    }
}
