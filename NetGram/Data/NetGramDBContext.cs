using Microsoft.EntityFrameworkCore;
using NetGram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetGram.Data
{
    public class NetGramDBContext : DbContext
    {
        public NetGramDBContext(DbContextOptions<NetGramDBContext> options) : base(options)
        {
        }

        public DbSet<Post> PostsTable { get; set; }
    }
}
