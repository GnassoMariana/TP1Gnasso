using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Entities;

namespace TP1Gnasso.Data.Interfaces
{
    public interface ISportShoeRepository: IConcurrencyRepository<SportShoe>
    {
        bool Exist(string model, int sizeId, int id);
        bool HasDependencies(SportShoe sportShoe);

    }
}
