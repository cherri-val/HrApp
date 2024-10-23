using HrApp.Lib.Db;
using HrApp.Lib.InternalSystems;
using HrApp.Lib.Models;

namespace HrApp.Lib.Api
{
	public static class ApiRequests
	{
		public static CandidateModel? CreateCandidate(ApplicationContext dbContext, CandidateModel candidate)
		{
			dbContext.Candidates.Add(candidate);
			dbContext.SaveChanges();
			return candidate;
		}

		public static void UpdateCandidate(ApplicationContext dbContext, CandidateModel candidate)
		{
			CandidateModel? dbModel = GetCandidate(dbContext, candidate.Id);
			if (dbModel != null)
			{
				dbModel.FIO = candidate.FIO;
				dbModel.PhoneNumber = candidate.PhoneNumber;
				dbModel.Email = candidate.Email;
				dbModel.Status = candidate.Status;
				dbModel.Description = candidate.Description;
				dbContext.SaveChanges();
			}
		}

		public static void DeleteCandidate(ApplicationContext dbContext, int candidateId)
		{
			CandidateModel? dbModel = GetCandidate(dbContext, candidateId);
			if (dbModel != null)
			{
				dbContext.Candidates.Remove(dbModel);
				dbContext.SaveChanges();
			}
		}

		public static CandidateModel? GetCandidate(ApplicationContext dbContext, int candidateId) => dbContext.Candidates.FirstOrDefault(x => x.Id == candidateId);

		public static List<CandidateModel> GetCandidates(ApplicationContext dbContext) => dbContext.Candidates.ToList();

		public static void AddCandidatesFromSystem(ApplicationContext dbContext, EInternalSystem system)
		{
			IInternalSystem internalSystem = null;

			switch (system)
			{
				case EInternalSystem.test:
					internalSystem = new TestInternalApi();
					break;
				case EInternalSystem.Hh:
				case EInternalSystem.habr:
					throw new NotImplementedException();
			}
			var newCandidates = internalSystem?.GetCandidates();
			dbContext.AddRange(newCandidates);
			dbContext.SaveChanges();
		}
	}
}
