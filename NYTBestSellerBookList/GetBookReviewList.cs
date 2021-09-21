using System;
using System.Collections.Generic;
using System.Text;

namespace NYTBestSellerBookList
{
    public class GetBookReviewList : IProcessRequiredData
    {
        public APICallBookReview APICallBookReviewObject;
        public string[] GetRequiredData(string BookName)
        {
            string ResponseData;
            APICallBookReviewObject = new APICallBookReview();
            ResponseData = APICallBookReviewObject.GetResponse(BookName);
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

