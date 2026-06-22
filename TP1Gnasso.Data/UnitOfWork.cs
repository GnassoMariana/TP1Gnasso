using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Data.Interfaces;

namespace TP1Gnasso.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SportShoesDbContext _context;
        public UnitOfWork(SportShoesDbContext context, ISportRepository sports,
            ISportShoeRepository sportShoe, IBrandRepository brands, ISizeRepository sizes, IGenreRepository genres)
        {
            _context = context;
            Sports = sports;
            SportShoes = sportShoe;
            Sizes = sizes;
            Brands = brands;
            Genres = genres;
        }
        public ISportShoeRepository SportShoes { get; }

        public ISportRepository Sports { get; }

        public ISizeRepository Sizes { get; }

        public IBrandRepository Brands { get; }

        public IGenreRepository Genres { get; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void RollBack()
        {
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }   
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
