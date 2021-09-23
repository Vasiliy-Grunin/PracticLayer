using DAL.Entitys.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DAL.Entitys.Dto
{
    [DataContract]
    public class ReaderDto : ReaderBaseDto,  IEquatable<ReaderDto>, IPerson
    {
        public ICollection<BookBaseDto> Books { get; set; }

        public bool Equals(ReaderDto other) => Name == other.Name
                && LastName == other.LastName
                && MidleName == other.MidleName;

        public override bool Equals(object obj)
            => Equals(obj as ReaderDto);

        public override string ToString()
        {
            return $"{LastName} {Name} {MidleName} {Birthday}";
        }

        public override int GetHashCode()
            => HashCode.Combine(Id,Name,LastName,MidleName,Birthday);
    }
}
