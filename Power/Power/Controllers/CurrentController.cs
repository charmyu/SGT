using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Power.Controllers
{
    public class CurrentController : ApiController
    {
        public string GetLogoutInfo()
        {
          
            string val = "";
            bool bl = CurrentUser.IsLogon;
            if (bl)
            {
                CurrentUser.Logout(); val = "OK";
            }
            return val;
        }
    }
}