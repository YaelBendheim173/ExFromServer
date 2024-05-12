using BL.blModels;
using DataAccess.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.blApi;

namespace BL.blImplemintation
{
    public class URYRepo : IURYRepo
    {
        AcademyContext academyContext;
        public URYRepo(AcademyContext academyContext)
        {
            this.academyContext = academyContext;
        }
        public PagedList<UniversityRankingData> GetAllRankingTable(QueryParams queryParameters)
        {
            var queryParams = queryParameters as URYqueryparams;
            if (queryParams == null) { throw new Exception("invalid university query params"); }
            var query = from ury in academyContext.UniversityRankingYears
                        join u in academyContext.Universities on ury.UniversityId equals u.Id
                        join rc in academyContext.RankingCriteria on ury.RankingCriteriaId equals rc.Id
                        join rs in academyContext.RankingSystems on rc.RankingSystemId equals rs.Id
                        select new UniversityRankingData
                        {
                            UniversityName = u.UniversityName,
                            Year = ury.Year,
                            CriteriaName = rc.CriteriaName,
                            Score = ury.Score,
                            SystemName = rs.SystemName,
                            CountryId = u.CountryId
                        };
            var queryable = query.AsQueryable();
            if (queryParams.Year > 0)
            {
                queryable = queryable.Where(u => u.Year == queryParams.Year);
            }
            if (queryParams.UniversityName != null)
            {
                queryable = queryable.Where(u => u.UniversityName == queryParams.UniversityName);
            }
            if (queryParams.CountryId > 0)
            {
                queryable = queryable.Where(u => u.CountryId == queryParams.CountryId);
            }
            queryable.OrderBy(u => u.UniversityName);
            return PagedList<UniversityRankingData>.ToPagedList(queryable, queryParams.PageNumber, queryParams.PageSize);
        }
    }
}

