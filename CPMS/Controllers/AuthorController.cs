using CPMS.Models;
using CPMS.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

namespace CPMS.Controllers
{
    public class AuthorController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<PaperModel> papers = new List<PaperModel>();
        private readonly ILogger<AuthorController> _logger;
        GetData requestData = new GetData();

        IHostingEnvironment _hostingEnvironment = null;


        public AuthorController(ILogger<AuthorController> logger, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            con.ConnectionString = CPMS.Properties.Resources.ConnectionString;
            _hostingEnvironment = hostingEnvironment;
        }

        //Index page of author
        [HttpGet]
        public IActionResult Index()
        {
            if (requestData.FetchEnableAuthors()) { return View(); }
            else { return View("disabled"); }
        }

        [HttpPost]
        public IActionResult Index(PaperModel paper, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            string paperName = paper.PaperPdf.FileName;
            string uniquePaperName = Guid.NewGuid().ToString() + "_" + paperName;
            string fileName = $"{hostingEnvironment.WebRootPath}\\static\\{paper.PaperPdf.FileName}";
            using(FileStream fileStream = System.IO.File.Create(fileName))
            {
                paper.PaperPdf.CopyTo(fileStream);
                fileStream.Flush();
            }

            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "INSERT INTO Paper " +
                                    "(AuthorID, " +
                                    "FilenameOriginal, " +
                                    "Filename, " +
                                    "Title, " +
                                    "Certification, " +
                                    "NotesToReviewers, " +
                                    "AnalysisOfAlgorithms, " +
                                    "Applications, " +
                                    "Architecture, " +
                                    "ArtificialIntelligence, " +
                                    "ComputerEngineering, " +
                                    "Curriculum, " +
                                    "DataStructures, " +
                                    "Databases, " +
                                    "DistanceLearning, " +
                                    "DistributedSystems, " +
                                    "EthicalSocietalIssues, " +
                                    "FirstYearComputing, " +
                                    "GenderIssues, " +
                                    "GrantWriting, " +
                                    "GraphicsImageProcessing, " +
                                    "HumanComputerInteraction, " +
                                    "LaboratoryEnvironments, " +
                                    "Literacy, " +
                                    "MathematicsInComputing, " +
                                    "Multimedia, " +
                                    "NetworkingDataCommunications, " +
                                    "NonMajorCourses, " +
                                    "ObjectOrientedIssues, " +
                                    "OperatingSystems, " +
                                    "ParallelProcessing, " +
                                    "Pedagogy, " +
                                    "ProgrammingLanguages, " +
                                    "Research, " +
                                    "Security, " +
                                    "SoftwareEngineering, " +
                                    "SystemsAnalysisAndDesign, " +
                                    "UsingTechnologyInTheClassroom, " +
                                    "WebAndInternetProgramming, " +
                                    "Other, " +
                                    "OtherDescription) " +
                                    "VALUES " +
                                    "('" + paper.AuthorID + "', " +
                                    "'" + uniquePaperName + "', " +
                                    "'" + paperName + "', " +
                                    "'" + paper.Title + "', " +
                                    "'" + paper.Certification + "', " +
                                    "'" + paper.NotesToReviewers + "', " +
                                    "'" + paper.AnalysisOfAlgorithms + "', " +
                                    "'" + paper.Applications + "', " +
                                    "'" + paper.Architecture + "', " +
                                    "'" + paper.ArtificialIntelligence + "', " +
                                    "'" + paper.ComputerEngineering + "', " +
                                    "'" + paper.Curriculum + "'," +
                                    "'" + paper.DataStructures + "'," +
                                    "'" + paper.Databases + "'," +
                                    "'" + paper.DistanceLearning + "'," +
                                    "'" + paper.DistributedSystems + "'," +
                                    "'" + paper.EthicalSocietalIssues + "'," +
                                    "'" + paper.FirstYearComputing + "'," +
                                    "'" + paper.GenderIssues + "'," +
                                    "'" + paper.GrantWriting + "'," +
                                    "'" + paper.GraphicsImageProcessing + "', " +
                                    "'" + paper.HumanComputerInteraction + "', " +
                                    "'" + paper.LaboratoryEnvironments + "', " +
                                    "'" + paper.Literacy + "', " +
                                    "'" + paper.MathematicsInComputing + "', " +
                                    "'" + paper.Multimedia + "', " +
                                    "'" + paper.NetworkingDataCommunications + "', " +
                                    "'" + paper.NonMajorCourses + "', " +
                                    "'" + paper.ObjectOrientedIssues + "'," +
                                    "'" + paper.OperatingSystems + "'," +
                                    "'" + paper.ParallelProcessing + "'," +
                                    "'" + paper.Pedagogy + "'," +
                                    "'" + paper.ProgrammingLanguages + "'," +
                                    "'" + paper.Research + "'," +
                                    "'" + paper.Security + "'," +
                                    "'" + paper.SoftwareEngineering + "'," +
                                    "'" + paper.SystemsAnalysisAndDesign + "'," +
                                    "'" + paper.UsingTechnologyInTheClassroom + "', " +
                                    "'" + paper.WebAndInternetProgramming + "', " +
                                    "'" + paper.Other + "', " +
                                    "'" + paper.OtherDescription + "')";
                com.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View();

        }


        public IActionResult PaperSubmitted()
        {
            return View();
        }


        [HttpGet]
        public IActionResult EditAuthorInfo()
        {
            AuthorModel model = new AuthorModel();
            ModifyData ModifyData = new ModifyData();
            model = ModifyData.ModifyAuthor((UserModel.userID).ToString());

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

        [HttpPost]
        public IActionResult EditAuthorInfo(AuthorModel author)
        {
            ModifyData ModifyData = new ModifyData();
            ModifyData.ModifyAuthorData(author);
            return View("Index");
        }
    }
}
