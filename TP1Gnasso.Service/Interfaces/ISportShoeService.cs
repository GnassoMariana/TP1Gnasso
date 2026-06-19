using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Service.Common;
using TP1Gnasso.Service.DTOs.SportShoe;

namespace TP1Gnasso.Service.Interfaces
{
    public interface ISportShoeService
    {
        Result<List<SportShoeListDto>> GetAll();
        Result<SportShoeListDto> GetById(int id);
        Result<SportShoeEditDto> GetForUpdate(int id);
        Result<SportShoeDeleteDto> GetToDelete(int id);

        Result<SportShoeDetailsDto> GetDetails(int id);
        Result Add(SportShoeCreateDto sportShoeDto);
        Result Update(SportShoeEditDto sportShoeDto);
        Result Delete(SportShoeDeleteDto sportShoeDto);
        Result<List<SportShoeListDto>> FilterByActive(bool activo);


    }
}
