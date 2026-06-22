using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Entities;
using TP1Gnasso.Service.DTOs.Genre;

namespace TP1Gnasso.Service.Mappers
{
    public class GenreMapper
    {
        public static GenreListDto ToGenreListDto(Genre genre)
        {
            return new GenreListDto
            {
                GenreId = genre.GenreId,
                Name = genre.GenreName,
                Active = genre.Active
            };
        }
    }
}
