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
    public class ManageModel : PageModel
    {
        private readonly INetGram _netgram;

        public ManageModel(INetGram netgram)
        {
            _netgram = netgram;
        }
        [FromRoute]
        public int ID { get; set; }

        [BindProperty]
        public Post Post { get; set; }

        public async Task OnGet()
        {
            Post = await _netgram.FindPosts(ID);
        }
        public async Task<IActionResult> OnPost()
        {
            await _netgram.Save(Post);
            return RedirectToPage("/Posts/Index", ID);
        }
    }
}