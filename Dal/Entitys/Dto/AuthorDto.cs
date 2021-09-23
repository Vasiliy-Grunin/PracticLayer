using DAL.Entitys.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DAL.Entitys.Dto
{
    [DataContract]
    public class AuthorDto : AuthorBaseDto, IPeople, IDto, IAuthor<BookBaseDto>, IEquatable<AuthorDto>
    {
        public ICollection<BookBaseDto> Books { get; set; }

        public bool Equals(AuthorDto other)
        {
            return Name.Equals(other.Name)
                && LastName.Equals(other.LastName)
                && MidleName.Equals(other.MidleName);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, LastName, MidleName);
        }

        public override string ToString()
            => string.Format("{0} {1} {2}", Name, LastName, MidleName);

        public override bool Equals(object obj)
        {
            return Equals(obj as AuthorDto);
        }
    }
}
