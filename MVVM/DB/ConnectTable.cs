using MPAccses.MVVM.Model.ModelData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPAccses.MVVM.DB
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Roles { get; set; }

        public ApplicationDbContext() : base("ISMPEntities")
        {
        }
    }
}
