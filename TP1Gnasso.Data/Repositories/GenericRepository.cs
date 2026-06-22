using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Data.Interfaces;

namespace TP1Gnasso.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly SportShoesDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(SportShoesDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
        }
        public  void Add(T entidad)
        {
            ////try
            ////{
            ////    _dbSet.Add(entidad);

            ////}
            ////catch (Exception ex)
            ////{

            ////    throw new Exception($"An error ocurred while adding the record to the table {typeof(T).Name}", ex);
            ////}

            _dbSet.Add(entidad);
        }
        public virtual void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity is null)
            {
                throw new KeyNotFoundException("Unable to delete the record");
            }
            _dbSet.Remove(entity);
        }


        public virtual void Delete(int id, byte[] rowVersion)
        {
            //try
            //{
                var entidad = _dbSet.Find(id);
                if(entidad is null)
                {
                    throw new KeyNotFoundException("Unable to delete the record. Id is null");
                }
                _dbSet.Remove(entidad);
            //}
            //catch (Exception ex)
            //{

            //    throw new Exception("An error ocurred while deleting the record", ex);
            //}
        }

        public virtual List<T> GetAll()
        {
            //try
            //{
                return _dbSet
                    .AsNoTracking()
                    .ToList();
            //}
            //catch (Exception ex)
            //{

            //    throw new Exception("An error ocurred while retrieving the records", ex);
            //}
        }

        public virtual T GetById(int id)
        {
            //try
            //{
                return _dbSet.Find(id)!;
            //}
            //catch (Exception ex)
            //{

            //    throw new Exception("An error ocurred while trying ti find the record", ex);
            //}
        }

        public virtual IQueryable<T> Query()
        {
            return _dbSet.AsNoTracking();
                //.AsQueryable();
        }

        public void Update(T Entidad, int id)
        {
            //try
            //{
                var entidadEnDb = _dbSet.Find(id);
                if (entidadEnDb is null)
                {
                    throw new KeyNotFoundException("Unable to update the record. Id is null");
                }
                _dbSet.Entry(entidadEnDb).CurrentValues.SetValues(Entidad);
            //}
            //catch (Exception ex)
            //{

            //    throw new Exception("An error ocurred while updating the record", ex);
            //}
        }
    }
}
