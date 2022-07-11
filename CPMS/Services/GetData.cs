using System;
using System.Collections.Generic;
using System.Linq;
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
        
        

        public GetData()
        {
            con.ConnectionString = CPMS.Properties.Resources.ConnectionString;
        }

        ////function to FetchReviewData called with BridgeTableMaintenace function to display table for reviews
        //lots of boiler plate code to open connection...set connection to command...execute sql command
        public List<ReviewModel> FetchReviewData()
        {
            List<ReviewModel> reviews = new List<ReviewModel>();
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
                        PaperID = Int32.Parse(dr["PaperID"].ToString()) //reader.GetInt32(3); ... dr.GetInt32("PaperID")
                    ,
                        ReviewerID = Int32.Parse(dr["ReviewerID"].ToString())
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


        //Fetch report data class to fetch average score of paper from all reviews
        //Find a paper ID
        //for all reviews that match that paper ID average the scores of the topic
        //store averages score in ReportModel
        //add report to list
        public List<ReportModel> FetchReportData()
        {
            List<ReportModel> reports = new List<ReportModel>();
            List<int> paperIDs = new List<int>();
            List<string> titles = new List<string>();
            try {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) " +
                                  "[PaperID]," +
                                  "[Title]" +
                                  "FROM " +
                                  "[CPMS].[dbo].[Paper]";
                dr = com.ExecuteReader();

                while (dr.Read())
                {
                    paperIDs.Add(Int32.Parse(dr["PaperID"].ToString()));
                    titles.Add(dr["Title"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            


            for (var i = 0; i < paperIDs.Count(); i++){
                ReportModel reportModel = new ReportModel { PaperID = paperIDs[i], Title = titles[i] }; //adding each of the paperIDs into the list
                reports.Add(reportModel);
            }

            List<ReviewModel> reviews = new List<ReviewModel>();
            reviews = FetchReviewData();
            foreach (ReviewModel review in reviews){ //for all reviews
                foreach(var report in reports){  //for all papers
                    if(review.PaperID == report.PaperID) //
                    {
                        report.total_score_AppropriatnessOfTopic += float.Parse(review.AppropriatenessOfTopic);
                        report.total_score_TimelinessOfTopic += float.Parse(review.TimelinessOfTopic);
                        report.total_score_SupportiveEvidence += float.Parse(review.SupportiveEvidence);
                        report.total_score_TechnicalQuality += float.Parse(review.TechnicalQuality);
                        report.total_score_ScopeOfCoverage += float.Parse(review.ScopeOfCoverage);
                        report.total_score_CitationOfPreviousWork += float.Parse(review.CitationOfPreviousWork);
                        report.total_score_Originality += float.Parse(review.Originality);
                        report.total_score_OrganizationOfPaper += float.Parse(review.OrganizationOfPaper);
                        report.total_score_ClarityOfMainMessage += float.Parse(review.ClarityOfMainMessage);
                        report.total_score_Mechanics += float.Parse(review.Mechanics);
                        report.total_score_SuitabilityForPresentation += float.Parse(review.SuitabilityForPresentation);
                        report.total_score_PotentialInterestInTopic += float.Parse(review.PotentialInterestInTopic);
                        report.total_score_OverallRating += float.Parse(review.OverallRating);
                        report.NumReviews++;
                    } //end if paper ID
                }//end for each report
            }//end for each review

            return reports;
        }//end FetchReportData function
    }//end class getData
}//end namespace
