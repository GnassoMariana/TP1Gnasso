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
    public class SportShoeRepository : ConcurrencyRepository<SportShoe>, ISportShoeRepository
    {
        private readonly SportShoesDbContext _context;

        public SportShoeRepository(SportShoesDbContext context): base(context)
        {
            _context = context;
        }
        //public void Add(SportShoe sportShoe)
        //{
        //    _context.SportShoes.Add(sportShoe);
        //}

        //public void Delete(int id)
        //{
        //    var sportShoe = _context.SportShoes.Find(id);
        //    if (sportShoe == null) return;
        //    _context.SportShoes.Remove(sportShoe);

        //}

        public bool Exist(string model,int sizeId, int id)
        {
            return _context.SportShoes.Any(s => 
                s.Model == model &&
                s.SizeId == sizeId &&
                s.SportShoeId != id);
            ///Ver que devuelve. Porque el modelo e id pueden ser iguales pero distinto numero????
        }

        public bool HasDependencies(SportShoe sportShoe)
        {
            return false;
        }

        //public override void Add(SportShoe sportShoe)
        //{
        //    try
        //    {
        //        bool exists = _context.SportShoes.Any(s =>
        //            s.Model == sportShoe.Model &&
        //            s.SizeId == sportShoe.SizeId);

        //        if (exists)
        //        {
        //            throw new Exception(
        //                $"A sport shoe with model '{sportShoe.Model}' and size '{sportShoe.SizeId}' already exists.");
        //        }

        //        _context.SportShoes.Add(sportShoe);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(
        //            $"An error occurred while adding the record to the table {nameof(SportShoe)}",
        //            ex);
        //    }
        //}

        public override List<SportShoe> GetAll()
        {
            return _context.SportShoes
                .Include(s => s.Brand)
                .Include(s => s.Size)
                .Include(s => s.Sport)
                .Include(s=> s.Genre)
                .AsNoTracking().ToList();

        }

        public override SportShoe GetById(int id)
        {
            return _context.SportShoes
                .Include(s => s.Brand)
                .Include(s => s.Size)
                .Include(s => s.Sport)
                .Include(s => s.Genre)
                .AsNoTracking()
                .FirstOrDefault(s => s.SportShoeId == id)!;
        }

        public override IQueryable<SportShoe> Query()
        {
            return _context.SportShoes
                .Include(s => s.Brand)
                .Include(s => s.Size)
                .Include(s => s.Sport)
                .Include(s => s.Genre)
                .AsNoTracking();
        }

        public void Update(SportShoe sportShoe)
        {
            _context.SportShoes.Update(sportShoe);
        }
    }
}
