using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Data.Interfaces;
using TP1Gnasso.Entities.Interfaces;

namespace TP1Gnasso.Data.Repositories
{
    public class ConcurrencyRepository<T> : GenericRepository<T>, IConcurrencyRepository<T> where T : class, IConcurrencyEntity
    {
        public ConcurrencyRepository(SportShoesDbContext context) : base(context)
        {
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException("Use the concurrency version");
        }

        public void Delete(int id, byte[] rowVersion)
        {
            var entidadEnDb = _dbSet.Find(id);
            if (entidadEnDb is null)
            {
                throw new KeyNotFoundException("Unable to delete the record. Id is null");
            }

            var entidad = _dbContext.Entry(entidadEnDb);
            entidad.OriginalValues["RowVersion"] = rowVersion;
            _dbSet.Remove(entidadEnDb);

        }

        public void Update(T entity, int id, byte[] rowVersion)
        {
            var entidadEnDb = _dbSet.Find(id);

            if (entidadEnDb is null)
            {
                throw new KeyNotFoundException("Record not found");
            }
            var entry = _dbContext.Entry(entidadEnDb);
            entry.OriginalValues["RowVersion"] = rowVersion;
             
            entry.CurrentValues.SetValues(entity);

        }
    }
}
