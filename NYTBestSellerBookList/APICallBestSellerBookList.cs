using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NYTBestSellerBookList
{
    public class APICallBestSellerBookList 
    {
        public string ResponseData;

        public virtual async Task<string> GetResponseData(string InputData)
        {
            await Task.Run(() =>
            {
                string Url = "https://api.nytimes.com/svc/books/v3/lists/" + InputData + "/hardcover-fiction.json?api-key=PoIa9Gvjvni8UxLCVjiXgxgFjOtveAiW";
                WebRequest Request = WebRequest.Create(Url);
                using (WebResponse Response = Request.GetResponse())
                {
                    using (StreamReader ResponseReader =
                      new StreamReader(Response.GetResponseStream()))
                    {
                        ResponseData = ResponseReader.ReadToEnd();

                    }
                }

            });

            return ResponseData;
        }
    } 
}
