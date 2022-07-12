using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CPMS.Models;
using CPMS.Services;
using System.Data.SqlClient;
namespace CPMS.Services
{
    public class ModifyData
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        //List<AuthorModel> authors = new List<AuthorModel>();
        //List<ReviewModel> reviews = new List<ReviewModel>();

        public ModifyData()
        {
            con.ConnectionString = CPMS.Properties.Resources.ConnectionString;
        }


        //function to ModifyAuthorData takes in AuthorModel class type author
        //lots of boiler plate code to open connection...set connection to command...execute sql command
        public void ModifyAuthorData(AuthorModel author)
        {
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText =   "UPDATE " +
                                    "[CPMS].[dbo].[Author] " +
                                    "SET " +
                                    "FirstName = '" + author.FirstName + "', " +
                                    "MiddleInitial = '" + author.MiddleInitial + "', " +
                                    "LastName = '" + author.LastName + "', " +
                                    "Affiliation = '" + author.Affiliation + "', " +
                                    "Department = '" + author.Department + "', " +
                                    "Address = '" + author.Address + "', " +
                                    "City = '" + author.City + "', " +
                                    "State = '" + author.State + "', " +
                                    "ZipCode = '" + author.ZipCode + "', " +
                                    "PhoneNumber = '" + author.PhoneNumber + "' " +
                                    "WHERE " +
                                    "AuthorID='" + author.AuthorID + "'";
                com.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ModifyReviewData(ReviewModel review)
        {
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "UPDATE " +
                                    "[CPMS].[dbo].[Review] " +
                                    "SET " +
                                    "AppropriatenessOfTopic = '" + review.AppropriatenessOfTopic + "', " +
                                    "TimelinessOfTopic = '" + review.TimelinessOfTopic + "', " +
                                    "SupportiveEvidence = '" + review.SupportiveEvidence + "', " +
                                    "TechnicalQuality = '" + review.TechnicalQuality + "', " +
                                    "ScopeOfCoverage = '" + review.ScopeOfCoverage + "', " +
                                    "CitationOfPreviousWork = '" + review.CitationOfPreviousWork + "', " +
                                    "Originality = '" + review.Originality + "', " +
                                    "ContentComments = '" + review.ContentComments + "', " +
                                    "OrganizationOfPaper = '" + review.OrganizationOfPaper + "', " +
                                    "ClarityOfMainMessage = '" + review.ClarityOfMainMessage + "', " +
                                    "Mechanics = '" + review.Mechanics + "', " +
                                    "WrittenDocumentComments = '" + review.WrittenDocumentComments + "', " +
                                    "SuitabilityForPresentation = '" + review.SuitabilityForPresentation + "', " +
                                    "PotentialInterestInTopic = '" + review.PotentialInterestInTopic + "', " +
                                    "PotentialForOralPresentationComments = '" + review.PotentialForOralPresentationComments + "', " +
                                    "OverallRating = '" + review.OverallRating + "', " +
                                    "OverallRatingComments = '" + review.OverallRatingComments + "', " +
                                    "ComfortLevelTopic = '" + review.ComfortLevelTopic + "', " +
                                    "ComfortLevelAcceptability = '" + review.ComfortLevelAcceptability + "', " +
                                    "Complete = '" + review.Complete + "' " +
                                    "WHERE " +
                                    "ReviewID=" + review.ReviewID + "";
                com.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //function to modify review where ReviewID 
        //lots of boiler plate code to open connection...set connection to command...execute sql command
        public ReviewModel ModifyReview(string ReviewID)
        {
            ReviewModel model = new ReviewModel();
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = com.CommandText = "SELECT " +
                                                    "[ReviewID], " +
                                                    "[AppropriatenessOfTopic], " +
                                                    "[TimelinessOfTopic], " +
                                                    "[SupportiveEvidence], " +
                                                    "[TechnicalQuality], " +
                                                    "[ScopeOfCoverage], " +
                                                    "[CitationOfPreviousWork], " +
                                                    "[Originality], " +
                                                    "[ContentComments], " +
                                                    "[OrganizationOfPaper], " +
                                                    "[ClarityOfMainMessage], " +
                                                    "[Mechanics], " +
                                                    "[WrittenDocumentComments], " +
                                                    "[SuitabilityForPresentation], " +
                                                    "[PotentialInterestInTopic], " +
                                                    "[PotentialForOralPresentationComments], " +
                                                    "[OverallRating], " +
                                                    "[OverallRatingComments], " +
                                                    "[ComfortLevelTopic], " +
                                                    "[ComfortLevelAcceptability], " +
                                                    "[Complete] " +
                                                    "FROM " +
                                                    "[CPMS].[dbo].[Review] " +
                                                    "WHERE " +
                                                    "ReviewID='" + ReviewID + "'";


                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    //Storing row elements in ViewBag variables
                    //ViewBag variables set as default values in ModifyAuthor view
                    model.ReviewID = dr["ReviewID"].ToString();
                    model.AppropriatenessOfTopic = dr["AppropriatenessOfTopic"].ToString();
                    model.TimelinessOfTopic = dr["TimelinessOfTopic"].ToString();
                    model.SupportiveEvidence = dr["SupportiveEvidence"].ToString();
                    model.TechnicalQuality = dr["TechnicalQuality"].ToString();
                    model.ScopeOfCoverage = dr["ScopeOfCoverage"].ToString();
                    model.CitationOfPreviousWork = dr["CitationOfPreviousWork"].ToString();
                    model.Originality = dr["Originality"].ToString();
                    model.ContentComments = dr["ContentComments"].ToString();
                    model.OrganizationOfPaper = dr["OrganizationOfPaper"].ToString();
                    model.ClarityOfMainMessage = dr["ClarityOfMainMessage"].ToString();
                    model.Mechanics = dr["Mechanics"].ToString();
                    model.WrittenDocumentComments = dr["WrittenDocumentComments"].ToString();
                    model.SuitabilityForPresentation = dr["SuitabilityForPresentation"].ToString();
                    model.PotentialInterestInTopic = dr["PotentialInterestInTopic"].ToString();
                    model.PotentialForOralPresentationComments = dr["PotentialForOralPresentationComments"].ToString();
                    model.OverallRating = dr["OverallRating"].ToString();
                    model.OverallRatingComments = dr["OverallRatingComments"].ToString();
                    model.ComfortLevelTopic = dr["ComfortLevelTopic"].ToString();
                    model.ComfortLevelAcceptability = dr["ComfortLevelAcceptability"].ToString();
                    model.Complete = dr["Complete"].ToString();

                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        //function to modify author where AuthID 
        //lots of boiler plate code to open connection...set connection to command...execute sql command
        public AuthorModel ModifyAuthor(string AuthID)
        {
            AuthorModel model = new AuthorModel();
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = com.CommandText = "SELECT " +
                                                    "[AuthorID]," +
                                                    "[FirstName]," +
                                                    "[MiddleInitial]," +
                                                    "[LastName]," +
                                                    "[Affiliation]," +
                                                    "[Department]," +
                                                    "[Address]," +
                                                    "[City]," +
                                                    "[State]," +
                                                    "[ZipCode]," +
                                                    "[PhoneNumber], " +
                                                    "[EmailAddress], " +
                                                    "[Password] " +
                                                    "FROM " +
                                                    "[CPMS].[dbo].[Author] " +
                                                    "WHERE " +
                                                    "AuthorID='" + AuthID + "'";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    //Storing row elements in ViewBag variables
                    //ViewBag variables set as default values in ModifyAuthor view
                    model.AuthorID = dr["AuthorID"].ToString();
                    model.FirstName = dr["FirstName"].ToString();
                    model.MiddleInitial = dr["MiddleInitial"].ToString();
                    model.LastName = dr["LastName"].ToString();
                    model.Affiliation = dr["Affiliation"].ToString();
                    model.Department = dr["Department"].ToString();
                    model.Address = dr["Address"].ToString();
                    model.City = dr["City"].ToString();
                    model.State = dr["State"].ToString();
                    model.ZipCode = dr["ZipCode"].ToString();
                    model.PhoneNumber = dr["PhoneNumber"].ToString();
                    model.EmailAddress = dr["EmailAddress"].ToString();
                    model.Password = dr["Password"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public void ModifyReviewerData(ReviewerModel reviewer)
        {
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "UPDATE " +
                                    "[CPMS].[dbo].[Reviewer] " +
                                    "SET " +
                                    "FirstName = '" + reviewer.FirstName + "', " +
                                    "MiddleInitial = '" + reviewer.MiddleInitial + "', " +
                                    "LastName = '" + reviewer.LastName + "', " +
                                    "Affiliation = '" + reviewer.Affiliation + "', " +
                                    "Department = '" + reviewer.Department + "', " +
                                    "Address = '" + reviewer.Address + "', " +
                                    "City = '" + reviewer.City + "', " +
                                    "State = '" + reviewer.State + "', " +
                                    "ZipCode = '" + reviewer.ZipCode + "', " +
                                    "PhoneNumber = '" + reviewer.PhoneNumber + "', " +
                                    "EmailAddress = '" + reviewer.EmailAddress + "', " +
                                    "Password = '" + reviewer.Password + "' " +
                                    "WHERE " +
                                    "ReviewerID='" + reviewer.ReviewerID + "'";
                com.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //function to modify author where ModifyReviewer
        //lots of boiler plate code to open connection...set connection to command...execute sql command
        public ReviewerModel ModifyReviewer(string ReviewerID)
        {
            ReviewerModel model = new ReviewerModel();
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = com.CommandText = "SELECT " +
                                                    "[ReviewerID]," +
                                                    "[FirstName]," +
                                                    "[MiddleInitial]," +
                                                    "[LastName]," +
                                                    "[Affiliation]," +
                                                    "[Department]," +
                                                    "[Address]," +
                                                    "[City]," +
                                                    "[State]," +
                                                    "[ZipCode]," +
                                                    "[PhoneNumber], " +
                                                    "[EmailAddress], " +
                                                    "[Password] " +
                                                    "FROM " +
                                                    "[CPMS].[dbo].[Reviewer] " +
                                                    "WHERE " +
                                                    "ReviewerID='" + ReviewerID + "'";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    //Storing row elements in ViewBag variables
                    //ViewBag variables set as default values in ModifyAuthor view
                    model.ReviewerID = dr["ReviewerID"].ToString();
                    model.FirstName = dr["FirstName"].ToString();
                    model.MiddleInitial = dr["MiddleInitial"].ToString();
                    model.LastName = dr["LastName"].ToString();
                    model.Affiliation = dr["Affiliation"].ToString();
                    model.Department = dr["Department"].ToString();
                    model.Address = dr["Address"].ToString();
                    model.City = dr["City"].ToString();
                    model.State = dr["State"].ToString();
                    model.ZipCode = dr["ZipCode"].ToString();
                    model.PhoneNumber = dr["PhoneNumber"].ToString();
                    model.EmailAddress = dr["EmailAddress"].ToString();
                    model.Password = dr["Password"].ToString();

                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public void SetDefaultTable(DefaultModel model)
        {
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "UPDATE " +
                                    "[CPMS].[dbo].[Defaults] " +
                                    "SET " +
                                    "EnabledReviewers = '" + model.EnableReviewers + "', " +
                                    "EnabledAuthors = '" + model.EnableAuthors + "' ";
                com.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
