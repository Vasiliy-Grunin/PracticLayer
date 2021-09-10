using DAL.Entitys.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entitys.Dto
{
    public class AuthorBaseDto : IPeople, IDto
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
    }
}
