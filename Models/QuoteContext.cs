using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Diagnostics.CodeAnalysis;

namespace QuoteApi.Models
{
 // interacting with the Database, in this case inMemory
        public class QuoteContext : DbContext
        {
            public QuoteContext(DbContextOptions<QuoteContext> options) : base(options)
            {

            }
        public DbSet<QuoteItem> QuoteItems { get; set; } = null!;
        }
    
}
