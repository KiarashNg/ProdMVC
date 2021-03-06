﻿using ProdMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProdMVC.DAL
{
    public class ProdMVCDBContext :DbContext
    {
        public ProdMVCDBContext()
            : base("name=ProdMVCDBContext")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}