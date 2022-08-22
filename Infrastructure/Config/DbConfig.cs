using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Config.Interface;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Config
{
    public class DbConfig : IDbConfig
    {

        private readonly IConfiguration _configuration;

        public DbConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SqlDataReader ExecuteStoredProcedureWithParameters(string procedureName, Dictionary<string, object> parameters)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand(procedureName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                        {
                            foreach (KeyValuePair<string, object> kvp in parameters)
                            { 
                                cmd.Parameters.Add(new SqlParameter(kvp.Key, kvp.Value));
                            }
                        }

                        con.Open();
                        var reader = cmd.ExecuteReader();
                        con.Close();
                        return reader;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ExecuteStoredProcedure(string procedureName, Dictionary<string, object> parameters)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                        {
                            foreach (KeyValuePair<string, object> kvp in parameters)
                            {
                                cmd.Parameters.Add(new SqlParameter(kvp.Key, kvp.Value));
                            }
                        }
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("Ecommerce");
        }
    }
}
