﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIewWPF.Models

{
    public class Context : DbContext
    {
        public Context() : base("DbRevolution") { }

        public DbSet<People> Peoples { get; set; }
    }
}
