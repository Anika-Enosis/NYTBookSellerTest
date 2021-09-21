using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NYTBestSellerBookList
{
    public class GetBestSellerBookList 
    {
        public APICallBestSellerBookList APICallBestSellerBookListObject;
        public virtual async Task<string[]> GetRequiredData(string date)
        {
            //var APICallBookListObj = new APICallBookList();
            //Task<string> Result = APICallBookListObj.GetResponse("current");
            //Console.WriteLine(Result);

            string ResponseData;
            //var APICallBookListObject = new NYTBestSellerBookList.APICallBookList();
            //ResponseData = await APICallBookListObject.GetResponse(date);

            APICallBestSellerBookListObject = new APICallBestSellerBookList();
            ResponseData = await APICallBestSellerBookListObject.GetResponseData(date);

            string[] Titles = ResponseData.Split("\"title\":\"");
            string[] Books = new string[Titles.Length];
            string[] AuthorNames = ResponseData.Split("\"author\":\"");
            string[] Authors = new string[AuthorNames.Length];
            string[] BooksAndAuthors = new string[2*AuthorNames.Length];

            for (int i = 1; i < Titles.Length; i++)
            {
                string[] ResultBooks = Titles[i].Split("\"");
                Books[i - 1] = ResultBooks[0];
                string[] AuthorSplitResult = AuthorNames[i].Split("\"");
                Authors[i - 1] = AuthorSplitResult[0];
            }

            for (int i = 0; i < Titles.Length; i++)
            {
                BooksAndAuthors[i] = Books[i];
            }

            for (int i = Titles.Length; i < 2*Titles.Length; i++)
            {
                BooksAndAuthors[i] = Authors[i- Titles.Length];
            }

            return BooksAndAuthors;
            
        }
    }
}
