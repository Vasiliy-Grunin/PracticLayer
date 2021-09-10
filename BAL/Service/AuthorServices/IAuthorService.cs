using DAL.Entitys.Dto;
using DAL.Entitys.Model;
using Service.GynericRepositorys;

namespace Service.AuthorServices
{
    public interface IAuthorService: IRepository<AuthorModel, AuthorDto>
    {
    }

    public interface IAuthorServiceBase : IRepository<AuthorModel, AuthorBaseDto>
    {
    }
}
