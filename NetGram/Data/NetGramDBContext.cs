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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    ID = 1,
                    Title = "Creative Title 1",
                    Author = "Bob Smith",
                    Description = "a really cool description",
                    ImageURL = "tempImage.jpg"
                },
                new Post
                {
                    ID = 2,
                    Title = "Creative Title 2",
                    Author = "Sally Smith",
                    Description = "a not cool description",
                    ImageURL = "tempImage2.jpg"
                },
                new Post
                {
                    ID = 3,
                    Title = "Creative Title 3",
                    Author = "John Smith",
                    Description = "a lame description",
                    ImageURL = "tempImage3.jpg"
                }, 
                new Post
                {
                    ID = 4,
                    Title = "Creative Title 4",
                    Author = "Jane Smith",
                    Description = "just a description",
                    ImageURL = "tempImage4.jpg"
                },
                new Post
                {
                    ID = 5,
                    Title = "Creative Title 5",
                    Author = "Billy Smith",
                    Description = "a secret description that if I tell you I have to k*** you ;)",
                    ImageURL = "tempImage5.jpg"
                }
                );
        }

        public DbSet<Post> PostsTable { get; set; }
    }
}
