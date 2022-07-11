using CPMS.Models;
using CPMS.Services;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System;

namespace CPMS.Services
{
    public class GetPassword
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        
        public GetPassword()
        {
            con.ConnectionString = CPMS.Properties.Resources.ConnectionString;
        }

        public void SendEmail(string Email)
        {
            string password = "";
            bool emailFound = false;
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT [Password] FROM CPMS.dbo.Author WHERE [EmailAddress] = '" + Email + "';";

                dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    password = dr["Password"].ToString();
                    emailFound = true;
                }
                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (!emailFound)
            {
                try
                {
                    con.Open();
                    com.Connection = con;
                    com.CommandText = "SELECT [Password] FROM CPMS.dbo.Reviewer WHERE [EmailAddress] = '" + Email + "';";

                    dr = com.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        password = dr["Password"].ToString();
                        emailFound = true;
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            if (emailFound)
            {
                var smtpClient = new SmtpClient("smtp.office365.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("cpmsserver@outlook.com", "CPMSpassword!"),
                    EnableSsl = true,
                };

                smtpClient.Send("cpmsserver@outlook.com", Email, "Password Retrieval", "Email: " + Email + "\nPassword: " + password);
            }
        }
    }
}
