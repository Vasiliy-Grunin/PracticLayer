using DAL.Entitys.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DAL.Entitys.Dto
{
    [DataContract]
    public class GenryDto : GenryBaseDto, IDto, IGenry<BookBaseDto>, IEquatable<GenryDto>
    {
        public List<BookBaseDto> Books { get; set; }

        public bool Equals(GenryDto other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as GenryDto);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id,Name, Books);
        }
    }
}