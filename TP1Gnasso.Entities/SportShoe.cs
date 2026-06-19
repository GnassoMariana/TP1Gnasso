using TP1Gnasso.Entities.Interfaces;

namespace TP1Gnasso.Entities
{
    public class SportShoe: IConcurrencyEntity
    {

        public int SportShoeId { get; set; } 
        public string? Model { get ; set ; }
        public decimal Price { get ; set ; }
        public DateTime ReleaseDate { get; set ; }
        public bool Active { get; set; }

        public int BrandId { get; set; }
        public Brand? Brand { get; set; }

        public int SizeId { get; set; }
        public Size? Size { get; set; }

        public int SportId { get; set; }
        public Sport? Sport { get; set; }

        public int GenreId { get; set; }
        public Genre? Genre { get; set; }

        public byte[] RowVersion { get; set; } = null!;

    }
}
