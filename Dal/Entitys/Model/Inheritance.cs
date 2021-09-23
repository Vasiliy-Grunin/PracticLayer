using DAL.Entitys.Interfaces;
using System;

namespace DAL.Entitys.Model
{
    public class Inheritance : IInheritance
    {
        public DateTime DateTimeAdd { get; set; }

        public DateTime DateTimeChange { get; set; }

        public int? Version { get; set; }
    }
}
