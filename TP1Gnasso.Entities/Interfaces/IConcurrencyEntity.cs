using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1Gnasso.Entities.Interfaces
{
    public interface IConcurrencyEntity
    {
        public byte[] RowVersion { get; set; }
    }
}
