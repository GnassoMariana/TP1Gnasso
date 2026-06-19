using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Entities.Interfaces;

namespace TP1Gnasso.Data.Interfaces
{
    public interface IConcurrencyRepository<T> : IGenericRepository<T> where T : class, IConcurrencyEntity
    {
        void Delete(int id, byte[] rowVersion);

        void Update(T entity, int id, byte[] rowVersion);
    }
}
