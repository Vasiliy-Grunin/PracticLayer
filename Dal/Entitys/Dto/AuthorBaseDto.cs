using DAL.Entitys.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entitys.Dto
{
    public class AuthorBaseDto : IPeople, IDto
    {
        public int Id { get; private set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string Name { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string MidleName { get; set; }
    }
}
