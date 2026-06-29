using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Entities;
using TP1Gnasso.Service.DTOs.Brand;
using TP1Gnasso.Service.DTOs.Size;

namespace TP1Gnasso.Service.Mappers
{
    public class SizeMapper
    {
        public static Size ToEntity(SizeCreateDto sizeDto)
        {
            return new Size
            {
                Number = sizeDto.Number,
                Active = true
            };
        }

        public static SizeListDto ToSizeListDto(Size size)
        {
            return new SizeListDto
            {
                SizeId = size.SizeId,
                Number = size.Number,
                Active = size.Active

            };
        }

        public static SizeEditDto ToSizeEditDto(Size size)
        {
            return new SizeEditDto
            {
                SizeId = size.SizeId,
                Number = size.Number,
                Active = size.Active
            };
        }

        public static Size ToEntity(SizeEditDto dto)
        {
            return new Size
            {
                SizeId = dto.SizeId,
                Number = dto.Number,
                Active = dto.Active
            };
        }

        public static SizeDeleteDto ToDeleteDto(Size size)
        {
            return new SizeDeleteDto
            {
                SizeId = size.SizeId,
                RowVersion = size.RowVersion
            };
        }

    }
}
