using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgiltProjektarbete
{
    public class ReviewController : Controller
    {
        private readonly ApplicationContext context;
        private readonly UserManager<User> userManager;

        public ReviewController(ApplicationContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [Authorize]
        [Route("{controller}/AddReview")]
        public ActionResult AddReview([FromBody]AddReviewModel model)
        {
            if (model.CustomerReview)
            {
                var review = new CustomerReview();
                var result = context.Users.Single(u => u.Id == model.CustomerId);
                review.Id = Guid.NewGuid().ToString();
                review.Message = model.Message;
                review.Author = context.Restaurants.Single(r => r.Id == model.RestaurantId);
                review.Customer = result;
                context.CustomerReviews.Add(review);
                context.SaveChanges();
            } else
            {
                var review = new RestaurantReview();
                var result = userManager.GetUserAsync(User).Result;
                review.Id = Guid.NewGuid().ToString();
                review.Message = model.Message;
                review.Author = result.FirstName + " " + result.LastName;
                review.Restaurant = context.Restaurants.Single(r => r.Id == model.RestaurantId);
                context.RestaurantReviews.Add(review);
                context.SaveChanges();
            }
            return new OkResult();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}