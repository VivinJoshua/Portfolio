using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class portfolioContext :DbContext
    {

        public portfolioContext() : base("name=ConnectionString") { }

        public DbSet<Works> Works { get; set; }
        public DbSet<filters> filters { get; set; }
        public DbSet<Login> Logins { get; set; }
    }
}