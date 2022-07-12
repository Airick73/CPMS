using CPMS.Models;
using CPMS.Services;
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

        ModifyData ModifyData = new ModifyData();
        GetData requestData = new GetData();
        List<ReviewModel> tempReviews = new List<ReviewModel>();
        List<ReviewModel> reviews = new List<ReviewModel>();
        List<PaperModel> papers = new List<PaperModel>();

        public ReviewerController()
        {
            con.ConnectionString = CPMS.Properties.Resources.ConnectionString;
        }

        public IActionResult Index()
        {
       
            tempReviews = requestData.FetchReviewData();

            //before we return we need to edit the reviews list of models
            foreach(ReviewModel review in tempReviews)
            {
                if (review.ReviewerID == UserModel.userID)
                    reviews.Add(review);
            }

            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT FilenameOriginal, PaperID FROM [CPMS].[dbo].[Paper]";            
                dr = com.ExecuteReader();

                while (dr.Read())
                {
                    foreach(ReviewModel review in reviews)
                    {
                        if (review.PaperID == Int32.Parse(dr["PaperID"].ToString()))
                        {
                            papers.Add(new PaperModel()
                            {
                               FilenameOriginal = dr["FilenameOriginal"].ToString()
                            });
                        }
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ViewBag.list = papers;

            return View(reviews);
        } 

        public IActionResult openReview(string ReviewID, string ReviewerID)
        {
            if (requestData.FetchEnableReviewers())
            {
                ViewBag.ReviewID = ReviewID;
                return View();
            }
            else
            {
                return View("disabled");
            }
            
        }

        public IActionResult submitReview(ReviewModel review)
        {
            ModifyData.ModifyReviewData(review);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditReviewerInfo()
        {
            ReviewerModel model = new ReviewerModel();
            ModifyData ModifyData = new ModifyData();
            model = ModifyData.ModifyReviewer((UserModel.userID).ToString());

            //Storing row elements in ViewBag variables
            //ViewBag variables set as default values in ModifyAuthor view
            ViewBag.ReviewerID = model.ReviewerID;
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
        public IActionResult EditReviewerInfo(ReviewerModel reviewer)
        {
            ModifyData ModifyData = new ModifyData();
            ModifyData.ModifyReviewerData(reviewer);
            return RedirectToAction("Index");
        }

    }
}
