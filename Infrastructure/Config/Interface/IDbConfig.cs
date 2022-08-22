using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config.Interface
{
    public interface IDbConfig
    {
        public string GetConnectionString();
        public SqlDataReader ExecuteStoredProcedureWithParameters(string procedureName, Dictionary<string, object> parameters);
        public void ExecuteStoredProcedure(string procedureName, Dictionary<string, object> parameters);
    }
}
