using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1Gnasso.Service.DTOs.SportShoe
{
    public class SportShoeDetailsDto
    {
        public int SportShoeId { get; set; }

        public string? Model { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Active { get; set; }

        public int BrandId { get; set; }
        public string? Brand { get; set; }

        public int SizeId { get; set; }
        public decimal Size { get; set; }

        public int SportId { get; set; }
        public string? Sport { get; set; }
    }
}
