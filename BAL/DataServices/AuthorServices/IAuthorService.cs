using DAL.Entitys.Dto;
using DAL.Entitys.Model;
using DataServices.GynericRepositorys;

namespace DataServices.AuthorServices
{
    public interface IAuthorService: IRepository<AuthorModel, AuthorDto>
    {
    }

    public interface IAuthorServiceBase : IRepository<AuthorModel, AuthorBaseDto>
    {
    }
}
