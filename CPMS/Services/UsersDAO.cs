using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CPMS.Models;
using System.Data.SqlClient;

namespace CPMS.Services
{
    public class UsersDAO
    {
        string connectionString = CPMS.Properties.Resources.ConnectionString;

        public void FindUserByEmailAndPassword()
        {

            string sqlAuthorStatement = "SELECT * FROM [CPMS].[dbo].[Author] WHERE EmailAddress = @username AND Password = @password";
            string sqlReviewerStatement = "SELECT * FROM [CPMS].[dbo].[Reviewer] WHERE EmailAddress = @username AND Password = @password";

            using(SqlConnection connection =new SqlConnection(connectionString))
            {
                SqlCommand authorCommand = new SqlCommand(sqlAuthorStatement, connection);
                SqlCommand reviewerCommand = new SqlCommand(sqlReviewerStatement, connection);


                authorCommand.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 100).Value = UserModel.EmailAddress;
                authorCommand.Parameters.Add("@password", System.Data.SqlDbType.NVarChar, 50).Value = UserModel.Password;

                reviewerCommand.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 100).Value = UserModel.EmailAddress;
                reviewerCommand.Parameters.Add("@password", System.Data.SqlDbType.NVarChar, 50).Value = UserModel.Password;

                UserModel.valid = false;
                
                try
                {
                    connection.Open();
                    SqlDataReader reader = authorCommand.ExecuteReader();

                    if(reader.HasRows){
                        reader.Read();
                        UserModel.userID = Int32.Parse(reader["AuthorID"].ToString());
                        UserModel.userType = false;
                        UserModel.valid = true; 
                    }
                    connection.Close();

                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                try
                {
                    connection.Open();
                    SqlDataReader reader = reviewerCommand.ExecuteReader();
 
                    if (reader.HasRows) 
                    {
                        reader.Read();
                        UserModel.userID = Int32.Parse(reader["ReviewerID"].ToString());
                        UserModel.userType = true;
                        UserModel.valid = true;
                    }
                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

        }
    }
}
