using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phase1_Projects_Backend.Models
{
    public class ResponseString
    {
        public ResponseString()
        {
            this.responseMessage = "This string is not assigned with any response string yet";
            this.username = "This string is not assigned with any username yet";
        }
        public ResponseString(string s)
        {
            this.responseMessage = s;
        }
        public ResponseString(string s, string u)
        {
            this.responseMessage = s;
            this.username = u;
        }
        public string responseMessage { get; set; }
        public string username { get; set; }
    }
}
