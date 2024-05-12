using DataAccess.DalApi;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAccess.DalImplemintation
{
    public class UniversityRepo : IUniversityRepo
    {
        AcademyContext academyContext;
        public UniversityRepo(AcademyContext academyContext)
        {
            this.academyContext = academyContext;
        }
        public University Add(University university)
        {
            academyContext.Universities.Add(university);
            academyContext.SaveChanges();
            return university;
        }

        public University Get(int id)
        {
            throw new NotImplementedException();
        }

        public PagedList<University> GetAll(QueryParams queryParameters)
        {
            var queryParams = queryParameters as UniversityQueryParameters;
            if (queryParams == null) { throw new Exception("invalid university query params"); }
            var queryable = academyContext.Universities.AsQueryable();
            if (queryParams.CountryId > 0)
            {
                queryable = queryable.Where(u => u.CountryId == queryParams.CountryId);
            }
            //if (/*some more filters...*/)
            //{

            //}
            queryable.OrderBy(u => u.UniversityName);

            return PagedList<University>.ToPagedList(queryable, queryParams.PageNumber, queryParams.PageSize);
        }

        //public List<University> GetAll(QueryParams queryParams)
        //{
        //    throw new NotImplementedException();
        //}

        public University Update(University obj)
        {
            throw new NotImplementedException();
        }

        //public IQueryable<University> FindAll()
        //{
        //    return academyContext.Set<University>();
        //}


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
                                 CountryId=u.CountryId
                             };
            var queryable= query.AsQueryable();
            if (queryParams.Year > 0)
            {
                queryable = queryable.Where(u => u.Year == queryParams.Year);
            }
            if (queryParams.UniversityName!=null)
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
