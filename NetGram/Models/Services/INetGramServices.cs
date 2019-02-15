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
        public async Task Delete(int id)
        {
            Post post = await _context.PostsTable.FindAsync(id);
            if (post != null)
            {
                _context.Remove(post);
                await _context.SaveChangesAsync();
            }

            //Post delPost = _context.PostsTable.FirstOrDefault(p => p.ID == id);
            //_context.PostsTable.Remove(delPost);
            //await _context.SaveChangesAsync();
        }

        public async Task<Post> FindPosts(int id)
        {
            Post post = await _context.PostsTable.FirstOrDefaultAsync(p => p.ID == id);

            return post;
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return await _context.PostsTable.ToListAsync();
        }

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
