using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Entities;

namespace TP1Gnasso.Data.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entidad);
        void Update(T Entidad, int id);
        void Delete(int id);
        //bool Exist(string model, int id);
        T GetById(int id);
        List<T> GetAll();
        IQueryable<T> Query();

    }
}
