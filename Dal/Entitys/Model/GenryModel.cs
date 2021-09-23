using DAL.Entitys.Interfaces;
using System.Collections.Generic;

namespace DAL.Entitys.Model
{
    public class GenryModel : Inheritance, IRecord, IGenry<BookModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<BookModel> Books { get; set; }
    }
}
