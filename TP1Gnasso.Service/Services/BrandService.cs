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
using TP1Gnasso.Service.DTOs.Brand;
using TP1Gnasso.Service.DTOs.SportShoe;
using TP1Gnasso.Service.Interfaces;
using TP1Gnasso.Service.Mappers;

namespace TP1Gnasso.Service.Services
{
    public class BrandService : IBrandService
    {
        private readonly IValidator<Brand> _validator;
        private readonly IUnitOfWork _uow;

        public BrandService(IValidator<Brand> validator, IUnitOfWork unitOfWork)
        {
            _validator = validator;
            _uow = unitOfWork;
        }
        public Result Add(BrandCreateDto brandDto)
        {
            var brand = BrandMapper.Toentity(brandDto);

            var result = _validator.Validate(brand);
            if(!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(b => b.ErrorMessage).ToList());

            }
            if(_uow.Brands.Exist(brand.Name!, brand.BrandId))
            {
                return Result.Failure("Same name brand already exists!");
            }
            try
            {
                _uow.Brands.Add(brand);
                _uow.Save();
                return Result.Success();
            }
            catch(Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public Result Delete(int id)
        {
            var brand = _uow.Brands.GetById(id);
            if(brand == null)
            {
                return Result.Failure("Brand not found!");
            }
            if(_uow.Brands.HasShoes(id))
            {
                return Result.Failure("Thebrand is asociated with shoes, it cannot be deleted!");
            }
            try
            {
                _uow.Brands.Delete(id);
                _uow.Save();
                return Result.Success();
            }
            catch(Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public Result Delete(BrandDeleteDto brandDeleteDto)
        {
            try
            {
                _uow.Brands.Delete(brandDeleteDto.BrandId, brandDeleteDto.RowVersion);
                _uow.Save();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _uow.RollBack();
                return Result.ConcurrencyConflict("Another user has already modified the record");
            }
            catch (KeyNotFoundException)
            {
                _uow.RollBack();
                return Result.ConcurrencyConflict("Sport shoe not found");
            }
            catch (Exception ex)
            {
                _uow.RollBack();
                return Result.Failure(ex.Message);
            }
        }
        

        public Result<List<SportShoeListDto>> FilterByActive(bool activo)
        {
            throw new NotImplementedException();
        }

        public Result<List<BrandListDto>> GetAll()
        {
            var brands = _uow.Brands.GetAll()
                .Select(b => BrandMapper
                .ToBrandListDto(b))
                .ToList();
            return Result<List<BrandListDto>>.Success(brands);
        }

        public Result<BrandListDto> GetBrandByName(string name)
        {
            var brand = _uow.Brands
                  .GetAll()
                  .FirstOrDefault(b => b.Name == name);

            if (brand == null)
            {
                return Result<BrandListDto>.Failure("Brand not found!");
            }

            return Result<BrandListDto>
                .Success(BrandMapper.ToBrandListDto(brand));
        }

        public Result<BrandListDto> GetById(int id)
        {
            var brand = _uow.Brands.GetById(id);
            if(brand == null)
            {
                return Result<BrandListDto>.Failure("Brand not found!");
            }
            return Result<BrandListDto>.Success(BrandMapper.ToBrandListDto(brand));
        }

        public Result<BrandEditDto> GetForUpdate(int id)
        {
            var brand = _uow.Brands.GetById(id);
            if(brand == null)
            {
                return Result<BrandEditDto>.Failure("Brand not found!");

            }
            return Result<BrandEditDto>.Success(BrandMapper.ToBrandEditDto(brand));
        }

        public Result<BrandDeleteDto> GetToDelete(int id)
        {
            var brand = _uow.Brands.GetById(id);
            if (brand != null)
            {
                var brandDeleteDto = BrandMapper.ToDeleteDto(brand);
                return Result<BrandDeleteDto>.Success(brandDeleteDto);
            }
            return Result<BrandDeleteDto>.Failure("Brand not found");
        }

        public Result Update(BrandEditDto brandDto)
        {
            var brandToValidate =  BrandMapper.ToEntity(brandDto);
            var result = _validator.Validate(brandToValidate);
            if(!result.IsValid)
            {
                return Result.Failure(result.Errors.Select(b => b.ErrorMessage).ToList());
            }

            Brand? brand = _uow.Brands.GetById(brandDto.BrandId);
            if(brand == null)
            {
                return Result.Failure("Brand not found!");
            }

            brand.Name = brandDto.Name;
            brand.Country = brandDto.Country;
            brand.Active = brandDto.Active;

            if(_uow.Brands.Exist(brand.Name!, brand.BrandId))
            {
                return Result.Failure("Same name brand already exists!");
            }
            try
            {
                _uow.Save();
                return Result.Success();
            }
            catch (Exception ex)
            {

                return Result.Failure(ex.Message);
            }
        }
    }
}
