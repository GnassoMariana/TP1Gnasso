using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1Gnasso.Service.DTOs.Sport
{
    public class SportListDto
    {
        public int SportId { get; set; }
        public string? Name { get; set; }
        public bool Active { get; set; }
    }
}
