using HrApp.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace HrApp.Lib.Db
{
	public class ApplicationContext : DbContext
	{
		public DbSet<CandidateModel> Candidates { get; set; } = null!;

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
			//Database.EnsureDeleted();
			//Database.EnsureCreated();
		}
	}
}
