using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NYTBestSellerBookList
{
    public class PrintBookList
    {
        public async void print(string[] Dates)
        {
            var GetBestSellerBookListObject = new GetBestSellerBookList();
            foreach (string Date in Dates)
            {


                string[] BooksAndAuthors = null;
                BooksAndAuthors = await GetBestSellerBookListObject.GetRequiredData(Date);
                string[] Books = new string[BooksAndAuthors.Length/2];
                string[] Authors = new string[BooksAndAuthors.Length / 2];

                for (int i = 0; i < BooksAndAuthors.Length/2; i++)
                {
                    Books[i] = BooksAndAuthors[i];
                }

                for (int i = BooksAndAuthors.Length/2; i < BooksAndAuthors.Length; i++)
                {
                    Authors[i- BooksAndAuthors.Length / 2] = BooksAndAuthors[i];
                }
                int k = 0;
                Console.WriteLine("\n\n\nBest Seller book of date " + Date);
                lock ("output1.txt")
                {
                    foreach (string Book in Books)
                    {
                        using (StreamWriter StreamWriterObject = File.AppendText("output1.txt"))
                        {
                        if (Book != null)
                        {
                            Console.WriteLine("Title : " + Book + " Author : "+ Authors[k] );
                            StreamWriterObject.WriteLine("Title : " + Book + " Author : " + Authors[k]);
                            k += 1;

                        }
                        else
                        {
                            Console.WriteLine("Time after showing booklist  " + " is " + DateTime.Now.ToString("HH:mm:ss"));
                            var VariableObject = new Variables();
                            var FromTime = VariableObject.FromTime;
                            DateTime ToTime = DateTime.Now;
                            TimeSpan ResultTime = ToTime - FromTime;
                            VariableObject.TimeInMiliSecond += ResultTime.Milliseconds + ResultTime.Seconds * 1000;
                            Console.WriteLine("Time needed " + VariableObject.TimeInMiliSecond);
                            int Time_MiliSecond = VariableObject.TimeInMiliSecond;
                            //StreamWriterObject.WriteLine("Time needed " + VariableObject.TimeInMiliSecond);
                            VariableObject.FromTime = ToTime;
                            Console.WriteLine("\n\n");
                        }
                        StreamWriterObject.Close();
                        }
                    }
                }
            }
            //});
            //t.RunSynchronously(); 
        }

    }
}
