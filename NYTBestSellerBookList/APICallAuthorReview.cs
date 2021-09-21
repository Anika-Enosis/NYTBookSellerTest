using System;
using System.Collections.Generic;
using System.Text;

namespace NYTBestSellerBookList
{
    public class APICallAuthorReview : APICall
    {
        string ResponseData;
        public override string GetResponse(string InputData)
        {
            string Url = "https://api.nytimes.com/svc/books/v3/reviews.json?author=" + InputData + "&api-key=PoIa9Gvjvni8UxLCVjiXgxgFjOtveAiW";
            ResponseData = base.GetResponse(Url);
            return ResponseData;

        }
    }
}
