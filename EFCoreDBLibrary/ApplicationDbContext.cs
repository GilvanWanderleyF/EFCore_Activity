using Microsoft.EntityFrameworkCore;

namespace EFCoreDBLibrary
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions options)
        {

        }

    }
}