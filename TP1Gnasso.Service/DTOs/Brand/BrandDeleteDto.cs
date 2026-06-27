using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1Gnasso.Service.DTOs.Brand
{
    public class BrandDeleteDto
    {
        public int BrandId { get; set; }
        public byte[] RowVersion { get; set; } = null!;

    }
}
