using NUnit.Framework;
using NYTBestSellerBookList;
using Moq;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System;

namespace NYTBestSellerBookListTest
{
    class BookListTest
    {
       
        private GetBestSellerBookList GetBestSellerBookListObject;
        private APICallBestSellerBookList APICallBestSellerBookListObject;
        

        [SetUp]
        public void Setup()
        {
            GetBestSellerBookListObject = new GetBestSellerBookList();
            APICallBestSellerBookListObject = new APICallBestSellerBookList();

        }

        [Test]
        public async Task BookListGetResponseTestAsync()
        {
            Mock<APICallBestSellerBookList> WebRequestMock = new Mock<APICallBestSellerBookList>();

            WebRequestMock.Setup(x => x.GetResponseData("2021-08-08")).ReturnsAsync((string s) => s);
            GetBestSellerBookListObject.APICallBestSellerBookListObject = WebRequestMock.Object;
            var Result = await GetBestSellerBookListObject.GetRequiredData("2021-08-08");
            Assert.IsNotNull(Result);
        }

    }
}
