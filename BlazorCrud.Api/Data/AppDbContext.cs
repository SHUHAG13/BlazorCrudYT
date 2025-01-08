using BlazorCrud.Library;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Api.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}
        public DbSet<Student> Students { get; set; }
    }
}
