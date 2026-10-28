using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Danesh.WebSite.Security
{
    class SecurityModule : IHttpModule
    {

        public void Dispose()
        {
        }

        public void Init(HttpApplication app)
        {
            app.PreSendRequestHeaders += app_PreSendRequestHeaders;
        }

        static void app_PreSendRequestHeaders(object sender, EventArgs e)
        {
            RemoveHeader.CheckPreSendRequestHeaders(sender);
        }
    }
}
