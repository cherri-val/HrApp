using HrApp.Models;

namespace HrApp.InternalSystems
{
	public interface IInternalSystem
	{
		List<CandidateModel> GetCandidates();
	}
}
 