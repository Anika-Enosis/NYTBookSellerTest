using NYTBestSellerBookList;
using System;
using System.IO;
using System.Threading.Tasks;


namespace NYTBestSeller
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var VariablesObject = new NYTBestSellerBookList.Variables();
            VariablesObject.TimeInMiliSecond = 0;
            Task Task1 = null;
            Console.WriteLine("Enter date in format(\"YYYY-MM-DD\") seperating by \",\"");
            string Dates = Console.ReadLine();
            string[] DateArray = Dates.Split(",");
            VariablesObject.FromTime = DateTime.Now;
            Console.WriteLine("Time of calling BookList " + " is " + DateTime.Now.ToString("HH:mm:ss"));
            VariablesObject.StreamWriterObject = new StreamWriter("output1.txt");
            VariablesObject.StreamWriterObject.WriteLine("Time of calling BookList " + " is " + DateTime.Now.ToString("HH:mm:ss"));
            VariablesObject.StreamWriterObject.Close();
            var APICallBookListObject = new NYTBestSellerBookList.APICallBookList();

            /*foreach (string EachEate in DateArray)
            {
                Task1 = APICallBookListObject.GetResponse(EachEate);

            }

            string result = await (APICallBookListObject.GetResponse("current"));
            Console.WriteLine("result:: " + result);
            //Console.WriteLine(APICallBookListObject.GetResponse("current").GetType());
            await Task.WhenAll(Task1);*/

            var PrintBookListObject = new PrintBookList();
            PrintBookListObject.print(DateArray);

            Console.WriteLine("Need More results?press \"2\" for \"Book Review\" \n press \"3\" for \"Author Review\"");
            string Pressed = Console.ReadLine();

            if (Pressed == (2.ToString()))
            {
                Console.WriteLine("Enter book title: ");
                string BookTitle = Console.ReadLine();
                string Title = BookTitle.ToUpper();
                Title = Title.Replace(" ", "%20");
                var GetBookReviewListObject = new GetBookReviewList();
                string[] BookReviewList = GetBookReviewListObject.GetRequiredData(Title);
                var PrintBookReviewListObject = new PrintBookReview();
                PrintBookReviewListObject.print(BookReviewList);
                
            }
            else if (Pressed == (3.ToString()))
            {
                Console.WriteLine("Enter Author Name: ");
                string AuthorName = Console.ReadLine();
                string Author = AuthorName.Replace(" ", "%20");
                var GetAuthorReviewListObject = new GetAuthorReviewList();
                string[] AuthorReviewList = GetAuthorReviewListObject.GetRequiredData(Author);
                var PrintAuthorReviewListObject = new PrintAuthorReview();
                PrintAuthorReviewListObject.print(AuthorReviewList);

            }


        }
    }
}
