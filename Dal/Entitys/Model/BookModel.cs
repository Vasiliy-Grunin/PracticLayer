using DAL.Entitys.Interfaces;
using System.Collections.Generic;

namespace DAL.Entitys.Model
{
    public class BookModel : IRecord, IBook<AuthorModel, GenryModel>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual AuthorModel Author { get; set; } = new AuthorModel();

        public virtual List<GenryModel> Genre { get; set; } = new List<GenryModel>();

        public virtual PeopleModel Master { get; set; } = new PeopleModel();
    }
}
