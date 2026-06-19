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
    public class SportRepository : GenericRepository<Sport>, ISportRepository
    {
        private readonly SportShoesDbContext _context;
        public SportRepository(SportShoesDbContext context): base(context)
        {
            _context = context;
        }
        //public void Add(Sport sport)
        //{
        //    _context.Sports.Add(sport);
        //}

        //public void Delete(int id)
        //{
        //    var sport = _context.Sports.Find(id);
        //    if (sport == null) return;
        //    _context.Sports.Remove(sport);


        //}

        public bool Exists(int id)
        {
            ///Mirar bien!!!!
            return _context.Sports.Any(s => s.SportId == id);
        }

        //public List<Sport> GetAll()
        //{
        //    return _context.Sports.AsNoTracking().ToList();
        //}

        //public Sport GetById(int id)
        //{
        //    return _context.Sports.Find(id)!;
        //}

        public bool HasShoes(int id)
        {
            return false;
           // return _context.SportShoes.Any(s => s.SportId == id);
        }

        //public void Update(Sport sport)
        //{
        //    _context.Sports.Update(sport);
        //}

        //public IQueryable<Sport> Query()
        //{
        //    return _context.Sports.AsNoTracking().AsQueryable();
        //}

        //object ISportRepository.GetById(int id)
        //{
        //    return GetById(id);
        //}
    }
}
