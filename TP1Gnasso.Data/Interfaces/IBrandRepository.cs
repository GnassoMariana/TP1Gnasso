using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Entities;

namespace TP1Gnasso.Data.Interfaces
{
    public interface IBrandRepository: IGenericRepository<Brand>

    {
        bool Exist(string Name, int? BrandId=null);
        bool HasShoes(int id);
    }
}
