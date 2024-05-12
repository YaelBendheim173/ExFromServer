using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DalApi
{
    public interface IRepo<T/*, Y*/>
    {
        //List<T> GetAll(Y queryParams);
        PagedList<T> GetAll(QueryParams queryParams);
        T Get(int id);
        T Add(T obj);
        T Update(T obj);

        //public IQueryable<T> FindAll()
        //{

        //}
    }
}
