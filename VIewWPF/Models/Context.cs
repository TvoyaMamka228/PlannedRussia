using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIewWPF.Models;

namespace VIewWPF

{
    public class Context : DbContext
    {
        public Context() : base("DbRevolution") { }

        public DbSet<People> Peoples { get; set; }
        public DbSet<Factory> Factories { get; set; }

    }
}
