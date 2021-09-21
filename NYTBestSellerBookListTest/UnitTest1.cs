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
    public class Tests
    {
        private APICallBookList APICallBookListObject;
        private GetBestSellerBookList GetBestSellerBookListObject;
        private GetBookReviewList GetBookReviewListObject;
        private GetAuthorReviewList GetAuthorReviewListObject;
        private APICallBestSellerBookList APICallBestSellerBookListObject;
        private PrintBookList PrintBookListObject;
        private PrintBookReview PrintBookReviewObject;
        private PrintAuthorReview PrintAuthorReviewObject;


        [SetUp]
        public void Setup()
        {
            APICallBookListObject = new APICallBookList();
            GetBestSellerBookListObject = new GetBestSellerBookList();
            PrintBookListObject = new PrintBookList();
            GetBookReviewListObject = new GetBookReviewList();
            GetAuthorReviewListObject = new GetAuthorReviewList();
            PrintBookReviewObject = new PrintBookReview();
            PrintAuthorReviewObject = new PrintAuthorReview();
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


        [Test]
        public void BookReviewGetResponseTest()
        {
            Mock<APICallBookReview> WebRequestMock = new Mock<APICallBookReview>();
            WebRequestMock.Setup(x => x.GetResponse(It.IsAny<string>())).Returns((string s) => s);
            GetBookReviewListObject.APICallBookReviewObject = WebRequestMock.Object;
            
            Assert.IsNotNull(GetBookReviewListObject.GetRequiredData("THE%20MIDNIGHT%20LIBRARY"));
        }

        [Test]
        public void GetResponseTest_ForAuthorReviewList_RunsMethod()
        {
            Mock<APICallAuthorReview> WebRequestMock = new Mock<APICallAuthorReview>();
            WebRequestMock.Setup(x => x.GetResponse(It.IsAny<string>())).Returns((string s) => s);
            GetAuthorReviewListObject.APICallAuthorReviewObject = WebRequestMock.Object;
            Assert.IsNotNull(GetAuthorReviewListObject.GetRequiredData("Matt%20Haig"));
        }

        

    }
}