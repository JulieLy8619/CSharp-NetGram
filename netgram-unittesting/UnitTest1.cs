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

        //read (FindPosts)
        [Fact]
        public async void TestReadOneinDB()
        {
            DbContextOptions<NetGramDBContext> options = new DbContextOptionsBuilder<NetGramDBContext>().UseInMemoryDatabase("ReadPost").Options;


            using (NetGramDBContext context = new NetGramDBContext(options))
            {

                Post testPost10 = new Post();
                testPost10.ID = 1;
                testPost10.Title = "aTitle";
                testPost10.Description = "aDescription";
                testPost10.ImageURL = ".URL";

                INetGramServices netGramService = new INetGramServices(context);

                await netGramService.Save(testPost10);
                Post returnedPost1 = await netGramService.FindPosts(testPost10.ID);

                var testPost10Answer = context.PostsTable.FirstOrDefault(a => a.ID == testPost10.ID);

                Assert.Equal(returnedPost1, testPost10Answer);
            }
        }
        //read (GetAllPosts)
        [Fact]
        public async void TestReadAllinDB()
        {
            DbContextOptions<NetGramDBContext> options = new DbContextOptionsBuilder<NetGramDBContext>().UseInMemoryDatabase("Read2Post").Options;


            using (NetGramDBContext context = new NetGramDBContext(options))
            {

                Post testPost11 = new Post();
                testPost11.ID = 1;
                testPost11.Title = "aTitle";
                testPost11.Description = "aDescription";
                testPost11.ImageURL = ".URL";

                INetGramServices netGramService = new INetGramServices(context);

                await netGramService.Save(testPost11);
                var returnedPost2 = await netGramService.GetAllPosts();

                var testPost11Answer = context.PostsTable.FirstOrDefault(a => a.ID == testPost11.ID);

                Assert.Equal(returnedPost2[0], testPost11Answer);
            }
        }

        //update
        [Fact]
        public async void TestUpdateinDB()
        {
            DbContextOptions<NetGramDBContext> options = new DbContextOptionsBuilder<NetGramDBContext>().UseInMemoryDatabase("UpdatePost").Options;


            using (NetGramDBContext context = new NetGramDBContext(options))
            {

                Post testPost12 = new Post();
                testPost12.ID = 1;
                testPost12.Title = "aTitle";
                testPost12.Description = "aDescription";
                testPost12.ImageURL = ".URL";

                INetGramServices netGramService = new INetGramServices(context);

                await netGramService.Save(testPost12);
                testPost12.Title = "NEWTitle";
                await netGramService.Save(testPost12);
                var returnedPost3 = await netGramService.FindPosts(1);

                var testPost12Answer = context.PostsTable.FirstOrDefault(a => a.ID == testPost12.ID);

                Assert.Equal("NEWTitle", testPost12Answer.Title);
            }
        }

        //delete
        [Fact]
        public async void TestDeleteinDB()
        {
            DbContextOptions<NetGramDBContext> options = new DbContextOptionsBuilder<NetGramDBContext>().UseInMemoryDatabase("DeletePost").Options;


            using (NetGramDBContext context = new NetGramDBContext(options))
            {

                Post testPost13 = new Post();
                testPost13.ID = 1;
                testPost13.Title = "aTitle";
                testPost13.Description = "aDescription";
                testPost13.ImageURL = ".URL";

                INetGramServices netGramService = new INetGramServices(context);

                await netGramService.Save(testPost13);

                await netGramService.Delete(1);

                var testPost13Answer = context.PostsTable.FirstOrDefault(a => a.ID == testPost13.ID);

                Assert.Null(testPost13Answer);
            }
        }
    }
}
