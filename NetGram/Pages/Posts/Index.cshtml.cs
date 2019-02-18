using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetGram.Models;
using NetGram.Models.Interfaces;

namespace NetGram.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly INetGram _netgram;

        public IndexModel(INetGram netgram)
        {
            _netgram = netgram;
        }
        [FromRoute]
        //[BindProperty(SupportsGet =true)]
        public int ID { get; set; }
        public Post Post { get; set; }

        /// <summary>
        /// gets all the posts in the database
        /// </summary>
        /// <returns>returns to the index page with all the post objects</returns>
        public async Task OnGet()
        {
            Post = await _netgram.FindPosts(ID);
        }
    }
}