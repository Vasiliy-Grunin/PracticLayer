using DAL.Entitys.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DAL.Entitys.Dto
{
    [DataContract]
    public class GenryDto : GenryBaseDto, IDto, IGenry<BookBaseDto>, IEquatable<GenryDto>
    {
        public ICollection<BookBaseDto> Books { get; set; }

        public bool Equals(GenryDto other)
        {
            return other.Books.Equals(Books)
                && other.Id.Equals(Id)
                && other.Name.Equals(Name);
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