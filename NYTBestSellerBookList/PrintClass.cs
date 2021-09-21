using System;
using System.Collections.Generic;
using System.Text;

namespace NYTBestSellerBookList
{
    public class PrintClass
    {
        public virtual void print(string[] Reviews)
        {
            foreach (string Review in Reviews)
            {
                Console.WriteLine(Review);
            }
        }
    }
}
