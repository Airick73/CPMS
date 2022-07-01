using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CPMS.Models;
using System.Data.SqlClient;
namespace CPMS.Controllers
{
    public class HomeController : Controller
    {
        SqlCommand com = new SqlCommand(); 
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<AuthorModel> authors = new List<AuthorModel>();
        List<ReviewModel> reviews = new List<ReviewModel>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            con.ConnectionString = CPMS.Properties.Resources.ConnectionString;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TableMaintenance()
        {
            FetchAuthorData();
            return View(authors);
        }

        public IActionResult BridgeTableMaintenance()
        {
            return View();
        }

        public IActionResult Report()
        {
            return View();
        }

        public IActionResult AddAuthor()
        {
            return View();
        }

        public IActionResult AddReview()
        {
            return View();
        }

        public IActionResult AddAuthorData(AuthorModel author)
        {
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "INSERT INTO Author (FirstName, MiddleInitial, LastName, Affiliation, Department, Address, City, State, ZipCode, PhoneNumber, EmailAddress, Password) VALUES ('" + author.FirstName + "', '" + author.MiddleInitial + "', '" + author.LastName + "', '" + author.Affiliation + "', '" + author.Department + "', '" + author.Address + "', '" + author.City + "', '" + author.State + "', '" + author.ZipCode + "', '" + author.PhoneNumber + "', '" + author.EmailAddress + "','" + author.Password + "')";
                com.ExecuteReader();
                con.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return View("Index");
        }

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

            return View("Index");
        }

        public IActionResult ModifyAuthor(string AuthID)
        {
            ViewBag.test1 = AuthID;
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT [AuthorID],[FirstName],[MiddleInitial],[LastName],[Affiliation],[Department],[Address],[City],[State],[ZipCode],[PhoneNumber], [EmailAddress], [Password] FROM [CPMS].[dbo].[Author] WHERE AuthorID='"+AuthID+"'";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
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

        public IActionResult ModifyAuthorData(AuthorModel author)
        {
            ViewBag.test = ViewBag.AuthorID;
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



        private void FetchAuthorData()
        {
            if (authors.Count > 0)
            {
                authors.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) [AuthorID],[FirstName],[MiddleInitial],[LastName],[Affiliation],[Department],[Address],[City],[State],[ZipCode],[PhoneNumber] FROM [CPMS].[dbo].[Author]";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    authors.Add(new AuthorModel()
                    {
                        AuthorID = dr["AuthorID"].ToString()
                    ,
                        FirstName = dr["FirstName"].ToString()
                    ,
                        MiddleInitial = dr["MiddleInitial"].ToString()
                    ,
                        LastName = dr["LastName"].ToString()
                    ,
                        Affiliation = dr["Affiliation"].ToString()
                    ,
                        Department = dr["Department"].ToString()
                    ,
                        Address = dr["Address"].ToString()
                    ,
                        City = dr["City"].ToString()
                    ,
                        State = dr["State"].ToString()
                    ,
                        ZipCode = dr["ZipCode"].ToString()
                    ,
                        PhoneNumber = dr["PhoneNumber"].ToString()

                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FetchReviewData()
        {
            if (reviews.Count > 0)
            {
                reviews.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) [ReviewID], [PaperID], [ReviewerID], [AppropriatenessOfTopic], [TimelinessOfTopic], [SupportiveEvidence], [TechnicalQuality], [ScopeOfCoverage], [CitationOfPreviousWork], [Originality], [ContentComments], [OrganizationOfPaper], [ClarityOfMainMessage], [Mechanics], [WrittenDocumentComments], [SuitabilityForPresentation], [PotentialInterestInTopic], [PotentialForOralPresentationComments], [OverallRating], [OverallRatingComments], [ComfortLevelTopic], [ComfortLevelAcceptability], [Complete] FROM [CPMS].[dbo].[Review]";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    reviews.Add(new ReviewModel()
                    {
                        ReviewID = dr["ReviewID"].ToString()
                    ,
                        PaperID = dr["PaperID"].ToString()
                    ,
                        ReviewerID = dr["ReviewerID"].ToString()
                    ,
                        AppropriatenessOfTopic = dr["AppropriatenessOfTopic"].ToString()
                        //CONTINUE HERE
                    ,
                        Affiliation = dr["Affiliation"].ToString()
                    ,
                        Department = dr["Department"].ToString()
                    ,
                        Address = dr["Address"].ToString()
                    ,
                        City = dr["City"].ToString()
                    ,
                        State = dr["State"].ToString()
                    ,
                        ZipCode = dr["ZipCode"].ToString()
                    ,
                        PhoneNumber = dr["PhoneNumber"].ToString()

                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}