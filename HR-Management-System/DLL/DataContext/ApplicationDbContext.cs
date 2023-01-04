using Microsoft.EntityFrameworkCore;


namespace DLL.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        protected ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }
    }
}
