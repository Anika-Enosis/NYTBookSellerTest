using System;
using System.Collections.Generic;
using System.Text;

namespace NYTBestSellerBookList
{
    public class GetAuthorReviewList : IProcessRequiredData
    {
        public APICallAuthorReview APICallAuthorReviewObject;
        public string[] GetRequiredData(string AuthorName)
        {
            string ResponseData;
            APICallAuthorReviewObject = new APICallAuthorReview();
            ResponseData = APICallAuthorReviewObject.GetResponse(AuthorName);

            if (ResponseData.Contains("summary"))
            {
                string[] ReviewLines = ResponseData.Split("\"summary\":\"");
                string[] Reviews = new string[ReviewLines.Length];

                for (int i = 1; i < ReviewLines.Length; i++)
                {
                    string[] str = ReviewLines[i].Split("\",");
                    Reviews[i - 1] = str[0];
                }

                //var PrintClassObject = new PrintClass();
                //PrintClassObject.print(Reviews);
                return Reviews;
            }
            else
            {
                string[] Reviews = new string[1];
                Reviews[0] = "No review Available";
                //var PrintClassObject = new PrintClass();
                //PrintClassObject.print(Reviews);
                return Reviews;

            }

        }
    }
}
