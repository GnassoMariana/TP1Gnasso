using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Entities;
using TP1Gnasso.Service.DTOs.SportShoe;

namespace TP1Gnasso.Service.Mappers
{
    public static class SportShoeMapper
    {
        public static SportShoe ToEntity(SportShoeCreateDto sportShoedto)
        {
            return new SportShoe
            {
                Model = sportShoedto.Model,
                Price = sportShoedto.Price,
                ReleaseDate = sportShoedto.ReleaseDate,
                Active = sportShoedto.Active,
                BrandId = sportShoedto.BrandId,
                SizeId = sportShoedto.SizeId,
                SportId = sportShoedto.SportId,
                GenreId = sportShoedto.GenreId
            };

        }

        public static SportShoeDetailsDto ToSportShoeDetailsDto(SportShoe sportShoe)
        {
            return new SportShoeDetailsDto
            {
                SportShoeId = sportShoe.SportShoeId,
                Model = sportShoe.Model,
                Price = sportShoe.Price,
                ReleaseDate = sportShoe.ReleaseDate,
                Active = sportShoe.Active,
                BrandId = sportShoe.BrandId,
                Brand = sportShoe.Brand?.Name!,
                SizeId = sportShoe.SizeId,
                Size = sportShoe.Size?.Number ?? 0m,
                SportId = sportShoe.SportId,
                Sport = sportShoe.Sport?.Name!
            };
        }

        public static SportShoeEditDto ToSportShoeEditDto(SportShoe sportshoe)
        {
            return new SportShoeEditDto
            {
                SportShoeId = sportshoe.SportShoeId,
                Model = sportshoe.Model,
                Price = sportshoe.Price,
                ReleaseDate = sportshoe.ReleaseDate,
                Active = sportshoe.Active,
                BrandId = sportshoe.BrandId,
                //Brand = sportshoe.Brand.Name,
                SizeId = sportshoe.SizeId,
                //Size = sportshoe.Size.Number,
                SportId = sportshoe.SportId,
                //Sport = sportshoe.Sport.Name


            };
        }

        public static SportShoe ToEntity(SportShoeEditDto sportShoeEditDto)
        {
            return new SportShoe
            {
                SportShoeId = sportShoeEditDto.SportShoeId,
                Model = sportShoeEditDto.Model,
                Price = sportShoeEditDto.Price,
                ReleaseDate = sportShoeEditDto.ReleaseDate,
                Active = sportShoeEditDto.Active,
                BrandId = sportShoeEditDto.BrandId,
                SizeId = sportShoeEditDto.SizeId,
                SportId = sportShoeEditDto.SportId
            };
        }

        public static SportShoeListDto ToSportShoeListDto(SportShoe sportShoe)
        {
            return new SportShoeListDto
            {
                SportShoeId = sportShoe.SportShoeId,
                Model = sportShoe.Model,
                Price = sportShoe.Price,
                Active = sportShoe.Active,
                Brand = sportShoe.Brand?.Name!,
                Size = sportShoe.Size?.Number ?? 0m,
                Sport = sportShoe.Sport?.Name!,
                ReleaseDate = sportShoe.ReleaseDate,
                Genre = sportShoe.Genre?.GenreName!

            };
        }

        public static SportShoeDeleteDto ToDeleteDto(SportShoe sportShoe)
        {
            return new SportShoeDeleteDto
            {
                SportShoeId = sportShoe.SportShoeId,
                RowVersion = sportShoe.RowVersion
            };
        }
    }
}  
