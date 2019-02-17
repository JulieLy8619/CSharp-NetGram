using System;
using Xunit;
using NetGram;
using System.Linq;
using NetGram.Data;
using NetGram.Models;
using NetGram.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace netgram_unittesting
{
    public class UnitTest1
    {
        //get title
        [Fact]
        public void TestGetTitle()
        {
            Post testPost1 = new Post();
            testPost1.Title = "aTitle";
            Assert.Equal("aTitle", testPost1.Title);
        }

        //set title
        [Fact]
        public void TestSetTitle()
        {
            Post testPost2 = new Post();
            testPost2.Title = "aTitle";
            testPost2.Title = "newTitle";
            Assert.Equal("newTitle", testPost2.Title);
        }

        //get author
        [Fact]
        public void TestGetAuthor()
        {
            Post testPost3 = new Post();
            testPost3.Author = "anAuthor";
            Assert.Equal("anAuthor", testPost3.Author);
        }

        //set author
        [Fact]
        public void TestSetAuthor()
        {
            Post testPost4 = new Post();
            testPost4.Author = "anAuthor";
            testPost4.Author = "NewAuthor";
            Assert.Equal("NewAuthor", testPost4.Author);
        }

        //get description
        [Fact]
        public void TestGetDescription()
        {
            Post testPost5 = new Post();
            testPost5.Description = "aDescription";
            Assert.Equal("aDescription", testPost5.Description);
        }

        //set description
        [Fact]
        public void TestSetDescription()
        {
            Post testPost6 = new Post();
            testPost6.Description = "aDescription";
            testPost6.Description = "NewDescription";
            Assert.Equal("NewDescription", testPost6.Description);
        }

        //get image url
        [Fact]
        public void TestGetImageURL()
        {
            Post testPost7 = new Post();
            testPost7.ImageURL = "aURL";
            Assert.Equal("aURL", testPost7.ImageURL);
        }

        //set image url
        [Fact]
        public void TestSetImageURL()
        {
            Post testPost8 = new Post();
            testPost8.ImageURL = "aURL";
            testPost8.ImageURL = "NewURL";
            Assert.Equal("NewURL", testPost8.ImageURL);
        }

        //create
        [Fact]
        public async void TestCreateinDB()
        {
            DbContextOptions<NetGramDBContext> options = new DbContextOptionsBuilder<NetGramDBContext>().UseInMemoryDatabase("CreatePost").Options;

            using (NetGramDBContext context = new NetGramDBContext(options))
            {

                Post testPost9 = new Post();
                testPost9.ID = 1;
                testPost9.Title = "aTitle";
                testPost9.Description = "aDescription";
                testPost9.ImageURL = ".URL";

                INetGramServices netGramService = new INetGramServices(context);

                await netGramService.Save(testPost9);

                var testPost9Answer = context.PostsTable.FirstOrDefault(a => a.ID == testPost9.ID);

                Assert.Equal(testPost9, testPost9Answer);
            }
        }

        //read
        [Fact]
        public void TestReadinDB()
        {

        }

        //update
        [Fact]
        public void TestUpdateinDB()
        {

        }

        //delete
        [Fact]
        public void TestDeleteinDB()
        {

        }
    }
}
