using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestEF.Models
{
    public class API_ErrorModel
    {
        public string Msg { get; set; }
        public string Success { get; set; }
        public API_ErrorModel(string suc , string msg)
        {
            this.Success = suc;
            this.Msg = msg;
        }
    }
}
