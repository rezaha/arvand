<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Confirm.ascx.vb" Inherits="WUControls_Confirm" %>
<telerik:RadWindowManager ID="windowManager1" runat="server" Modal="true">
    <Localization Maximize="<%$ Resources:RadWindow, Maximize %>" Minimize="<%$ Resources:RadWindow, Minimize %>"
        Close="<%$ Resources:RadWindow, Close %>" PinOff="<%$ Resources:RadWindow, PinOff %>"
        PinOn="<%$ Resources:RadWindow, PinOn %>" Reload="<%$ Resources:RadWindow,Reload %>"
        Restore="<%$ Resources:RadWindow, Restore%>" Cancel="<%$ Resources:RadWindow, Cancel %>"
        OK="<%$ Resources:RadWindow, OK %>" No="<%$ Resources:RadWindow, No %>" Yes="<%$ Resources:RadWindow, Yes %>" />
</telerik:RadWindowManager>
<script type="text/javascript">
        //<![CDATA[

    //RadConfirm
    function RadConfirm(sender, args) {
        var callBackFunction = Function.createDelegate(sender, function (shouldSubmit) {
            if (shouldSubmit) {
                this.click();
            }
        });

        var text = "آیا مایل به حذف رکورد می باشد؟";
        radconfirm(text, callBackFunction, 250, 100, null, "اخطار سیستم");
        args.set_cancel(true);
    }

    function RadConfirm2(sender, args) {
        var callBackFunction = Function.createDelegate(sender, function (shouldSubmit) {
            if (shouldSubmit) {
                this.click();
            }
        });

        var text = "آیا مطمئنید؟";
        radconfirm(text, callBackFunction, 250, 100, null, "اخطار سیستم");
        args.set_cancel(true);
    }
    //Custom RadWindow Confirm
          
        //]]>
</script>
