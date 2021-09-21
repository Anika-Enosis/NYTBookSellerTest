using System;
using System.Collections.Generic;
using System.Text;

namespace NYTBestSellerBookList
{
    public interface IProcessRequiredData
    {
        string[] GetRequiredData(string ResponseData);
    }

}
