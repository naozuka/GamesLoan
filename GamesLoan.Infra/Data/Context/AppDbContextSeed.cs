using System;
using Microsoft.EntityFrameworkCore;

namespace GamesLoan.Infra.Data.Context
{
    public class AppDbContextSeed
    {
        public static void SeedAsync(AppDbContext dbContext)   
        {
            Console.WriteLine("===================================> Run Migration...");
            dbContext.Database.Migrate();            
        }
    }
}