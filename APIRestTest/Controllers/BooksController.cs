using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using APIRestTest.Core;

namespace APIRestTest.Controllers
{
    public class BooksController: ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            using (var context = new ProjectContext())
            {
                // return Ok(await context.Books.ToListAsync());
                // return Ok(await context.Books.Select(x =>  new { Id = x.Id, BookTitle = x.Title, BookDescription = x.Description, ReviewId = x.Reviews.Select(y => new { Id = y.Id}) }).ToListAsync());
                return Ok(await context.Books.Include(x => x.Reviews).AsNoTracking().ToListAsync());
            }
        }
    }
}