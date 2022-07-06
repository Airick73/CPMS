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
    public class GetData
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<AuthorModel> authors = new List<AuthorModel>();
        List<ReviewModel> reviews = new List<ReviewModel>();

        public GetData()
        {
            con.ConnectionString = CPMS.Properties.Resources.ConnectionString;
        }

        ////function to FetchReviewData called with BridgeTableMaintenace function to display table for reviews
        //lots of boiler plate code to open connection...set connection to command...execute sql command
        public List<ReviewModel> FetchReviewData()
        {
            if (reviews.Count > 0)
            {
                reviews.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) " +
                                  "[ReviewID], " +
                                  "[PaperID], " +
                                  "[ReviewerID], " +
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
                                  "[CPMS].[dbo].[Review]";
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
                    ,
                        TimelinessOfTopic = dr["TimelinessOfTopic"].ToString()
                    ,
                        SupportiveEvidence = dr["SupportiveEvidence"].ToString()
                    ,
                        TechnicalQuality = dr["TechnicalQuality"].ToString()
                    ,
                        ScopeOfCoverage = dr["ScopeOfCoverage"].ToString()
                    ,
                        CitationOfPreviousWork = dr["CitationOfPreviousWork"].ToString()
                    ,
                        Originality = dr["Originality"].ToString()
                    ,
                        ContentComments = dr["ContentComments"].ToString()
                    ,
                        OrganizationOfPaper = dr["OrganizationOfPaper"].ToString()
                    ,
                        ClarityOfMainMessage = dr["ClarityOfMainMessage"].ToString()
                    ,
                        Mechanics = dr["Mechanics"].ToString()
                    ,
                        WrittenDocumentComments = dr["WrittenDocumentComments"].ToString()
                    ,
                        SuitabilityForPresentation = dr["SuitabilityForPresentation"].ToString()
                    ,
                        PotentialInterestInTopic = dr["PotentialInterestInTopic"].ToString()
                    ,
                        PotentialForOralPresentationComments = dr["PotentialForOralPresentationComments"].ToString()
                    ,
                        OverallRating = dr["OverallRating"].ToString()
                    ,
                        OverallRatingComments = dr["OverallRatingComments"].ToString()
                    ,
                        ComfortLevelTopic = dr["ComfortLevelTopic"].ToString()
                    ,
                        ComfortLevelAcceptability = dr["ComfortLevelAcceptability"].ToString()
                    ,
                        Complete = dr["Complete"].ToString()
                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return reviews;
        }

        //function to FetchAuthorData called with TableMaintenance function to display table for authors
        //lots of boiler plate code to open connection...set connection to command...execute sql command
        public List<AuthorModel> FetchAuthorData()
        {
            if (authors.Count > 0)
            {
                authors.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) " +
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
                                  "[PhoneNumber] " +
                                  "FROM " +
                                  "[CPMS].[dbo].[Author]";
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

            return authors;
        }
    }
}
