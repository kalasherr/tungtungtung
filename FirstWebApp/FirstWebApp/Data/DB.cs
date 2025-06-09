    using FirstWebApp.Models;
    using Microsoft.EntityFrameworkCore;

    namespace FirstWebApp.Data;

    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options)
        {
            
        }
        
        public DbSet<Game> Games { get; set;}
    }