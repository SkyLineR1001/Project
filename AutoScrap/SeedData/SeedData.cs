using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AutoScrap.Data;
using System;
using System.Linq;

namespace AutoScrap.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AutoScrapContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AutoScrapContext>>()))
            {
                // Look for any movies.
                if (context.Part.Any())
                {
                    return;   // DB has been seeded
                }
                context.Part.AddRange(
                    new Part
                    {
                        Title = "Link",
                        ManufactureeDate = DateTime.Parse("1989-2-12"),
                        System = "Suspension",
                        Condition = "Good",
                        Price = 7.99M
                    },
                    new Part
                    {
                        Title = "Breaking Disk",
                        ManufactureeDate = DateTime.Parse("1989-2-12"),
                        System = "Breake System",
                        Condition = "Normal",
                        Price = 8.99M
                    },
                    new Part
                    {
                        Title = "Joint",
                        ManufactureeDate = DateTime.Parse("1989-2-12"),
                        System = "Suspension",
                        Condition = "Normal",
                        Price = 9.99M
                    },
                    new Part
                    {
                        Title = "Gearbox",
                        ManufactureeDate = DateTime.Parse("1989-2-12"),
                        System = "Transmission",
                        Condition = "Normal",
                        Price = 11.99M
                    }
                );
                context.SaveChanges();
            }


        }
    }
}
