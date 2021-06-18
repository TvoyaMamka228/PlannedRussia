using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannedRussiaLC.Model
{
    class Context : DbContext
    {
        public Context()
            : base("DbConnection")
        { }

        public DbSet<People> Peoples { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<SchoolProfil> SchoolProfils { get; set; }

    }
}
