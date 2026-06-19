using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Entities;

namespace TP1Gnasso.Data.Interfaces
{
    public interface ISizeRepository: IGenericRepository<Size>
    {

        IQueryable<Size> Query();
        bool Exists(decimal number, int id);
        bool HasSizes(int id);
    }
}
