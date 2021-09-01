using DAL.Entitys.Dto;
using DAL.Entitys.Model;
using DAL.Service.GynericRepositorys;

namespace DAL.Service.AuthorServices
{
    public interface IAuthorService: IRepository<AuthorModel, AuthorDto>
    {
    }

    public interface IAuthorServiceBase : IRepository<AuthorModel, AuthorBaseDto>
    {
    }
}
