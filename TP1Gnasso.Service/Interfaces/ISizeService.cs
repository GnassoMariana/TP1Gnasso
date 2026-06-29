using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Service.Common;
using TP1Gnasso.Service.DTOs.Size;
using TP1Gnasso.Service.DTOs.Sport;

namespace TP1Gnasso.Service.Interfaces
{
    public interface ISizeService
    {
        Result<List<SizeListDto>> GetAll();
        Result<SizeListDto> GetById(int id);
        Result<SizeEditDto> GetForUpdate(int id);

        Result<SizeDeleteDto> GetToDelete(int id);
        Result<List<SizeListDto>> FilterByActive(bool activo);


        Result Add(SizeCreateDto sizeDto);
        
        Result Update(SizeEditDto sizeDto);

        Result Delete(SizeDeleteDto sizeDeleteDto);

        //Result HasSizes(int id);
        Result<SizeListDto> GetSizeByNumber(decimal number);



    }
}
