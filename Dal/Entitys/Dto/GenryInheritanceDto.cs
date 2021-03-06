using DAL.Entitys.Interfaces;
using System;

namespace DAL.Entitys.Dto
{
    public class GenryInheritanceDto : GenryDto, IInheritance
    {
        public DateTime DateTimeAdd { get; set; }
        public DateTime DateTimeChange { get; set; }
        public int? Version { get; set; }
    }
}
