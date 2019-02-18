using Microsoft.EntityFrameworkCore;
using NetGram.Data;
using NetGram.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetGram.Models.Services
{
    public class INetGramServices : INetGram
    {
        private readonly NetGramDBContext _context;

        public INetGramServices(NetGramDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Deletes a data row from the database
        /// </summary>
        /// <param name="id">which item to remove, this is by ID number</param>
        /// <returns>once the task is completed, no object is actually returned</returns>
        public async Task Delete(int id)
        {
            Post post = await _context.PostsTable.FindAsync(id);
            if (post != null)
            {
                _context.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Searches the database for a specific data row
        /// </summary>
        /// <param name="id">which item you are looking for, this is by ID number</param>
        /// <returns>the object of which one you were searching for</returns>
        public async Task<Post> FindPosts(int id)
        {
            Post post = await _context.PostsTable.FirstOrDefaultAsync(p => p.ID == id);

            return post;
        }

        /// <summary>
        /// Finds all rows in the database
        /// </summary>
        /// <returns>a list of all data objects</returns>
        public async Task<List<Post>> GetAllPosts()
        {
            return await _context.PostsTable.ToListAsync();
        }

        /// <summary>
        /// Saves either a new post or updates an existing one
        /// </summary>
        /// <param name="post">the object to save or update</param>
        /// <returns>doesn't actually return data, just returns after it is done saving</returns>
        public async Task Save(Post post)
        {
            Post tempPost = await _context.PostsTable.FirstOrDefaultAsync(p => p.ID == post.ID);
            if (tempPost == null)
            {
                _context.PostsTable.Add(post);
            }
            else
            {
                _context.PostsTable.Update(post);
            }

            await _context.SaveChangesAsync();
        }
    }
}
