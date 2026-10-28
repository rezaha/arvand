using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Danesh.WebSite.Security
{
    class RemoveHeader
    {
        private static readonly List<string> _headersToRemoveCache
           = new List<string>
                             {
                                 "X-AspNet-Version",
                                 "X-AspNetMvc-Version",
                                 "Server"
                             };

        public static void CheckPreSendRequestHeaders(Object sender)
        {
            //capture the current request
            var currentResponse = ((HttpApplication)sender).Response;

            //removing headers
            //it only works with IIS 7.x's integrated pipeline
            _headersToRemoveCache.ForEach(h => currentResponse.Headers.Remove(h));

            //modify the "Server" Http Header
            currentResponse.Headers.Set("Server", "Danesh Afzar Mahan");
        }
    }
}
