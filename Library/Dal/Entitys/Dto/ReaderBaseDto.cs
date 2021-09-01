using DAL.Entitys.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entitys.Dto
{
    public class ReaderBaseDto : IPeople, IDto
    {
        public int Id { get; private set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string MidleName { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "dd.mm.yyyy")]
        public DateTime Birthday { get; set; }
    }
}
