using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1Gnasso.Service.DTOs.SportShoe
{
    public class SportShoeDeleteDto
    {
        public int SportShoeId { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
