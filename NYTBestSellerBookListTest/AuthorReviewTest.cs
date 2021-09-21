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
    class AuthorReviewTest
    {
       
        private GetAuthorReviewList GetAuthorReviewListObject;
       
        [SetUp]
        public void Setup()
        {
            GetAuthorReviewListObject = new GetAuthorReviewList();
        }

        [Test]
        public void AuthorReviewListTest()
        {
            Mock<APICallAuthorReview> WebRequestMock = new Mock<APICallAuthorReview>();
            WebRequestMock.Setup(x => x.GetResponse(It.IsAny<string>())).Returns((string s) => s);
            GetAuthorReviewListObject.APICallAuthorReviewObject = WebRequestMock.Object;
            Assert.IsNotNull(GetAuthorReviewListObject.GetRequiredData("Matt%20Haig"));
        }

    }
}
