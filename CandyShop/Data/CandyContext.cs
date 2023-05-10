using CandyShop.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CandyShop.Data
{
    public class CandyContext:DbContext
    {
        public CandyContext(DbContextOptions<CandyContext> options) : base(options) { 
        
        }
        public DbSet<Candy>Candies{ get; set; }


}
}
