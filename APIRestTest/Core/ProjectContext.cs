using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using APIRestTest.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace APIRestTest.Core
{

    public class ProjectContext: IdentityDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}