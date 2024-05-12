using DataAccess.DalApi;
using DataAccess.Models;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using BL.blModels;
using BL;
using BL.blApi;

namespace lesson11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class URYController : ControllerBase
    {
        IURYRepo uryRepo;
        public URYController(IURYRepo uryRepo)
        {
            this.uryRepo = uryRepo;
        }

        [HttpGet]
        public ActionResult<List<UniversityRankingData>> GetAll([FromQuery] URYqueryparams queryParams)
        {
            var result = uryRepo.GetAllRankingTable(queryParams);

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

