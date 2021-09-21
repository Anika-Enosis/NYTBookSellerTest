using System;
using System.Collections.Generic;
using System.Text;

namespace NYTBestSellerBookList
{
    public class APICallBookReview : APICall
    {
        string ResponseData;
        public override string GetResponse(string InputData)
        {
            string Url = "https://api.nytimes.com/svc/books/v3/reviews.json?title=" + InputData + "&api-key=PoIa9Gvjvni8UxLCVjiXgxgFjOtveAiW";
            ResponseData = base.GetResponse(Url);
            //var GetReviewListObject = new GetBookReviewList();
            //GetReviewListObject.GetRequiredData(ResponseData);
            return ResponseData;
        }
    }
}
