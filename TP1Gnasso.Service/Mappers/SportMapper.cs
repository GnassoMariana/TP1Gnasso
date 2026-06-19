using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Entities;
using TP1Gnasso.Service.DTOs.Sport;

namespace TP1Gnasso.Service.Mappers
{
    public static class SportMapper
    {
        public static SportListDto ToSportListDto(Sport sport)
        {
            return new SportListDto
            {
                SportId = sport.SportId,
                Name = sport.Name,
                Active = sport.Active
            };
        }

        public static SportEditDto ToSportEditDto(Sport sport)
        {
            return new SportEditDto
            {
                SportId = sport.SportId,
                Name = sport.Name,

            };
        }

        public static Sport ToEntity(SportCreateDto sportDto)
        {
            return new Sport
            {
                Name = sportDto.Name,
                Active = sportDto.Active
            };
        }

        public static Sport ToEntity(SportEditDto sportEditdto)
        {
            return new Sport
            {
                Name = sportEditdto.Name,
                Active = sportEditdto.Active
            };
        }
    }
}
