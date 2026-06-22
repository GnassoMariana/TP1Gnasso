using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1Gnasso.Service.DTOs.Genre
{
    public class GenreListDto
    {
        public int GenreId { get; set; }
        public string? Name { get; set; }
        public bool Active { get; set; }
    }
}
