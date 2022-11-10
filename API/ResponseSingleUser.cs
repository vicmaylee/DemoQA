﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.API
{// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Data
    {
        public int id { get; set; }
        public string? email { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? avatar { get; set; }
    }

    public class SingleUser
    {
        public Data? data { get; set; }
        public Support? support { get; set; }
    }

    //public class Support
    //{
    //    public string url { get; set; }
    //    public string text { get; set; }
    //}



}
