using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Service.Common;
using TP1Gnasso.Service.DTOs.Sport;

namespace TP1Gnasso.Service.Interfaces
{
    public interface ISportService
    {
        Result<List<SportListDto>> GetAll();
        Result<SportListDto> GetById(int id);
        Result<SportEditDto> GetForUpdate(int id);
        Result Add(SportCreateDto sportDto);
        Result Update(SportEditDto sportDto);
        Result Delete(int id);

        Result<SportListDto> GetSportByName(string name);


    }
}
