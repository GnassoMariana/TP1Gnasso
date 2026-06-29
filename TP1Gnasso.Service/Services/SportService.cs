using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TP1Gnasso.Data;
using TP1Gnasso.Entities;
using TP1Gnasso.Service.Common;
using TP1Gnasso.Service.DTOs.Sport;
using TP1Gnasso.Service.Interfaces;
using TP1Gnasso.Service.Mappers;

namespace TP1Gnasso.Service.Services
{
    public class SportService : ISportService
    {
        private readonly IValidator<Sport> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public SportService(IValidator<Sport> validator, IUnitOfWork unitOfWork)
        {
            _validator = validator;
            _unitOfWork = unitOfWork;
        }
        public Result Add(SportCreateDto sportDto)
        {
            var sport = SportMapper.ToEntity(sportDto);
            var result = _validator.Validate(sport);

            if (!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            if (_unitOfWork.Sports.GetAll().Any(s => s.Name == sport.Name))
            {
                return Result.Failure($"A sport with the name '{sport.Name}' already exists.");
            }
            try
            {
                _unitOfWork.Sports.Add(sport);
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
            var sport = _unitOfWork.Sports.GetById(id);
            if (sport == null)
            {
                return Result.Failure("Sport not found");
            }
            if (_unitOfWork.Sports.HasShoes(id))
            {
                return Result.Failure("Cannot delete sport with associated shoes");
            }

            try
            {
                _unitOfWork.Sports.Delete(id);
                _unitOfWork.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {

                return Result.Failure(ex.Message);
            }
        }

        public Result Delete(SportDeleteDto sportDeleteDto)
        {
            try
            {
                _unitOfWork.Sports.Delete(sportDeleteDto.SportId, sportDeleteDto.RowVersion);
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
                return Result.ConcurrencyConflict("Sport not found");
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                return Result.Failure(ex.Message);
            }
        }

        public Result<List<SportListDto>> FilterByActive(bool activo)
        {
            try
            {
                var query = _unitOfWork.Sports.Query();
                var list = query.Where(s => s.Active == activo);
                var dtoList = list.Select(s => SportMapper.ToSportListDto(s)).ToList();
                return Result<List<SportListDto>>.Success(dtoList);

            }
            catch (Exception ex)
            {

                return Result<List<SportListDto>>.Failure(ex.Message);
            }
        }

        public Result<List<SportListDto>> GetAll()
        {
            var sport = _unitOfWork.Sports.GetAll()
                .Select(s => SportMapper
                .ToSportListDto(s))
                .ToList();
            return Result<List<SportListDto>>.Success(sport);

        }

        public Result<SportListDto> GetById(int id)
        {
            Sport sport = (Sport)_unitOfWork.Sports.GetById(id);
            if (sport == null) return Result<SportListDto>.Failure("Sport not found");
            return Result<SportListDto>.Success(SportMapper.ToSportListDto(sport));
        }

        public Result<SportEditDto> GetForUpdate(int id)
        {
            Sport sport = (Sport)_unitOfWork.Sports.GetById(id);
            if (sport == null)
            {
                return Result<SportEditDto>.Failure("Sport not found");
            }
            return Result<SportEditDto>.Success(SportMapper.ToSportEditDto(sport));
        }

        public Result<SportListDto> GetSportByName(string name)
        {
            var sport = _unitOfWork.Sports
                       .GetAll()
                       .FirstOrDefault(s => s.Name == name);

            if (sport == null)
            {
                return Result<SportListDto>.Failure("Sport not found");
            }

            return Result<SportListDto>
                .Success(SportMapper.ToSportListDto(sport));
        }

        public Result<SportDeleteDto> GetToDelete(int id)
        {
            var sport = _unitOfWork.Sports.GetById(id);
            if (sport != null)
            {
                var sportToDeleteDto = SportMapper.ToDeleteDto(sport);
                return Result<SportDeleteDto>.Success(sportToDeleteDto);
            }
            return Result<SportDeleteDto>.Failure("Sport not found");
        }

        public Result Update(SportEditDto sportDto)
        {
            var sportToValidate = SportMapper.ToEntity(sportDto);
            var result = _validator.Validate(sportToValidate);

            if (!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            Sport sport = (Sport)_unitOfWork.Sports.GetById(sportDto.SportId);
            if (sport == null)
            {
                return Result.Failure("Sport not found");
            }

            sport.Name = sportDto.Name;
            sport.Active = sportDto.Active;

            if (_unitOfWork.Sports.Exists(sport.Name!, sport.SportId))
            {
                return Result.Failure("Sport already exists!");
            }
            try
            {
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
