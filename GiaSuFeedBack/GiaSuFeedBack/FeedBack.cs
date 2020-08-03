using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GiaSuFeedBack
{
    public class FeedBack
    {
        public int feedBackID { get; set; }
        public string title { get; set; }
        public string detail { get; set; }
        public int userID { get; set; }
        public string userName { get; set; }
    }
}
