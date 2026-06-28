using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1Gnasso.Service.DTOs.Sport
{
    public class SportDeleteDto

    {
        public int SportId { get; set; }
        public byte[] RowVersion { get; set; } = null!;

    }
}
