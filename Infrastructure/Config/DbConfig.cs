﻿using System;
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
        public DataTable ExecuteReader(string procedureName, Dictionary<string, object> parameters)
        {
            try
            {
                var dt = new DataTable();

                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {

                    using (SqlDataAdapter cmd = new SqlDataAdapter(procedureName, con))
                    {
                        cmd.SelectCommand.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                        {
                            foreach (KeyValuePair<string, object> kvp in parameters)
                            { 
                                cmd.SelectCommand.Parameters.Add(new SqlParameter(kvp.Key, kvp.Value));
                            }
                        }

                        con.Open();

                        cmd.Fill(dt);

                        con.Close();
                        return dt;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ExecuteNonQuery(string procedureName, Dictionary<string, object> parameters)
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
