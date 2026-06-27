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
    public class BrandRepository : ConcurrencyRepository<Brand>, IBrandRepository
    {
        private readonly SportShoesDbContext _dbContext;

        public BrandRepository(SportShoesDbContext dbcontext): base(dbcontext)
        {
            _dbContext = dbcontext;
        }
        //public void Add(Brand brand)
        //{
        //    _dbContext.Brands.Add(brand);
        //}

        //public void Delete(int id)
        //{
        //    var brand = _dbContext.Brands.Find(id);
        //    if (brand == null) return;
        //    _dbContext.Brands.Remove(brand);
        //}

        public bool Exist(string name, int? brandId = null)
        {
            return _dbContext.Brands.Any(
                b => b.Name == name && b.BrandId == brandId);
        }

        //public List<Brand> GetAll()
        //{
        //    return _dbContext.Brands.AsNoTracking().ToList();
        //}

        //public Brand GetById(int Id)
        //{
        //    return _dbContext.Brands.Find(Id)!;
        //}

        public bool HasShoes(int id)
        {
            return false;
            //return _dbContext.SportShoes.Any(b => b.BrandId == id);
        }

        //public void Update(Brand brand)
        //{
        //    _dbContext.Brands.Update(brand);
        //}

        //public IQueryable<Brand> Query()
        //{
        //    return _dbContext.Brands.AsNoTracking()
        //        .AsQueryable();
        //}
        public override List<Brand> GetAll()
        {
            return _dbContext.Brands
                .AsNoTracking().ToList();

        }


        public override Brand GetById(int id)
        {
            return _dbContext.Brands
                .FirstOrDefault(b => b.BrandId == id)!;
        }

        public override IQueryable<Brand> Query()
        {
            return _dbContext.Brands
                .AsNoTracking();
        }

        public void Update(Brand brand)
        {
            _dbContext.Brands.Update(brand);
        }

    }
}
