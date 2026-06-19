using Microsoft.Extensions.DependencyInjection;
using System;
using TP1Gnasso.IoC;
using TP1Gnasso.Service.DTOs.SportShoe;
using TP1Gnasso.Service.Interfaces;

namespace TP1Gnasso.Consola
{
    internal class Program
    {
        //static IServiceProvider provider = DependencyInyectionContainer.Configure();
        static void Main(string[] args)
        {


            //        do
            //        {
            //            Console.Clear();

            //            Console.WriteLine("1. Sport Shoes");
            //            Console.WriteLine("2. Sports");
            //            Console.WriteLine("3. Sizes");
            //            Console.WriteLine("4. Brands");
            //            Console.WriteLine("0. Exit");
            //            Console.Write("Select an option:");
            //            var option = Console.ReadLine();
            //            switch (option)
            //            {
            //                case "1":
            //                    SportShoesMenu();
            //                    break;
            //                case "2":
            //                    SportsMenu();
            //                    break;
            //                case "3":
            //                    SizesMenu();
            //                    break;
            //                case "4":
            //                    BrandsMenu();
            //                    break;
            //                case "0":
            //                    return;
            //                default:
            //                    break;
            //            }
            //        } while (true);
            //    }

            //    private static void BrandsMenu()
            //    {
            //        throw new NotImplementedException();
            //    }

            //    private static void SizesMenu()
            //    {
            //        throw new NotImplementedException();
            //    }

            //    private static void SportsMenu()
            //    {
            //        throw new NotImplementedException();
            //    }

            //    private static void SportShoesMenu()
            //    { 
            //        using (var scoped = provider.CreateScope())
            //        {
            //            var service = scoped.ServiceProvider.GetRequiredService<ISportShoeService>();

            //            do
            //            {
            //                Console.Clear();

            //                Console.WriteLine("Sport Shoes Manager");
            //                Console.WriteLine("1. List Sport Shoes");
            //                Console.WriteLine("2. Add Sport Shoe");
            //                Console.WriteLine("3. Delete Sport Shoe");
            //                Console.WriteLine("4. Update Sport Shoe");
            //                Console.WriteLine("5. Details");
            //                Console.WriteLine("0. Back");

            //                Console.Write("Select an option:");

            //                var option = Console.ReadLine();

            //                switch (option)
            //                {
            //                    case "1":
            //                        ListSportShoes(service);
            //                        break;
            //                    case "2":
            //                        AddSportShoe(service);
            //                        break;
            //                    case "3":
            //                        DeleteSportShoe(service);
            //                        break;
            //                    case "4":
            //                        UpdateSportShoe(service);
            //                        break;
            //                    case "5":
            //                        SportShoeDetails(service);
            //                        break;
            //                    case "0":
            //                        return;
            //                }

            //            } while (true);
            //        }
            //    }

            //    private static void SportShoeDetails(ISportShoeService service)
            //    {
            //        Console.Clear();

            //        ShowSportShoes(service);

            //        Console.WriteLine();
            //        Console.Write("Select an ID: ");

            //        var id = int.Parse(Console.ReadLine()!);

            //        var result = service.GetDetails(id);

            //        if (result.IsFailure)
            //        {
            //            foreach (var error in result.Errors)
            //            {
            //                Console.WriteLine(error);
            //            }

            //            Console.ReadLine();
            //            return;
            //        }

            //        var shoe = result.Value!;

            //        Console.WriteLine($"Id: {shoe.SportShoeId}");
            //        Console.WriteLine($"Model: {shoe.Model}");
            //        Console.WriteLine($"Price: {shoe.Price}");
            //        Console.WriteLine($"Release Date: {shoe.ReleaseDate:d}");
            //        Console.WriteLine($"Brand: {shoe.Brand}");
            //        Console.WriteLine($"Size: {shoe.Size}");
            //        Console.WriteLine($"Sport: {shoe.Sport}");
            //        Console.WriteLine($"Active: {shoe.Active}");

            //        Console.ReadLine();
            //    }

            //    private static void UpdateSportShoe(ISportShoeService service)
            //    {
            //        Console.Clear();

            //        ShowSportShoes(service);

            //        Console.WriteLine();
            //        Console.Write("Select an ID to update: ");

            //        var id = int.Parse(Console.ReadLine()!);

            //        var resultGet = service.GetForUpdate(id);

            //        if (resultGet.IsFailure)
            //        {
            //            foreach (var error in resultGet.Errors)
            //            {
            //                Console.WriteLine(error);
            //            }

            //            Console.ReadLine();
            //            return;
            //        }

            //        var shoe = resultGet.Value!;

            //        Console.Write($"Model ({shoe.Model}): ");
            //        var modelInput = Console.ReadLine();

            //        Console.Write($"Price ({shoe.Price}): ");
            //        var priceInput = Console.ReadLine();

            //        Console.Write($"Brand Id ({shoe.BrandId}): ");
            //        var brandInput = Console.ReadLine();

            //        Console.Write($"Size Id ({shoe.SizeId}): ");
            //        var sizeInput = Console.ReadLine();

            //        Console.Write($"Sport Id ({shoe.SportId}): ");
            //        var sportInput = Console.ReadLine();

            //        shoe.Model = string.IsNullOrWhiteSpace(modelInput)
            //            ? shoe.Model
            //            : modelInput;

            //        shoe.Price = string.IsNullOrWhiteSpace(priceInput)
            //            ? shoe.Price
            //            : decimal.Parse(priceInput);

            //        shoe.BrandId = string.IsNullOrWhiteSpace(brandInput)
            //            ? shoe.BrandId
            //            : int.Parse(brandInput);

            //        shoe.SizeId = string.IsNullOrWhiteSpace(sizeInput)
            //            ? shoe.SizeId
            //            : int.Parse(sizeInput);

            //        shoe.SportId = string.IsNullOrWhiteSpace(sportInput)
            //            ? shoe.SportId
            //            : int.Parse(sportInput);

            //        var result = service.Update(shoe);

            //        if (result.IsFailure)
            //        {
            //            foreach (var error in result.Errors)
            //            {
            //                Console.WriteLine(error);
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine("Sport shoe updated successfully.");
            //        }

            //        Console.ReadLine();
            //    }

            //    private static void DeleteSportShoe(ISportShoeService service)
            //    {
            //        Console.Clear();

            //        ShowSportShoes(service);

            //        Console.WriteLine();
            //        Console.Write("Select an ID to delete: ");

            //        var id = int.Parse(Console.ReadLine()!);

            //        var resultGet = service.GetById(id);

            //        if (resultGet.IsFailure)
            //        {
            //            foreach (var error in resultGet.Errors)
            //            {
            //                Console.WriteLine(error);
            //            }

            //            Console.ReadLine();
            //            return;
            //        }

            //        Console.Write(
            //            $"Delete '{resultGet.Value!.Model}'? (y/n): ");

            //        var response = Console.ReadLine();

            //        if (response?.ToLower() == "y")
            //        {
            //            var result = service.Delete(id);

            //            if (result.IsFailure)
            //            {
            //                foreach (var error in result.Errors)
            //                {
            //                    Console.WriteLine(error);
            //                }
            //            }
            //            else
            //            {
            //                Console.WriteLine("Sport shoe deleted successfully.");
            //            }
            //        }

            //        Console.ReadLine();
            //    }

            //    private static void AddSportShoe(ISportShoeService service)
            //    {

            //        Console.Clear();

            //        Console.WriteLine("Add Sport Shoe");
            //        Console.WriteLine();

            //        Console.Write("Model: ");
            //        var model = Console.ReadLine();

            //        Console.Write("Price: ");
            //        var price = decimal.Parse(Console.ReadLine()!);

            //        Console.Write("Release Date (yyyy-MM-dd): ");
            //        var releaseDate = DateTime.Parse(Console.ReadLine()!);

            //        Console.Write("Brand Id: ");
            //        var brandId = int.Parse(Console.ReadLine()!);

            //        Console.Write("Size Id: ");
            //        var sizeId = int.Parse(Console.ReadLine()!);

            //        Console.Write("Sport Id: ");
            //        var sportId = int.Parse(Console.ReadLine()!);

            //        var dto = new SportShoeCreateDto
            //        {
            //            Model = model!,
            //            Price = price,
            //            ReleaseDate = releaseDate,
            //            Active = true,
            //            BrandId = brandId,
            //            SizeId = sizeId,
            //            SportId = sportId
            //        };

            //        var result = service.Add(dto);

            //        if (result.IsFailure)
            //        {
            //            foreach (var error in result.Errors)
            //            {
            //                Console.WriteLine(error);
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine("Sport shoe added successfully.");
            //        }

            //        Console.ReadLine();
            //    }

            //    private static void ListSportShoes(ISportShoeService service)
            //    {
            //        Console.Clear();
            //        Console.WriteLine("List of Sport Shoes");
            //        Console.WriteLine();

            //        ShowSportShoes(service);

            //        Console.WriteLine();
            //        Console.WriteLine("Press ENTER to continue");
            //        Console.ReadLine();
            //    }

            //    private static void ShowSportShoes(ISportShoeService service)
            //    {
            //        var result = service.GetAll();

            //        if (result.IsFailure)
            //        {
            //            foreach (var error in result.Errors)
            //            {
            //                Console.WriteLine(error);
            //            }
            //            return;
            //        }

            //        foreach (var shoe in result.Value!)
            //        {
            //            Console.WriteLine(
            //                $"ID:{shoe.SportShoeId,3} " +
            //                $"Model:{shoe.Model,-25} " +
            //                $"Brand:{shoe.Brand,-15} " +
            //                $"Size:{shoe.Size,-5} " +
            //                $"Sport:{shoe.Sport,-15} " +
            //                $"Price:{shoe.Price}");
            //        }
            //    }
            //}


        }
    }
}