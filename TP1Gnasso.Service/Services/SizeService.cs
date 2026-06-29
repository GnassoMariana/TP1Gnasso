using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1Gnasso.Data;
using TP1Gnasso.Entities;
using TP1Gnasso.Service.Common;
using TP1Gnasso.Service.DTOs.Size;
using TP1Gnasso.Service.DTOs.Sport;
using TP1Gnasso.Service.Interfaces;
using TP1Gnasso.Service.Mappers;

namespace TP1Gnasso.Service.Services
{
    public class SizeService : ISizeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Size> _validator;

        public SizeService(IUnitOfWork unitOfWork, IValidator<Size> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }
        public Result Add(SizeCreateDto sizeDto)
        {
            var size = SizeMapper.ToEntity(sizeDto);
            var result = _validator.Validate(size);

            if(!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(s => s.ErrorMessage).ToList());
            }
            if(_unitOfWork.Sizes.Exists(size.Number, size.SizeId))
            {
                return Result.Failure("The size already exists!!");

            }
            try
            {
                _unitOfWork.Sizes.Add(size);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {

                return Result.Failure(ex.Message);
            }
           
        }

        public Result Delete(int id)
        {
            var size = _unitOfWork.Sizes.GetById(id);
            if(size == null)
            {
                return Result.Failure("Size not found");
            }
            if(_unitOfWork.Sizes.HasSizes(id))
            {
                return Result.Failure("The size is associeted with shoes");
            }
            try
            {
                _unitOfWork.Sizes.Delete(id);
                _unitOfWork.Save();
                return Result.Success();

            }
            catch (Exception ex)
            {

                return Result.Failure(ex.Message);

            }

        }

        public Result Delete(SizeDeleteDto sizeDeleteDto)
        {
            try
            {
                _unitOfWork.Sizes.Delete(sizeDeleteDto.SizeId, sizeDeleteDto.RowVersion);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _unitOfWork.RollBack();
                return Result.ConcurrencyConflict("Another user has already modified the record");
            }
            catch (KeyNotFoundException)
            {
                _unitOfWork.RollBack();
                return Result.ConcurrencyConflict("Size not found");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure(ex.Message);
            }
        }

        public Result<List<SizeListDto>> FilterByActive(bool activo)
        {
            try
            {
                var query = _unitOfWork.Sizes.Query();
                var list = query.Where(s => s.Active == activo);
                var dtoList = list.Select(s => SizeMapper.ToSizeListDto(s)).ToList();
                return Result<List<SizeListDto>>.Success(dtoList);

            }
            catch (Exception ex)
            {

                return Result<List<SizeListDto>>.Failure(ex.Message);
            }
        }

        public Result<List<SizeListDto>> GetAll()
        {
            var sizes = _unitOfWork.Sizes.GetAll()
                .Select(s=> SizeMapper.ToSizeListDto(s)).ToList();
            return Result<List<SizeListDto>>.Success(sizes);

        }

        public Result<SizeListDto> GetById(int id)
        {
            var size = _unitOfWork.Sizes.GetById(id);
            if(size == null)
            {
                return Result<SizeListDto>.Failure("Size not found");

            }
            return Result<SizeListDto>.Success(SizeMapper.ToSizeListDto(size));
        }

        public Result<SizeEditDto> GetForUpdate(int id)
        {
            var size = _unitOfWork.Sizes.GetById(id);
            if(size == null)
            {
                return Result<SizeEditDto>.Failure("Size not found");
            }
            return Result<SizeEditDto>.Success(SizeMapper.ToSizeEditDto(size));
        }

        public Result<SizeListDto> GetSizeByNumber(decimal number)
        {
            var size = _unitOfWork.Sizes
                       .GetAll()
                       .FirstOrDefault(s => s.Number == number);

            if (size == null)
            {
                return Result<SizeListDto>.Failure("Size not found");
            }

            return Result<SizeListDto>
                .Success(SizeMapper.ToSizeListDto(size));
        }

        public Result<SizeDeleteDto> GetToDelete(int id)
        {
            var size = _unitOfWork.Sizes.GetById(id);
            if (size != null)
            {
                var sizeToDelete = SizeMapper.ToDeleteDto(size);
                return Result<SizeDeleteDto>.Success(sizeToDelete);
            }
            return Result<SizeDeleteDto>.Failure("Size not found");
        }

        //public Result HasSizes(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public Result Update(SizeEditDto sizeDto)
        {
            var sizeToValidate = SizeMapper.ToEntity(sizeDto);
            var result = _validator.Validate(sizeToValidate);
            if(!result.IsValid)
            {
                return Result.Failure(result.Errors.Select( s => s.ErrorMessage).ToList());
            }

            var size = _unitOfWork.Sizes.GetById(sizeDto.SizeId);
            if(size == null)
            {
                return Result.Failure("Size not found");
            }

            size.Number = sizeDto.Number;
            size.Active = sizeDto.Active;

           
            if(_unitOfWork.Sizes.Exists(size.Number, size.SizeId))
            {
                return Result.Failure("The size already exists!!");
            }
            try
            {
                
                _unitOfWork.Sizes.Update(size, size.SizeId);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}
