using DataAccess.DalApi;
using DataAccess.Models;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace lesson11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class URYController : ControllerBase
    {
        IUniversityRepo universityRepo;
        public URYController(IUniversityRepo universityRepo)
        {
            this.universityRepo = universityRepo;
        }

        [HttpGet]
        public ActionResult<List<UniversityRankingData>> GetAll([FromQuery] URYqueryparams queryParams)
        {
            var result = universityRepo.GetAllRankingTable(queryParams);

            var metadata = new
            {
                result.TotalCount,
                result.TotalPages,
                result.PageSize,
                result.CurrentPage,
                result.HasNext,
                result.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));
            return result;
        }
    }
}

