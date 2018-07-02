using APIRestTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Data.Entity;
using APIRestTest.Core;
using APIRestTest.ViewModels;

namespace APIRestTest.Controllers
{
    public class ReviewsController: ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] ReviewViewModel review)
        {
            using (var context = new ProjectContext())
            {
                var book = await context.Books.FirstOrDefaultAsync(b => b.Id == review.BookId);
                if (book == null)
                {
                    return NotFound();
                }

                var newReview = context.Reviews.Add(new Review
                {
                    BookId = book.Id,
                    Description = review.Description,
                    Rating = review.Rating
                });

                await context.SaveChangesAsync();
                return Ok(new ReviewViewModel(newReview));
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            using (var context = new ProjectContext())
            {
                var review = await context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
                if (review == null)
                {
                    return NotFound();
                }

                context.Reviews.Remove(review);
                await context.SaveChangesAsync();
            }
            return Ok();
        }
    }
}