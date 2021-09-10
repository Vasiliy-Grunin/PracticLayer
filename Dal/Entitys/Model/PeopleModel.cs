using DAL.Entitys.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.Entitys.Model
{
    public class PeopleModel : IRecord, IPeople
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string MidleName { get; set; }

        public DateTime Birthday { get; set; }

        public virtual List<BookModel> Books { get; set; } = new List<BookModel>();
    }
}
