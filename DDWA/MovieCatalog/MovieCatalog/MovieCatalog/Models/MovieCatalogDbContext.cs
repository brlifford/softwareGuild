﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCatalog.Models
{
    public class MovieCatalogDbContext : IdentityDbContext<AppUser>
    {
        public MovieCatalogDbContext() : base("MovieCatalog")
        {

        }
    }
}