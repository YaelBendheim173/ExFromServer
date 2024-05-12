using BL.blModels;
using DataAccess;
using DataAccess.DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.blApi
{
    public interface IURYRepo
    {
        public PagedList<UniversityRankingData> GetAllRankingTable(QueryParams queryParameters);
    }
}
