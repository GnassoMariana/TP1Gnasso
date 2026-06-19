using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Entities;

namespace TP1Gnasso.Data.Interfaces
{
    public interface ISportRepository: IGenericRepository<Sport>
    {
        bool Exists(int id);
        bool HasShoes(int id);
    }
}
