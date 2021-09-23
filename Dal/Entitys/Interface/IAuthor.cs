using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entitys.Interfaces
{
    interface IAuthor<T> : IPeople where T : IBook
    {
        ICollection<T> Books { get; set; }
    }
}
