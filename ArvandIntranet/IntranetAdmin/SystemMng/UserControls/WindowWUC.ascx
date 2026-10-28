<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WindowWUC.ascx.vb" Inherits="WUControls_WindowWUC" %>

<telerik:RadWindowManager ID="RadWindowManager" runat="server">
    <Windows>
        <telerik:RadWindow ID="RadWindow1" runat="server" VisibleOnPageLoad="false" Title=""
            OnClientShow="clientShow" OnClientClose="clientClose">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
<telerik:RadCodeBlock ID="RadCodeBlock3" runat="server">
    <script type="text/javascript">
        var manager = null;
        var windows = null;
        var win = null;
        var myUrl = null;
        var bodyOverflow;
        var htmlOverflow;
        var winHeight;
        var winWidth;
        function ShowForm(url, width, height) {
            manager = $find("<%=RadWindowManager.ClientID %>");
            windows = manager.get_windows();
            win = windows[0];
            if (width == null) {
                width = $(window).width() - 50;
            }
            if (height == null) {
                height = $(window).height() - 50;
            }
            var docHeight = $(window).height();
            if (docHeight < 650) {
                height = docHeight - 50;
            }
            winHeight = height;
            winWidth = width;
            win.setSize(winWidth, winHeight);
            win.setUrl(url);
            win.set_modal(true);
            win.set_showContentDuringLoad(false);
            //win.set_visibleTitlebar(false);
            win.set_visibleStatusbar(false);
            win.set_behaviors(Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Move);
            //save the overflow  
            bodyOverflow = document.body.style.overflow;
            htmlOverflow = document.documentElement.style.overflow;
            //hide the overflow  
            document.body.style.overflow = "hidden";
            document.documentElement.style.overflow = "hidden";
            win.show();
            return false;
        }
        function clientShow(sender, eventArgs) {
            //document.getElementById("HiddenFieldParent").value = "";
        }
        function clientClose(sender, args) {
            document.body.style.overflow = bodyOverflow;
            document.documentElement.style.overflow = htmlOverflow;
            AfterWindowsClose();
        }

        $(window).resize(function () {
            ResizeModal();
        });
        function ResizeModal() {
            if (win != null) {
                var height = winHeight;
                var docHeight = $(window).height();
                if (docHeight < winHeight) {
                    height = docHeight - 50;
                }
                win.set_height(height);
            }
        }
    </script>
</telerik:RadCodeBlock>
