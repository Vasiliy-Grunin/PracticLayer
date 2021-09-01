using System.Collections.Generic;

namespace DAL.Service.GynericRepositorys
{
    /// <summary>
    /// Default operation for dbset
    /// </summary>
    /// <typeparam name="EEntity">Entity on Db</typeparam>
    /// <typeparam name="TDto">returned Dto</typeparam>
    public interface IRepository<EEntity, TDto> 
        where TDto : class
        where EEntity : class
    {
        abstract bool Add(TDto entity);
        abstract bool AddRange(IEnumerable<TDto> entitys);
        abstract bool Remove(TDto entity);
        abstract bool Remove(int id);
        abstract bool RemoveRange(IEnumerable<TDto> entitys);
        abstract IEnumerable<TDto> Get();
        abstract IEnumerable<TDto> Get(string query);
        abstract IEnumerable<TDto> Get(params string[] query);
        abstract bool Update(TDto entity);
    }
}
