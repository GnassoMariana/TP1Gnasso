using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Entities;
using TP1Gnasso.Service.DTOs.Brand;
using TP1Gnasso.Service.DTOs.SportShoe;

namespace TP1Gnasso.Service.Mappers
{
    public class BrandMapper
    {
        public static BrandListDto ToBrandListDto(Brand brand)
        {
            return new BrandListDto
            {
                BrandId = brand.BrandId,
                Name = brand.Name,
                Country = brand.Country,
                 Active = brand.Active
            };
        }

        public static  BrandEditDto ToBrandEditDto(Brand brand)
        {
            return new BrandEditDto
            {
                BrandId = brand.BrandId,
                Name = brand.Name,
                Country = brand.Country,
                Active = brand.Active


            };
        }

        public static Brand ToEntity(BrandEditDto brandDto)
        {
            return new Brand
            {
                BrandId = brandDto.BrandId,
                Name = brandDto.Name!,
                Country = brandDto.Country,
                Active = brandDto.Active
            };

        }

        public static Brand Toentity(BrandCreateDto brandDto)
        {
            return new Brand
            {
                Name = brandDto.Name,
                Country = brandDto.Country,
                Active = brandDto.Active
            };
        }

        public static BrandDeleteDto ToDeleteDto(Brand brand)
        {
            return new BrandDeleteDto
            {
                BrandId = brand.BrandId,
                RowVersion = brand.RowVersion
            };
        }

    }
}
