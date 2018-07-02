using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APIRestTest.Migrations;
using System.Data.Entity;

namespace APIRestTest.Core
{
    

    public class Initializer: MigrateDatabaseToLatestVersion<ProjectContext, Configuration>
    {

    }
}

// DbMigrationsConfiguration<ProjectContext>
