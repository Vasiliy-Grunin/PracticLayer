using AutoMapper;
using DAL.Data;
using DAL.Entitys.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Service.GynericRepositorys
{
    /// <summary>
    /// returnd Dto
    /// </summary>
    /// <typeparam name="TEntity">Class entity</typeparam>
    /// <typeparam name="TDto">Class Dto</typeparam>
    public class GynericRepository<TEntity,TDto>
        : IRepository<TEntity,TDto>
        where TEntity : class, IRecord
        where TDto : class, IDto
    {
        protected readonly LibraryDbContext context;

        protected readonly IMapper mapper;

        protected readonly IMemoryCache memory;


        public GynericRepository(LibraryDbContext context, IMapper mapper, IMemoryCache cache)
        {
            this.context = context;
            this.mapper = mapper;
            memory = cache;
        }

        public virtual bool Add(TDto entity)
        {
            if (entity is null)
                return false;

            context.Set<TEntity>().Add(GetEntity(entity));
            memory.Set(GetEntity(entity).Id, entity, new MemoryCacheEntryOptions() 
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1.0)
            });
            return true;
        }

        public virtual bool AddRange(IEnumerable<TDto> entitys)
        {
            if (entitys.Any(x =>x is null))
                return false;

            context.Set<TEntity>().AddRange(GetEntities(entitys));
            return true;
        }

        public virtual IEnumerable<TDto> Get()
            =>  mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>
            (context.Set<TEntity>());

        public virtual IEnumerable<TDto> Get(string query)
        {
            return mapper
                .Map<IEnumerable<TEntity>, IEnumerable<TDto>>(context.Set<TEntity>()
                .AsEnumerable().Where(entity => entity.ToString().Contains(query)));
        }

        public virtual IEnumerable<TDto> Get(params string[] querys)
            => querys.SelectMany(query => Get(query)).AsEnumerable();

        public virtual bool Remove(int id)
        {
            if (id > 0 && context.Set<TEntity>().Count() > id)
            { 
                context.Set<TEntity>().Remove(GetEntity(id));
                return true;
            }

            return false;
        }

        public virtual bool Remove(TDto entity)
        {
            var dbEntity = GetEntity(entity);
            if (entity is null || !Contains(dbEntity))
                return false;

            context.Set<TEntity>().Remove(dbEntity);
            return true;
        }

        public virtual bool RemoveRange(IEnumerable<TDto> entitys)
        {
            var dbEntitys = GetEntities(entitys);
            if (dbEntitys.Any(x => x is null)
                || dbEntitys.Any(entity => !Contains(entity)))
                return false;

            context.Set<TEntity>().RemoveRange(dbEntitys);
            return true;
        }

        public virtual bool Update(TDto entity)
        {
            var dbEntity = GetEntity(entity);
            if (entity is null || !Contains(dbEntity))
                return false;

            context.Set<TEntity>().Update(dbEntity);
            return true;
        }

        protected bool Contains(TEntity entity)
            => context.Set<TEntity>().Contains(entity);

        protected TEntity GetEntity(TDto dto)
        {
            TEntity entity = (TEntity)
                Activator.CreateInstance(typeof(TEntity));
            mapper.Map(dto, entity);
            return context.Set<TEntity>().Find(entity.Id) ?? entity;

        }

        protected IEnumerable<TEntity> GetEntities(IEnumerable<TDto> dtos)
            => dtos.Select(dto => GetEntity(dto));

        protected TEntity GetEntity(int id)
            => context.Set<TEntity>().Find(id);
    }
}
