using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Service.Common;
using TP1Gnasso.Service.DTOs.Brand;

namespace TP1Gnasso.Service.Interfaces
{
    public interface IBrandService
    {
        Result<List<BrandListDto>> GetAll();
        Result<BrandListDto> GetById(int id);
        Result<BrandEditDto> GetForUpdate(int id);
        Result Add(BrandCreateDto brandDto);
        Result Update(BrandEditDto brandDto);
        Result Delete(int id);

    }
}
