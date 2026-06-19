using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Entities.Interfaces;

namespace TP1Gnasso.Entities
{
    public class Brand: IConcurrencyEntity
    {
        public int BrandId { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public bool Active { get; set; }
        public byte[] RowVersion { get; set; } = null!;

    }
}
