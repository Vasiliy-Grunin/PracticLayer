using DAL.Entitys.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entitys.Model
{
    public class AuthorModel : IRecord, IPeople, IAuthor<BookModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string MidleName { get; set; }

        public virtual List<BookModel> Books { get; set; } = new List<BookModel>();
    }
}
