using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestClient.Net;

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
        public async Task<ActionResult> AddReview([FromBody]AddReviewModel model)
        {
            var client = new Client(new Uri($"https://www.purgomalum.com/service/plain?text={model.Message}"));
            var response = await client.GetAsync<string>();

            var review = new RestaurantReview();
            var result = userManager.GetUserAsync(User).Result;
            review.Id = Guid.NewGuid().ToString();
            review.Message = response.Body;
            review.Author = result.FirstName + " " + result.LastName;
            review.Restaurant = context.Restaurants.Single(r => r.Id == model.RestaurantId);
            context.RestaurantReviews.Add(review);
            context.SaveChanges();
            return new OkResult();
        }
    }
}