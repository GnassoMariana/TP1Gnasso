using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Service.Common;
using TP1Gnasso.Service.DTOs.Genre;

namespace TP1Gnasso.Service.Interfaces
{
    public interface IGenreService
    {
        Result<List<GenreListDto>> GetAll();
    }
}
