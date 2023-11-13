using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Smileys.Data;
using Smileys.Models;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new SmileysContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<SmileysContext>>()))
        {
            if (context.Company.Any())
            {
                return;
            }

            context.Company.AddRange(
                new Company
                {
                    Name = "LEGO A/S",
                    CVR = 54562519,
                    Street = "Åstvej",
                    HouseNumber = "1",
                    ZipCode = 7190,
                    City = "Billund",
                    Smileys = "1111"
                }, 
                new Company
                {
                    Name = "LEGO House A/S",
                    CVR = 16632635,
                    Street = "Ole Kirks Plads",
                    HouseNumber = "1",
                    ZipCode = 7190,
                    City = "Billund",
                    Smileys = "4321"
                }, 
                new Company
                {
                    Name = "Dsv Road A/S",
                    CVR = 26366224,
                    Street = "Nokiavej",
                    HouseNumber = "30",
                    ZipCode = 8700,
                    City = "Horsens",
                    Smileys = "4324"
                }
            );
            context.SaveChanges();
        }
    }
}