using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetGram.Models.Interfaces
{
    public interface INetGram
    {
        //delete
        Task Delete(int id);

        //find
        Task<Post> FindPosts(int id);

        //get all
        Task<List<Post>> GetAllPosts();

        //save
        Task Save(Post post);
    }
}
