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

        public IActionResult Index()
        {
            tempReviews = requestData.FetchReviewData();

            //before we return we need to edit the reviews list of models
            foreach(ReviewModel review in tempReviews)
            {
                if (review.ReviewerID == UserModel.userID)
                    reviews.Add(review);
            } 

            return View(reviews);
        }

        public IActionResult openReview(string ReviewID, string ReviewerID)
        {
            ViewBag.ReviewID = ReviewID;
            return View();   
        }

        public IActionResult submitReview(ReviewModel review)
        {
            ModifyData.ModifyReviewData(review);
            return RedirectToAction("Index");
            

        }

    }
}
