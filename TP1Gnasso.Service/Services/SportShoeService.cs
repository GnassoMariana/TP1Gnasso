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
using TP1Gnasso.Service.DTOs.SportShoe;
using TP1Gnasso.Service.Interfaces;
using TP1Gnasso.Service.Mappers;

namespace TP1Gnasso.Service.Services
{
    public class SportShoeService : ISportShoeService
    {
        private readonly IValidator<SportShoe> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public SportShoeService(IValidator<SportShoe> validator, IUnitOfWork unitOfWork)
        {
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public Result Add(SportShoeCreateDto sportShoeDto)
        {
            try
            {
                var brand = _unitOfWork.Brands
                    .GetAll()
                    .FirstOrDefault(b => b.Name == sportShoeDto.Brand);

                if (brand is null)
                {
                    brand = new Brand
                    {
                        Name = sportShoeDto.Brand,
                        Active = true
                    };

                    _unitOfWork.Brands.Add(brand);
                    _unitOfWork.Save();
                }

                var sport = _unitOfWork.Sports
                    .GetAll()
                    .FirstOrDefault(s => s.Name == sportShoeDto.Sport);

                if (sport is null)
                {
                    sport = new Sport
                    {
                        Name = sportShoeDto.Sport,
                        Active = true
                    };

                    _unitOfWork.Sports.Add(sport);
                    _unitOfWork.Save();
                }

                sportShoeDto.BrandId = brand.BrandId;
                sportShoeDto.SportId = sport.SportId;

                var sportShoe = SportShoeMapper.ToEntity(sportShoeDto);

                var result = _validator.Validate(sportShoe);

                if (!result.IsValid)
                {
                    return Result.Failure(
                        result.Errors.Select(e => e.ErrorMessage).ToList());
                }

                if (_unitOfWork.SportShoes.Exist(
                    sportShoe.Model!,
                    sportShoe.SizeId,
                    sportShoe.SportShoeId))
                {
                    return Result.Failure(
                        $"A sport shoe with the model '{sportShoe.Model}' and the size {sportShoe.Size} already exists.");
                }

                _unitOfWork.SportShoes.Add(sportShoe);
                _unitOfWork.Save();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        //public Result Delete(int id)
        //{
        //    try
        //    {
        //        _unitOfWork.SportShoes.Delete(id);
        //        _unitOfWork.Save();
        //        return Result.Success();


        //    }
        //    catch (Exception ex)
        //    {

        //        return Result.Failure(ex.Message);
        //    }
        //}

        public Result Delete(SportShoeDeleteDto sportShoeDto)
        {
            try
            {
                _unitOfWork.SportShoes.Delete(sportShoeDto.SportShoeId, sportShoeDto.RowVersion);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                _unitOfWork.RollBack();
                return Result.ConcurrencyConflict("Another user has already modified the record");
            }
            catch(KeyNotFoundException)
            {
                _unitOfWork.RollBack();
                return Result.ConcurrencyConflict("Sport shoe not found");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure(ex.Message);
            }
        }

        public Result<List<SportShoeListDto>> FilterByActive(bool activo)
        {
            try
            {
                var query = _unitOfWork.SportShoes.Query();
                var list = query.Where(ss => ss.Active == activo);
                var dtoList = list.Select(ss =>SportShoeMapper.ToSportShoeListDto(ss)).ToList();
                return Result<List<SportShoeListDto>>.Success(dtoList);
            
            }
            catch (Exception ex)
            {

                return Result<List<SportShoeListDto>>.Failure(ex.Message);
            }
        }

        public Result<List<SportShoeListDto>> GetAll()
        {
            var sportShoes = _unitOfWork.SportShoes.GetAll()
                .Select(s => SportShoeMapper.ToSportShoeListDto(s))
                .ToList();
            return Result<List<SportShoeListDto>>.Success(sportShoes);
        }

        public Result<SportShoeListDto> GetById(int id)
        {
            var sportShoe = _unitOfWork.SportShoes.GetById(id);
            if (sportShoe == null) return Result<SportShoeListDto>.Failure("Sport shoe not found");
            return Result<SportShoeListDto>.Success(SportShoeMapper.ToSportShoeListDto(sportShoe));
        }

        public Result<SportShoeDetailsDto> GetDetails(int id)
        {
            var sportShoe = _unitOfWork.SportShoes.GetById(id);
            if (sportShoe is null)
            {
                return Result<SportShoeDetailsDto>.Failure("Sport shoe not found");
            }
            return Result<SportShoeDetailsDto>.Success(SportShoeMapper.ToSportShoeDetailsDto(sportShoe));
        }

        public Result<SportShoeEditDto> GetForUpdate(int id)
        {
            var sportShoe = _unitOfWork.SportShoes.GetById(id);
            if(sportShoe == null)
            {
                return Result<SportShoeEditDto>.Failure("Sport shoe not found");
            }
            return Result<SportShoeEditDto>.Success(SportShoeMapper.ToSportShoeEditDto(sportShoe));
        }

        public Result<SportShoeDeleteDto> GetToDelete(int id)
        {
            var sportShoe = _unitOfWork.SportShoes.GetById(id);
            if (sportShoe != null)
            {
                var sportShoeDeleteDto = SportShoeMapper.ToDeleteDto(sportShoe);
                return Result<SportShoeDeleteDto>.Success(sportShoeDeleteDto);
            }
            return Result<SportShoeDeleteDto>.Failure("Sport shoe not found");
        }

        public Result Update(SportShoeEditDto sportShoeDto)
        {
            var sportShoeToValidate = SportShoeMapper.ToEntity(sportShoeDto);
            var result = _validator.Validate(sportShoeToValidate);
            if(!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(s => s.ErrorMessage).ToList());
            }
            try
            {
                SportShoe sportShoe = _unitOfWork.SportShoes.GetById(sportShoeDto.SportShoeId);
                if (sportShoe == null)
                {
                    return Result.Failure("Sport shoe not found");
                }
                if (_unitOfWork.SportShoes.Exist(sportShoeDto.Model!, sportShoeDto.SizeId, sportShoeDto.SportShoeId))
                {
                    return Result.Failure($"A sport shoe with the model '{sportShoeDto.Model}' and the size {sportShoeDto.SizeId} already exists.");
                }

                sportShoe.Model = sportShoeDto.Model;
                sportShoe.Price = sportShoeDto.Price;
                sportShoe.ReleaseDate = sportShoeDto.ReleaseDate;
                sportShoe.Active = sportShoeDto.Active;
                sportShoe.BrandId = sportShoeDto.BrandId;
                sportShoe.SizeId = sportShoeDto.SizeId; ;
                sportShoe.SportId = sportShoeDto.SportId;

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
