using CPMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CPMS.Controllers
{
    public class ReviewerController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        public IActionResult Index(UserModel user)
        {
            ViewBag.ReviewerID = user.userID;
            return View();
        }

        public IActionResult AddReviewData(ReviewModel review)
        {
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "INSERT INTO Review " +
                                    "(AppropriatenessOfTopic, " +
                                    "TimelinessOfTopic, " +
                                    "SupportiveEvidence, " +
                                    "TechnicalQuality, " +
                                    "ScopeOfCoverage, " +
                                    "CitationOfPreviousWork, " +
                                    "Originality, " +
                                    "ContentComments, " +
                                    "OrganizationOfPaper, " +
                                    "ClarityOfMainMessage, " +
                                    "Mechanics, " +
                                    "WrittenDocumentComments, " +
                                    "SuitabilityForPresentation, " +
                                    "PotentialInterestInTopic, " +
                                    "PotentialForOralPresentationComments, " +
                                    "OverallRating, " +
                                    "OverallRatingComments, " +
                                    "ComfortLevelTopic, " +
                                    "ComfortLevelAcceptability, " +
                                    "Complete) " +
                                    "VALUES " +
                                    "('" + review.AppropriatenessOfTopic + "', " +
                                    "'" + review.TimelinessOfTopic + "', " +
                                    "'" + review.SupportiveEvidence + "', " +
                                    "'" + review.TechnicalQuality + "', " +
                                    "'" + review.ScopeOfCoverage + "', " +
                                    "'" + review.CitationOfPreviousWork + "', " +
                                    "'" + review.Originality + "', " +
                                    "'" + review.ContentComments + "', " +
                                    "'" + review.OrganizationOfPaper + "', " +
                                    "'" + review.ClarityOfMainMessage + "', " +
                                    "'" + review.Mechanics + "'," +
                                    "'" + review.WrittenDocumentComments + "'," +
                                    "'" + review.SuitabilityForPresentation + "'," +
                                    "'" + review.PotentialInterestInTopic + "'," +
                                    "'" + review.PotentialForOralPresentationComments + "'," +
                                    "'" + review.OverallRating + "'," +
                                    "'" + review.OverallRatingComments + "'," +
                                    "'" + review.ComfortLevelTopic + "'," +
                                    "'" + review.ComfortLevelAcceptability + "'," +
                                    "'" + review.Complete + "')";
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
