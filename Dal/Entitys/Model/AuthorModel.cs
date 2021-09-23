using DAL.Entitys.Interfaces;
using System.Collections.Generic;

namespace DAL.Entitys.Model
{
    public class AuthorModel : Inheritance, IRecord, IPeople, IAuthor<BookModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string MidleName { get; set; }

        public virtual ICollection<BookModel> Books { get; set; }
    }
}
