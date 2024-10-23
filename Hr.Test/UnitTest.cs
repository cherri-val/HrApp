using HrApp.Lib.Api;
using HrApp.Lib.Db;
using HrApp.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace Hr.Test
{
	public class Tests
	{
		ApplicationContext _context;

		[SetUp]
		public void SetUp()
		{
			var options = new DbContextOptionsBuilder<ApplicationContext>()
				.UseInMemoryDatabase(databaseName: "CandidatesDatabase")
				.Options;

			_context = new ApplicationContext(options);
		}

		[Test]
		public void should_create_candidateModel()
		{
			var candidate = new CandidateModel()
			{
				FIO = "abc",
				Email = "abc@email.ru",
				Status = EStatus.hr,
				PhoneNumber = "89042523252",
				Description = "frontend"
			};
			ApiRequests.CreateCandidate(_context, candidate);

			var dbCandidate = _context.Candidates.FirstOrDefault();

			Assert.AreEqual(dbCandidate, candidate);
		}

		[Test]
		public void should_update_candidateModel()
		{
			var candidate = new CandidateModel()
			{
				FIO = "abc",
				Email = "abc@email.ru",
				Status = EStatus.hr,
				PhoneNumber = "89042523252",
				Description = "frontend"
			};

			ApiRequests.CreateCandidate(_context, candidate);
			var dbCandidate = _context.Candidates.FirstOrDefault();
			dbCandidate.Status = EStatus.employment;

			ApiRequests.UpdateCandidate(_context, dbCandidate);
			Assert.AreNotEqual(EStatus.hr, dbCandidate.Status);
		}

		[Test]
		public void should_delete_candidateModel()
		{
			var candidate = new CandidateModel()
			{
				FIO = "abc",
				Email = "abc@email.ru",
				Status = EStatus.hr,
				PhoneNumber = "89042523252",
				Description = "frontend"
			};
			var savedCandidate = ApiRequests.CreateCandidate(_context, candidate);

			ApiRequests.DeleteCandidate(_context, savedCandidate.Id);
			var dbCandidate = ApiRequests.GetCandidate(_context, savedCandidate.Id);
			Assert.IsNull(dbCandidate);
		}
	}
}