using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Data.Interfaces;
using TP1Gnasso.Entities;

namespace TP1Gnasso.Data.Repositories
{

    public class SizeRepository : GenericRepository<Size> ,ISizeRepository
    {
        private readonly SportShoesDbContext _context;
        public SizeRepository(SportShoesDbContext context): base(context)
        {
            _context = context;
        }
        //public void Add(Size size)
        //{
        //    _context.Sizes.Add(size);
        //}

        //public void Delete(int id)
        //{
        //    var size = _context.Sizes.Find(id);
        //    if (size == null) return;
        //    _context.Sizes.Remove(size);
        //}

        public bool Exists(decimal number, int id)
        {
            return _context.Sizes.Any(s =>
            s.Number == number &&
            s.SizeId != id);
        }

        //public List<Size> GetAll()
        //{
        //    return _context.Sizes.AsNoTracking().ToList();
        //}

        //public Size? GetById(int id)
        //{
        //    return _context.Sizes.Find(id);
        //}

        public bool HasSizes(int id)
        {
            return false;
            //return _context.Sizes.Any( s=> s.SizeId == id);
        }

    //    public IQueryable<Size> Query()
    //    {
    //        return _context.Sizes.AsNoTracking().AsQueryable();
    //    }

    //    public void Update(Size size)
    //    {
    //        _context.Sizes.Update(size);
    //    }
    }
}
