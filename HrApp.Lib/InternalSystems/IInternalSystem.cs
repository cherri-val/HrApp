using HrApp.Lib.Models;

namespace HrApp.Lib.InternalSystems
{
	public interface IInternalSystem
	{
		List<CandidateModel> GetCandidates();
	}
}
