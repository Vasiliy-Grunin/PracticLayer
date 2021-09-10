using DAL.Entitys.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entitys.Dto
{
    public class GenryBaseDto : IDto
    {
        public int Id { get; private set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }
    }
}
