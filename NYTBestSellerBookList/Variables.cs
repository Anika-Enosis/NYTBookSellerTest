using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NYTBestSellerBookList
{
    public class Variables
    {
        public DateTime FromTime { get; set; }
        public int TimeInMiliSecond { get; set; }
        public DateTime ToTime { get; set; }
        public TimeSpan Result { get; set; }
        public StreamWriter StreamWriterObject { get; set; }
    }
}
