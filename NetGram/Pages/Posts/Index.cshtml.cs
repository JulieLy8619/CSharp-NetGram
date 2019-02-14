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
        public int ID { get; set; }
        public Post Post { get; set; }
        public async void OnGet()
        {
            Post = await _netgram.FindPosts(ID);
        }
    }
}