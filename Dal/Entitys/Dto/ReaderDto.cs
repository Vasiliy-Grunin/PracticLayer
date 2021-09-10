using DAL.Entitys.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DAL.Entitys.Dto
{
    [DataContract]
    public class ReaderDto : ReaderBaseDto,  IEquatable<ReaderDto>, IPerson
    {
        public List<BookBaseDto> Books { get; set; }

        public bool Equals(ReaderDto other) => Name == other.Name
                && LastName == other.LastName
                && MidleName == other.MidleName;

        public override bool Equals(object obj)
            => Equals(obj as ReaderDto);

        public override string ToString()
        {
            return string.Format("{{0}} {{1}} {{2}} {{4}}", LastName, Name, MidleName, Birthday);
        }

        public override int GetHashCode()
            => HashCode.Combine(Id,Name,LastName,MidleName,Birthday);
    }
}
