using System.Data.Common;
using System.Data;
using Dapper;
using System.Collections.Generic;

namespace Blazor_Store.Services
{
    public interface IDapperService
    {
        DbConnection GetConnection();
        T Get<T>(string sp, DynamicParameters parms,
            CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string sp, DynamicParameters parms,
            CommandType commandType = CommandType.StoredProcedure);
        int Execute(string sp, DynamicParameters parms,
            CommandType commandType = CommandType.StoredProcedure);
        T Insert<T>(string sp, DynamicParameters parms,
            CommandType commandType = CommandType.StoredProcedure);
        T Update<T>(string sp, DynamicParameters parms,
            CommandType commandType = CommandType.StoredProcedure);

    }
}
