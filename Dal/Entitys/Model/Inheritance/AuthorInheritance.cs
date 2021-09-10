using DAL.Entitys.Interfaces;
using System;

namespace DAL.Entitys.Model.Inheritance
{
    public class AuthorInheritance : AuthorModel, IInheritance
    {
        public DateTime DateTimeAdd { get; set; }
        public DateTime DateTimeChange { get; set; }
        public int Version { get; set; }
    }
}
