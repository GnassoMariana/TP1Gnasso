using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Service.Common;
using TP1Gnasso.Service.DTOs.Size;

namespace TP1Gnasso.Service.Interfaces
{
    public interface ISizeService
    {
        Result<List<SizeListDto>> GetAll();
        Result<SizeListDto> GetById(int id);
        Result<SizeEditDto> GetForUpdate(int id);

        Result Add(SizeCreateDto sizeDto);
        
        Result Update(SizeEditDto sizeDto);

        Result Delete(int id);

        //Result HasSizes(int id);


    }
}
