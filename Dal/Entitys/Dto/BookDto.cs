using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using DAL.Entitys.Interfaces;

namespace DAL.Entitys.Dto
{
    /// <summary>
    /// Book Model
    /// </summary>
    
    [DataContract]
    public class BookDto : BookBaseDto, IEquatable<BookDto>, IDto, IBook<AuthorBaseDto,GenryBaseDto>
    {
        public AuthorBaseDto Author { get; set; }

        public ICollection<GenryBaseDto> Genre { get; set; }

        public bool Equals(BookDto other) => other.Title == Title
            && Author.Equals(other.Author)
            && Genre.Equals(other.Genre);

        public override bool Equals(object obj)
            => Equals(obj as BookDto);

        public override int GetHashCode()
        {
            return HashCode.Combine(Id,Title,Author,Genre);
        }

        public override string ToString()
            => string.Format("{0} {1} {2}", Title, Author.ToString(), Genre.ToString());
    }
}
