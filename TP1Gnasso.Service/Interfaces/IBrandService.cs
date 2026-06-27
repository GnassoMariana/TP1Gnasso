using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Service.Common;
using TP1Gnasso.Service.DTOs.Brand;
using TP1Gnasso.Service.DTOs.SportShoe;

namespace TP1Gnasso.Service.Interfaces
{
    public interface IBrandService
    {
        Result<List<BrandListDto>> GetAll();
        Result<BrandListDto> GetById(int id);
        Result<BrandEditDto> GetForUpdate(int id);
        Result<BrandDeleteDto> GetToDelete(int id);
        Result Add(BrandCreateDto brandDto);
        Result Update(BrandEditDto brandDto);
        Result Delete(BrandDeleteDto brandDeleteDto);

        Result<BrandListDto> GetBrandByName(string name);
        Result<List<SportShoeListDto>> FilterByActive(bool activo);


    }
}
