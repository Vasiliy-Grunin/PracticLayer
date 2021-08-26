using System;
using DAL.Entitys.Interfaces;

namespace DAL.Entitys.Model.Inheritance
{
    public class PeopleInheritance : PeopleModel, IInheritance
    {
        public DateTime DateTimeAdd { get; set; }
        public DateTime DateTimeChange { get; set; }
        public int Version { get; set; }
    }
}
