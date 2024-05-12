using DataAccess.DalApi;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
