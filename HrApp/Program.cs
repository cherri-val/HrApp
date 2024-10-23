using HrApp.Db;
using HrApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ScreenApp
{
	internal class Program
	{

		static void Main(string[] args)
		{
			var options = new DbContextOptionsBuilder<ApplicationContext>()
				.UseSqlServer(@"Server=localhost;Database=testbase;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;Integrated Security=false;Password=RootRoot12;User Id=sa;")
				.Options;
			using (var dbContext = new ApplicationContext(options))
			{
				//var candidate = new CandidateModel()
				//{
				//	FIO = "abc",
				//	Email = "abc@email.ru",
				//	Status = EStatus.hr,
				//	PhoneNumber = 89042523252,
				//	Description = "frontend"
				//};
				//var candidateId = ApiRequests.CreateCandidate(dbContext, candidate)?.Id;

				//var dbCandidate = ApiRequests.GetCandidate(dbContext, candidateId);
			}
		}
	}
}