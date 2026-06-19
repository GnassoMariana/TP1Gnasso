using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Data.Interfaces;

namespace TP1Gnasso.Data
{
    public  interface IUnitOfWork: IDisposable
    {
        ISportShoeRepository SportShoes { get; }
        ISportRepository Sports { get; }
        ISizeRepository Sizes { get; }
        IBrandRepository Brands { get; }
        void Save();

        void RollBack();
    }
}
