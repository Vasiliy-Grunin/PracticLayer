using DAL.Entitys.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entitys.Dto
{
    public class BookBaseDto : IDto, IBook
    {
        public int Id { get; private set; }

        [Required]
        [StringLength(50, ErrorMessage = "the name is too long", MinimumLength = 1)]
        public string Title { get; set; }
    }
}
