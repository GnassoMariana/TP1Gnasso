using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Service.Common;
using TP1Gnasso.Service.DTOs.Brand;
using TP1Gnasso.Service.DTOs.Sport;
using TP1Gnasso.Service.DTOs.SportShoe;

namespace TP1Gnasso.Service.Interfaces
{
    public interface ISportService
    {
        Result<List<SportListDto>> GetAll();
        Result<SportListDto> GetById(int id);
        Result<SportEditDto> GetForUpdate(int id);
        Result Add(SportCreateDto sportDto);
        Result Update(SportEditDto sportDto);
        Result Delete(SportDeleteDto sportDeleteDto);

        Result<SportListDto> GetSportByName(string name);

        Result<SportDeleteDto> GetToDelete(int id);
        Result<List<SportListDto>> FilterByActive(bool activo);




    }
}
