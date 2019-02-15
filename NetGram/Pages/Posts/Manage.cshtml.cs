using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;
using NetGram.Models;
using NetGram.Models.Interfaces;
using NetGram.Models.Utility;

namespace NetGram.Pages.Posts
{
    public class ManageModel : PageModel
    {
        private readonly INetGram _netgram;

        public ManageModel(INetGram netgram, IConfiguration configuaton)
        {
            _netgram = netgram;
            BlobImg = new Blob(configuaton);
        }
        [FromRoute]
        public int? ID { get; set; }

        [BindProperty]
        public Post Post { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        public Blob BlobImg { get; set; }

        public async Task OnGet()
        {
            Post = await _netgram.FindPosts(ID.GetValueOrDefault()) ?? new Post();
        }
        public async Task<IActionResult> OnPost()
        {
            var tempPost = await _netgram.FindPosts(ID.GetValueOrDefault()) ?? new Post();

            tempPost.Title = Post.Title;
            tempPost.Author = Post.Author;
            tempPost.Description = Post.Description;
            tempPost.ImageURL = Post.ImageURL;

            if (Image != null)
            {
                var filePath = Path.GetTempFileName();
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }

                var container = await BlobImg.GetContainer("NetGramImagesContainer");

                BlobImg.AddBlob(Image.FileName, container, filePath);

                CloudBlob returnBlob = await BlobImg.GetBlob(Image.FileName, container.Name);
                tempPost.ImageURL = returnBlob.Uri.ToString();
            }

            await _netgram.Save(tempPost);
            return RedirectToPage("/Posts/Index", new { id = tempPost.ID});
        }

        public async Task<IActionResult> OnPostDelete()
        {
            await _netgram.Delete(ID.Value);
            return RedirectToPage("/Index");
        }
    }
}