using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLair;

namespace server
{
    public class Result
    {
        public int ResultCode { get; set; }
        public string ResultMessage { get; set; }
       public Result(int result_code, string result_message)
        {
            ResultCode = result_code;
            ResultMessage = result_message;
        }

   
    }
}