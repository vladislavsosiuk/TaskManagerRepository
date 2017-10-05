using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLair;

namespace server
{
    public class Result
    {
        private int v;
        private List<MyTask> tasks;

        public int ResultCode { get; set; }
        public string ResultMessage { get; set; }
       public Result(int result_code, string result_message)
        {
            ResultCode = result_code;
            ResultMessage = result_message;
        }

        public Result(int v, List<MyTask> tasks)
        {
            this.v = v;
            this.tasks = tasks;
        }
    }
}