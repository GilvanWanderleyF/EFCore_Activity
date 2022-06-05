using EFCoreDBLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCore_Activity0201
{
    class Program
    {
        private static IConfigurationRoot _configuration;
        private static DbContextOptionsBuilder<AdventureWorksContext> _optionsBuilder;

        static void Main(string[] args)
        {
            BuildConfiguration();
            BuildOptions();
            ListPeople();
        }

        static void BuildConfiguration()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
        }
        static void BuildOptions()
        {
            _optionsBuilder = new DbContextOptionsBuilder<AdventureWorksContext>()
                .UseSqlServer(_configuration.GetConnectionString("AdventureWorks"));
        }

        static void ListPeople()
        {
            using(var db = new AdventureWorksContext(_optionsBuilder.Options))
            {
                var people = db.People.OrderByDescending(x => x.LastName).Take(20).ToList();

                foreach (var person in people)
                {
                    Console.WriteLine($"{person.FirstName} {person.LastName}");
                }
            }
        }

    }
}