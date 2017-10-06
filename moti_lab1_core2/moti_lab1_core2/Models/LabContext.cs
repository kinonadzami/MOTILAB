using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace moti_lab1_core2.Models
{
    public class LabContext : DbContext
    {
        public DbSet<Alternative> Alternatives { get; set; }
        public DbSet<Criterion> Criterions { get; set; }
        public DbSet<LPR> LPRs { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Vector> Vectors { get; set; }

        public LabContext(DbContextOptions<LabContext> options)
            : base(options)
        {
        }

    }
}
