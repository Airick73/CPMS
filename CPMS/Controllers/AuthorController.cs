using CPMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CPMS.Controllers
{
    public class AuthorController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<PaperModel> papers = new List<PaperModel>();
        private readonly ILogger<AuthorController> _logger;


        public AuthorController(ILogger<AuthorController> logger)
        {
            _logger = logger;
            con.ConnectionString = CPMS.Properties.Resources.ConnectionString;
        }

        //Index page of author
        public IActionResult Index(UserModel user)
        {
            ViewBag.AuthorID = user.userID;
            ViewBag.Email = user.EmailAddress;
            return View();
        }

        public IActionResult AddPaperData(PaperModel paper)
        {
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
                                    "ParallelsProcessing, " +
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
                                    "'" + paper.FilenameOriginal + "', " +
                                    "'" + paper.Filename + "', " +
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
                                    "'" + paper.ParallelsProcessing + "'," +
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

            return View("Index");
        }
    }
}
