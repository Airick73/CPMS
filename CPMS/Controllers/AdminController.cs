using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        ModifyData ModifyData = new ModifyData();
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
            List<ReportModel> reports = new List<ReportModel>();
            reports = requestData.FetchReportData(); 
            return View(reports);
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

        public IActionResult ModifyAuthorData(AuthorModel author)
        {
            ModifyData.ModifyAuthorData(author);   
            return View("Index");
        }

        public IActionResult ModifyReviewData(ReviewModel review)
        {
            ModifyData.ModifyReviewData(review);
            return View("Index");
        }

        //function to modify review where ReviewID 
        //lots of boiler plate code to open connection...set connection to command...execute sql command
        public IActionResult ModifyReview(string ReviewID)
        {
            ReviewModel model = new ReviewModel();
            model = ModifyData.ModifyReview(ReviewID);

            //Storing row elements in ViewBag variables
            //ViewBag variables set as default values in ModifyAuthor view
            ViewBag.ReviewID = model.ReviewID;
            ViewBag.AppropriatenessOfTopic = model.AppropriatenessOfTopic;
            ViewBag.TimelinessOfTopic = model.TimelinessOfTopic;
            ViewBag.SupportiveEvidence = model.SupportiveEvidence;
            ViewBag.TechnicalQuality = model.TechnicalQuality;
            ViewBag.ScopeOfCoverage = model.ScopeOfCoverage;
            ViewBag.CitationOfPreviousWork = model.CitationOfPreviousWork;
            ViewBag.Originality = model.Originality;
            ViewBag.ContentComments = model.ContentComments;
            ViewBag.OrganizationOfPaper = model.OrganizationOfPaper;
            ViewBag.ClarityOfMainMessage = model.ClarityOfMainMessage;
            ViewBag.Mechanics = model.Mechanics;
            ViewBag.WrittenDocumentComments = model.WrittenDocumentComments;
            ViewBag.SuitabilityForPresentation = model.SuitabilityForPresentation;
            ViewBag.PotentialInterestInTopic = model.PotentialInterestInTopic;
            ViewBag.PotentialForOralPresentationComments = model.PotentialForOralPresentationComments;
            ViewBag.OverallRating = model.OverallRating;
            ViewBag.OverallRatingComments = model.OverallRatingComments;
            ViewBag.ComfortLevelTopic = model.ComfortLevelTopic;
            ViewBag.ComfortLevelAcceptability = model.ComfortLevelAcceptability;
            ViewBag.Complete = model.Complete;
            return View();
        }


        public IActionResult ModifyAuthor(string AuthID)
        {
            AuthorModel model = new AuthorModel();
            model = ModifyData.ModifyAuthor(AuthID);

            //Storing row elements in ViewBag variables
            //ViewBag variables set as default values in ModifyAuthor view
            ViewBag.AuthorID = model.AuthorID;
            ViewBag.FirstName = model.FirstName;
            ViewBag.MiddleInitial = model.MiddleInitial;
            ViewBag.LastName = model.LastName;
            ViewBag.Affiliation = model.Affiliation;
            ViewBag.Department = model.Department;
            ViewBag.Address = model.Address;
            ViewBag.City = model.City;
            ViewBag.State = model.State;
            ViewBag.ZipCode = model.ZipCode;
            ViewBag.PhoneNumber = model.PhoneNumber;
            ViewBag.EmailAddress = model.EmailAddress;
            ViewBag.Password = model.Password;

            return View();
        }




        //Boiler plate code 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}