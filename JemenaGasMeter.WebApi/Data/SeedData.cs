using JemenaGasMeter.WebApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JemenaGasMeter.WebApi.Data
{
    public class SeedData
    {
         public static void Initialize(IServiceProvider serviceProvider)
        {
            
                using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());
                context.Database.EnsureCreated();
                // Look for customers.
                if (context.Users.Any() && context.Users != null)
                    return; // DB has already been seeded.

                const string format = "dd/MM/yyyy hh:mm:ss tt";

                context.Users.AddRange(
                    new User
                    {
                        PayRollID = "1",
                        FirstName = "Raji",
                        LastName = "Rudhra",
                        UserType = UserType.Technician,
                        PIN = "1234",
                        Status = Status.Active,
                        ModifyDate = DateTime.ParseExact("20/01/2020 09:30:00 PM", format, null)
                    },
                    new User
                    {
                        PayRollID = "2",
                        FirstName = "Test",
                        LastName = "User",
                        UserType = UserType.Contractor,
                        PIN = "1234",
                        Status = Status.Inactive,
                        ModifyDate = DateTime.ParseExact("20/01/2020 09:30:00 PM", format, null)
                    },
                    new User
                    {
                        PayRollID = "3",
                        FirstName = "Abc",
                        LastName = "Test",
                        UserType = UserType.Technician,
                        PIN = "1234",
                        Status = Status.Active,
                        ModifyDate = DateTime.ParseExact("20/01/2020 09:30:00 PM", format, null)
                    },
                    new User
                    {
                        PayRollID = "4",
                        FirstName = "User",
                        LastName = "Test",
                        UserType = UserType.Contractor,
                        PIN = "1234",
                        Status = Status.Inactive,
                        ModifyDate = DateTime.ParseExact("20/01/2020 09:30:00 PM", format, null)
                    });

                context.SaveChanges();
          
        }
    }
}
