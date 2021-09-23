using System.Collections.Generic;

namespace DAL.Entitys.Interfaces
{
    interface IGenry<TBook> : IGenry
        where TBook : class
    {
        public ICollection<TBook> Books { get; set; }
    }

    interface IGenry
    {
        public string Name { get; set; }
    }
}
