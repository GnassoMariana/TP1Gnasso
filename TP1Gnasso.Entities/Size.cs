using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Entities.Interfaces;

namespace TP1Gnasso.Entities
{
    public class Size: IConcurrencyEntity
    {
        public int SizeId { get; set; }
        public decimal Number { get; set; }
        public bool Active { get; set; }
        public byte[] RowVersion { get; set; } = null!;

    }
}
