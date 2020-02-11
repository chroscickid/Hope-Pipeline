using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;



namespace HopePipeline.Models.DbEntities.Login
{
    public class AdminRowContext : DbContext

    {
        public DbSet<AdminRow> AdminRows { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=tcp:ccrhopepipeline.database.windows.net,1433;Initial Catalog=Hope Pipeline;Persist Security Info=False;User ID=user;Password=P4ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
                );
        }
    }
    public class AdminRow
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
      

    }
}
