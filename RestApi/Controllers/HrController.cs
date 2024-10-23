using HrApp.Lib.Api;
using HrApp.Lib.Db;
using HrApp.Lib.InternalSystems;
using HrApp.Lib.Models;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class HrController : Controller
	{
		private readonly ILogger<HrController> _logger;
		private readonly ApplicationContext _dbContext;


		public HrController(ILogger<HrController> logger, ApplicationContext dbContext)
		{
			_logger = logger;
			_dbContext = dbContext;
		}

		[HttpPost("candidate")]
		public CandidateModel? CreateCandidate(CandidateModel candidate)
		{
			return ApiRequests.CreateCandidate(_dbContext, candidate);
		}

		[HttpPost("candidates")]
		public void AddCadidateDb(EInternalSystem system)
		{
			ApiRequests.AddCadidateDb(_dbContext, system);
		}

		[HttpPut("candidate")]
		public void UpdateCandidate(CandidateModel candidate)
		{
			ApiRequests.UpdateCandidate(_dbContext, candidate);
		}

		[HttpDelete("candidate/{id}")]
		public void DeleteCandidate(int id)
		{
			ApiRequests.DeleteCandidate(_dbContext, id);
		}

		[HttpGet("candidate/{id}")]
		public CandidateModel? GetCandidate(int id)
		{
			return ApiRequests.GetCandidate(_dbContext, id);
		}

		[HttpGet("candidates")]
		public List<CandidateModel> GetCandidates()
		{
			return ApiRequests.GetCandidates(_dbContext);
		}
	}
}
