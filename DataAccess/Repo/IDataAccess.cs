using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repo
{
    public interface IDataAccess<T>
    {
        //returntype name(parameters);
        Task<List<T>> GetAll(string tableName);
        Task<List<T>> GetByFilter(string tableName, string whereClause);
    }
}
