using DAL.Entitys.Interfaces;
using System;

namespace DAL.Entitys.Dto
{
    class ReaderInheritanceDto : ReaderDto, IInheritance
    {
        public DateTime DateTimeAdd { get; set; }
        public DateTime DateTimeChange { get; set; }
        public int Version { get; set; }
    }
}
