﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CPMS.Models;
using CPMS.Services;
using System.Data.SqlClient;
namespace CPMS.Controllers
{
    public class AdminController : Controller
    {
        SqlCommand com = new SqlCommand(); 
        SqlDataReader dr; 
        SqlConnection con = new SqlConnection();
        List<AuthorModel> authors = new List<AuthorModel>();
        List<ReviewModel> reviews = new List<ReviewModel>();
        GetData requestData = new GetData();
        AddData AddData = new AddData();
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
            con.ConnectionString = CPMS.Properties.Resources.ConnectionString;
        }

        //Home page 
        public IActionResult Index()
        {
            return View();
        }

        //Author table page
        public IActionResult TableMaintenance()
        {
            authors = requestData.FetchAuthorData();
            return View(authors);
        }

        //Review table page
        public IActionResult BridgeTableMaintenance()
        {
            reviews = requestData.FetchReviewData();
            return View(reviews);
        }

        //Report page
        public IActionResult Report()
        {
            return View();
        }

        //Add review page
        public IActionResult AddReview()
        {
            return View();
        }

        public IActionResult AddReviewData(ReviewModel review)
        {
            AddData.AddReview(review);
            return View("Index");
        }

        //Add author page
        public IActionResult AddAuthor()
        {
            return View();
        }

        public IActionResult AddAuthorData(AuthorModel author)
        {
            AddData.AddAuthor(author);
            return View("Index");
        }


        //function that takes in AuthID from TableMaintenance view and writes query to Delete author where Auth ID 
        //lots of boiler plate code to open connection...set connection to command...execute sql command
        public IActionResult DeleteAuthorData(string AuthID)
        {
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "DELETE FROM Author WHERE AuthorID='"+ AuthID + "'";
                com.ExecuteReader();
                con.Close();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return View("Index"); //After delete return to home page
        }

        //function to modify author where AuthID 
        //lots of boiler plate code to open connection...set connection to command...execute sql command
        public IActionResult ModifyAuthor(string AuthID)
        {
            ViewBag.test1 = AuthID; //AuthID stored in ViewBag variable test1 ... may not need in final code
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = com.CommandText = "SELECT [AuthorID],[FirstName],[MiddleInitial],[LastName],[Affiliation],[Department],[Address],[City],[State],[ZipCode],[PhoneNumber], [EmailAddress], [Password] FROM [CPMS].[dbo].[Author] WHERE AuthorID='" + AuthID + "'";
                dr = com.ExecuteReader();
                while (dr.Read()) 
                {
                    //Storing row elements in ViewBag variables
                    //ViewBag variables set as default values in ModifyAuthor view
                    ViewBag.AuthorID = dr["AuthorID"].ToString();
                    ViewBag.FirstName = dr["FirstName"].ToString();
                    ViewBag.MiddleInitial = dr["MiddleInitial"].ToString();
                    ViewBag.LastName = dr["LastName"].ToString();
                    ViewBag.Affiliation = dr["Affiliation"].ToString();
                    ViewBag.Department = dr["Department"].ToString();
                    ViewBag.Address = dr["Address"].ToString();
                    ViewBag.City = dr["City"].ToString();
                    ViewBag.State = dr["State"].ToString();
                    ViewBag.ZipCode = dr["ZipCode"].ToString();
                    ViewBag.PhoneNumber = dr["PhoneNumber"].ToString();
                    ViewBag.EmailAddress = dr["EmailAddress"].ToString();
                    ViewBag.Password = dr["Password"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }

        //function to ModifyAuthorData takes in AuthorModel class type author
        //lots of boiler plate code to open connection...set connection to command...execute sql command
        public IActionResult ModifyAuthorData(AuthorModel author)
        {
            ViewBag.test = ViewBag.AuthorID; //AuthorID element stored in test ViewBag variable displayed on homepage...may not need in final code
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "UPDATE [CPMS].[dbo].[Author] SET FirstName = '" + author.FirstName + "', MiddleInitial = '" + author.MiddleInitial + "', LastName = '" + author.LastName + "', Affiliation = '" + author.Affiliation + "', Department = '" + author.Department + "', Address = '" + author.Address + "', City = '" + author.City + "', State = '" + author.State + "', ZipCode = '" + author.ZipCode + "', PhoneNumber = '" + author.PhoneNumber + "' WHERE AuthorID='" + author.AuthorID + "'";
                com.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View("Index");
        }

       

        //function that takes in ReviewID from BridgeTableMaintenance view and writes query to Delete review where ReviewID
        //lots of boiler plate code to open connection...set connection to command...execute sql command
        public IActionResult DeleteReviewData(string ReviewID)
        {
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "DELETE FROM Review WHERE ReviewID='" + ReviewID + "'";
                com.ExecuteReader();
                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View("Index"); //After delete return to home page
        }

        //function to modify review where ReviewID 
        //lots of boiler plate code to open connection...set connection to command...execute sql command
        public IActionResult ModifyReview(string ReviewID)
        {
            
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
                    ViewBag.ReviewID = dr["ReviewID"].ToString();
                    ViewBag.AppropriatenessOfTopic = dr["AppropriatenessOfTopic"].ToString();
                    ViewBag.TimelinessOfTopic = dr["TimelinessOfTopic"].ToString();
                    ViewBag.SupportiveEvidence = dr["SupportiveEvidence"].ToString();
                    ViewBag.TechnicalQuality = dr["TechnicalQuality"].ToString();
                    ViewBag.ScopeOfCoverage = dr["ScopeOfCoverage"].ToString();
                    ViewBag.CitationOfPreviousWork = dr["CitationOfPreviousWork"].ToString();
                    ViewBag.Originality = dr["Originality"].ToString();
                    ViewBag.ContentComments = dr["ContentComments"].ToString();
                    ViewBag.OrganizationOfPaper = dr["OrganizationOfPaper"].ToString();
                    ViewBag.ClarityOfMainMessage = dr["ClarityOfMainMessage"].ToString();
                    ViewBag.Mechanics = dr["Mechanics"].ToString();
                    ViewBag.WrittenDocumentComments = dr["WrittenDocumentComments"].ToString();
                    ViewBag.SuitabilityForPresentation = dr["SuitabilityForPresentation"].ToString();
                    ViewBag.PotentialInterestInTopic = dr["PotentialInterestInTopic"].ToString();
                    ViewBag.PotentialForOralPresentationComments = dr["PotentialForOralPresentationComments"].ToString();
                    ViewBag.OverallRating = dr["OverallRating"].ToString();
                    ViewBag.OverallRatingComments = dr["OverallRatingComments"].ToString();
                    ViewBag.ComfortLevelTopic = dr["ComfortLevelTopic"].ToString();
                    ViewBag.ComfortLevelAcceptability = dr["ComfortLevelAcceptability"].ToString();
                    ViewBag.Complete = dr["Complete"].ToString();

                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }

        public IActionResult ModifyReviewData(ReviewModel review)
        {
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText =   "UPDATE " +
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
                                    "ReviewID='" + review.ReviewID + "'";
                com.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View("Index");
        }

        //Boiler plate code 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}