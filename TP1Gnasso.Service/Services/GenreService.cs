using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Data;
using TP1Gnasso.Service.Common;
using TP1Gnasso.Service.DTOs.Genre;
using TP1Gnasso.Service.Interfaces;
using TP1Gnasso.Service.Mappers;

namespace TP1Gnasso.Service.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;  
        }
        public Result<List<GenreListDto>> GetAll()
        {
            try
            {
                var genres = _unitOfWork.Genres.GetAll()
                    .Select(GenreMapper.ToGenreListDto)
                    .ToList();

                return Result<List<GenreListDto>>.Success(genres);
            }
            catch (Exception ex)
            {
                return Result<List<GenreListDto>>.Failure(ex.Message);
            }
        }
    }
}
