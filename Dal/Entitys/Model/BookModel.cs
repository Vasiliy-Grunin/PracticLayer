using DAL.Entitys.Interfaces;
using System.Collections.Generic;

namespace DAL.Entitys.Model
{
    public class BookModel : Inheritance, IRecord, IBook<AuthorModel, GenryModel>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<GenryModel> Genre { get; set; }

        public virtual AuthorModel Author { get; set; }
    }
}
