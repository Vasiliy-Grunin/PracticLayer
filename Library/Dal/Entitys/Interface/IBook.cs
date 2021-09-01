using System.Collections.Generic;

namespace DAL.Entitys.Interfaces
{
    /// <summary>
    /// Required fields for BookModel
    /// </summary>
    /// <typeparam name="TAuthor">The reprisentor a AuthorModel</typeparam>
    /// <typeparam name="EGenry">The reprisentor a GenryModel</typeparam>
    interface IBook<TAuthor, EGenry> : IBook
        where TAuthor : IPeople
        where EGenry : class
    {
        TAuthor Author { get; set; }
        List<EGenry> Genre { get; set; }
    }

    interface IBook
    {
        string Title { get; set; }
    }
}
