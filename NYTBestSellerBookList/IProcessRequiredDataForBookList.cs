using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NYTBestSellerBookList
{
    public interface IProcessRequiredDataForBookList
    {
        public Task<string[]> GetRequiredData(string ResponseData);
    }
}
