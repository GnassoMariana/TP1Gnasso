using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1Gnasso.Service.DTOs.Size
{
    public class SizeDeleteDto
    {
        public int SizeId { get; set; }
        public byte[] RowVersion { get; set; } = null!;

    }
}
