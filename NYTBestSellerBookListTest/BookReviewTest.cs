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
    class BookReviewTest
    {
        private GetBookReviewList GetBookReviewListObject;
        
        [SetUp]
        public void Setup()
        {
            GetBookReviewListObject = new GetBookReviewList();
        }

        [Test]
        public void BookReviewGetResponseTest()
        {
            Mock<APICallBookReview> WebRequestMock = new Mock<APICallBookReview>();
            WebRequestMock.Setup(x => x.GetResponse(It.IsAny<string>())).Returns((string s) => s);
            GetBookReviewListObject.APICallBookReviewObject = WebRequestMock.Object;

            Assert.IsNotNull(GetBookReviewListObject.GetRequiredData("THE%20MIDNIGHT%20LIBRARY"));
        }

    }
}
