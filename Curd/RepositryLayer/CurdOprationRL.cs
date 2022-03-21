

using Curd.CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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


        //Create Record ++++++++++++++++++++++++++++++ Create Record+++++++++++++++++++++++Create Record++++++++++++++++++
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

        
        //Read Record +++++++++++++++++++++++++++++++++Read Record ++++++++++++++++++++++++++++++++++++Read Record +++++++++++++++++
        public async Task<ReadRecord> ReadRecord()
        {
            ReadRecord responce = new ReadRecord();
            responce.IsSuccess = true;
            responce.Message = "Sucessfullllly";


            try
            {
                string SqlQuary = "Select UserName,age from CrudOprationTable";
                using (SqlCommand sqlCommand = new SqlCommand(SqlQuary, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    _sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            responce.readRecordData = new List<ReadRecordData>();
                            while (await sqlDataReader.ReadAsync())
                            {
                                ReadRecordData dbData = new ReadRecordData();
                                dbData.UserName = sqlDataReader[name: "UserName"] != DBNull.Value ? sqlDataReader[name: "UserName"].ToString() : String.Empty;
                                dbData.age = sqlDataReader[name: "age"] != DBNull.Value ? Convert.ToInt32(sqlDataReader[name: "age"]) : 0;
                                responce.readRecordData.Add(dbData);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                responce.IsSuccess = false;
                responce.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return responce;
        }


        // Update Record _____________Update Record ++++++++++++++++ Update Record +++++++++++
        public async Task<UpdateRecordResponse> updateRecord(UpdateRecordRequest request)

        {
            UpdateRecordResponse Response = new UpdateRecordResponse();
            Response.IsSucess = true;
            Response.Message = "Suceess";

            try
            {
                string sqlQuery = "Update CrudOprationTable set UserName=@UserName,age=@age where Id=@Id";

                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue(parameterName: "@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@age", request.age);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Id", request.Id);
                    _sqlConnection.Open();
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if (status <= 0)
                    {
                        Response.IsSucess = false;
                        Response.Message = "something went wrongr";
                    }
                }                
            }
            catch (Exception e)
            {
                Response.IsSucess = false;
                Response.Message = e.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return Response;
        }


        //Delete +++++++++++++  ++++++++++++++++   Delete +++++++++++++++++++++++ Delete
        public async Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request)
        {
            DeleteRecordResponse responce = new DeleteRecordResponse();
            responce.IsSucess = true;
            responce.Message = "Sucessfully";

            try
            {
                string sqlQuary = "Delete from CrudOprationTable Where Id=@Id";
                using(SqlCommand sqlCommand = new SqlCommand(sqlQuary, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    _sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Id",request.Id);

                    int status=await sqlCommand.ExecuteNonQueryAsync();
                    if (status <= 0)
                    { 
                       responce.IsSucess = false;
                        responce.Message = "Something went wronge ";
                    }

                }
            }
            catch(Exception e)
            {
                responce.IsSucess=false;
                responce.Message= "Exception Message : "+e.Message;

            }
            finally
            {
                _sqlConnection.Close();

            }

            return responce;
        }


    }
}
