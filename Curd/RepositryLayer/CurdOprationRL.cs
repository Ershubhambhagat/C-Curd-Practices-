

using Curd.CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Curd.RepositryLayer
{

    public class CurdOprationRL : ICurdOprationRL
    {
        public readonly IConfiguration _configuration;
        public readonly SqlConnection _sqlConnection;

        public CurdOprationRL(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection = new SqlConnection(_configuration[key: "ConnectionStrings:DBSettingConnection"]);
        }
        public async Task<CreateReacordReasponce> CreateRecord(CreateRecordRequest request)
        {
            CreateReacordReasponce responce = new CreateReacordReasponce();
            responce.Issuccess = true;
            responce.Message = "Succesfully";
            try
            {
                string sqlquery = "Insert into CrudOprationTable (UserName,age) values(@UserName,@age)";
                using (SqlCommand sqlCommand = new SqlCommand(sqlquery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue(parameterName: "@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@age", request.age);
                    _sqlConnection.Open();
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if (status <= 0)
                    {
                        responce.Issuccess = false; ;
                        responce.Message = "Something wnt wroonge";
                    }
                }

            }
            catch (Exception ex)
            {
                responce.Issuccess = false;
                responce.Message = ex.Message;

            }
            finally
            {
                _sqlConnection.Close();
            }
            return responce;
        }

    }
}
