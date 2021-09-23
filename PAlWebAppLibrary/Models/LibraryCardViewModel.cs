using DAL.Entitys.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAlWebAppLibrary.Models
{
    public class LibraryCardViewModel
    {
        public ReaderBaseDto Reader { get; set; }
        public BookBaseDto Book { get; set; }
    }
}
