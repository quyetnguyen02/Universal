﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationViewDemo.Entity
{
   public  class Account
    {

        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string avatar { get; set; }

        public int gender { get; set; }
        public string email { get; set; }
        public string birthday { get; set; }
        public string introduction { get; set; }
        public string createAt { get; set; }
        public string updateAt { get; set; }
        public string status { get; set; }
    }
}
