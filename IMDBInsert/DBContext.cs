using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBInsert
{
    public  class ImdbDBContext : DbContext
    {
        public ImdbDBContext(DbContextOptions<ImdbDBContext>
            options) : base(options) { }

        public DbSet<Title> titles { get; set; }
    }
}
