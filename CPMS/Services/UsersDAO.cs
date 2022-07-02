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

        public int FindUserByEmailAndPassword(UserModel user)
        {
            int userLogin = 0;

            string sqlAuthorStatement = "SELECT * FROM [CPMS].[dbo].[Author] WHERE EmailAddress = @username AND Password = @password";
            string sqlReviewerStatement = "SELECT * FROM [CPMS].[dbo].[Author] WHERE EmailAddress = @username AND Password = @password";

            using(SqlConnection connection =new SqlConnection(connectionString))
            {
                SqlCommand authorCommand = new SqlCommand(sqlAuthorStatement, connection);
                SqlCommand reviewerCommand = new SqlCommand(sqlReviewerStatement, connection);


                authorCommand.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 100).Value = user.EmailAddress;
                authorCommand.Parameters.Add("@password", System.Data.SqlDbType.NVarChar, 50).Value = user.Password;

                reviewerCommand.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 100).Value = user.EmailAddress;
                reviewerCommand.Parameters.Add("@password", System.Data.SqlDbType.NVarChar, 50).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = authorCommand.ExecuteReader();

                    if(reader.HasRows){
                        userLogin = 1; //here we have successfully found the author
                    }
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
                        userLogin = 2; //here we have successfully found the reivewer
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return userLogin;
            }

        }
    }
}
