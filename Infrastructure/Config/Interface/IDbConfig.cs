using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config.Interface
{
    public interface IDbConfig
    {
        public string GetConnectionString();
        public DataTable ExecuteReader(string procedureName, Dictionary<string, object> parameters);
        public void ExecuteNonQuery(string procedureName, Dictionary<string, object> parameters);
    }
}
