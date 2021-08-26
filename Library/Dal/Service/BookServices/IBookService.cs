﻿using DAL.Entitys.Dto;
using DAL.Entitys.Model;
using DAL.Service.GynericRepositorys;

namespace DAL.Service.BookServices
{
    public interface IBookService : IRepository<BookModel, BookDto>
    {
    }
    public interface IBookServiceBase : IRepository<BookModel, BookBaseDto>
    {
    }
}