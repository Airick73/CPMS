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
    public class AddData
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();

        public AddData()
        {
            con.ConnectionString = CPMS.Properties.Resources.ConnectionString;
        }

        public void AddReview(ReviewModel review)
        {
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "INSERT INTO Review " +
                                    "(PaperID, " +
                                    "ReviewerID) " +
                                    "VALUES " +
                                    "(" + review.PaperID + ", " +
                                          review.ReviewerID + ") ";

                com.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void AddReviewer(ReviewerModel reviewer)
        {
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "INSERT INTO Reviewer " +
                                    "(FirstName, " +
                                    "MiddleInitial, " +
                                    "LastName, " +
                                    "Affiliation, " +
                                    "Department, " +
                                    "Address, " +
                                    "City, " +
                                    "State, " +
                                    "ZipCode, " +
                                    "PhoneNumber, " +
                                    "EmailAddress, " +
                                    "Password, " +
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
                                    "('" + reviewer.FirstName + "', " +
                                    "'" + reviewer.MiddleInitial + "', " +
                                    "'" + reviewer.LastName + "', " +
                                    "'" + reviewer.Affiliation + "', " +
                                    "'" + reviewer.Department + "', " +
                                    "'" + reviewer.Address + "', " +
                                    "'" + reviewer.City + "', " +
                                    "'" + reviewer.State + "', " +
                                    "'" + reviewer.ZipCode + "', " +
                                    "'" + reviewer.PhoneNumber + "', " +
                                    "'" + reviewer.EmailAddress + "', " +
                                    "'" + reviewer.Password + "', " +
                                    "'" + reviewer.AnalysisOfAlgorithms + "', " +
                                    "'" + reviewer.Applications + "', " +
                                    "'" + reviewer.Architecture + "', " +
                                    "'" + reviewer.ArtificialIntelligence + "', " +
                                    "'" + reviewer.ComputerEngineering + "', " +
                                    "'" + reviewer.Curriculum + "'," +
                                    "'" + reviewer.DataStructures + "'," +
                                    "'" + reviewer.Databases + "'," +
                                    "'" + reviewer.DistanceLearning + "'," +//--------------------------
                                    "'" + reviewer.DistributedSystems + "'," +
                                    "'" + reviewer.EthicalSocietalIssues + "'," +
                                    "'" + reviewer.FirstYearComputing + "'," +
                                    "'" + reviewer.GenderIssues + "'," +
                                    "'" + reviewer.GrantWriting + "'," +
                                    "'" + reviewer.GraphicsImageProcessing + "', " +
                                    "'" + reviewer.HumanComputerInteraction + "', " +
                                    "'" + reviewer.LaboratoryEnvironments + "', " +
                                    "'" + reviewer.Literacy + "', " +
                                    "'" + reviewer.MathematicsInComputing + "', " +
                                    "'" + reviewer.Multimedia + "', " +
                                    "'" + reviewer.NetworkingDataCommunications + "', " +
                                    "'" + reviewer.NonMajorCourses + "', " +
                                    "'" + reviewer.ObjectOrientedIssues + "'," +
                                    "'" + reviewer.OperatingSystems + "'," +
                                    "'" + reviewer.ParallelProcessing + "'," +//------------------
                                    "'" + reviewer.Pedagogy + "'," +
                                    "'" + reviewer.ProgrammingLanguages + "'," +
                                    "'" + reviewer.Research + "'," +
                                    "'" + reviewer.Security + "'," +
                                    "'" + reviewer.SoftwareEngineering + "'," +
                                    "'" + reviewer.SystemsAnalysisAndDesign + "'," +
                                    "'" + reviewer.UsingTechnologyInTheClassroom + "', " +
                                    "'" + reviewer.WebAndInternetProgramming + "', " +
                                    "'" + reviewer.Other + "', " +
                                    "'" + reviewer.OtherDescription + "')";
                com.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void AddAuthor(AuthorModel author)
        {
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText =   "INSERT " +
                                    "INTO " +
                                    "Author " +
                                    "(FirstName, " +
                                    "MiddleInitial, " +
                                    "LastName, " +
                                    "Affiliation, " +
                                    "Department, " +
                                    "Address, " +
                                    "City, " +
                                    "State, " +
                                    "ZipCode, " +
                                    "PhoneNumber, " +
                                    "EmailAddress, " +
                                    "Password) " +
                                    "VALUES " +
                                    "('" + author.FirstName + "', " +
                                    "'" + author.MiddleInitial + "', " +
                                    "'" + author.LastName + "', " +
                                    "'" + author.Affiliation + "', " +
                                    "'" + author.Department + "', " +
                                    "'" + author.Address + "', " +
                                    "'" + author.City + "', " +
                                    "'" + author.State + "', " +
                                    "'" + author.ZipCode + "', " +
                                    "'" + author.PhoneNumber + "', " +
                                    "'" + author.EmailAddress + "', " +
                                    "'" + author.Password + "')";
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
