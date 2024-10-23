using HrApp.Lib.Models;

namespace HrApp.Lib.InternalSystems
{
	internal class TestInternalApi : IInternalSystem
	{
		public List<CandidateModel> GetCandidates()
		{
			return new List<CandidateModel>()
			{
				new CandidateModel()
				{
					FIO = "Test from testSystem",
					PhoneNumber = "8888888888888",
					Email = "test@test.com",
					Status = EStatus.interview,
					Description = "for test"
				},
				new CandidateModel()
				{
					FIO = "Mark Twen",
					PhoneNumber = "89172175446",
					Email = "test2@test.com",
					Status = EStatus.probation,
					Description = "for test"
				},
				new CandidateModel()
				{
					FIO = "Lev Tolstoi",
					PhoneNumber = "89372856954",
					Email = "test3@test.com",
					Status = EStatus.employment,
					Description = "for test"
				}
			};
		}
	}
}
