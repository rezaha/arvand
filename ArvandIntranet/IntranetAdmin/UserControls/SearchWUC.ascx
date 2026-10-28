<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SearchWUC.ascx.vb" Inherits="UserControls_SearchWUC" %>

<script type="text/javascript">

    function clickButton(e, buttonid) {

        var evt = e ? e : window.event;

        var bt = document.getElementById(buttonid);

        if (bt) {

            if (evt.keyCode == 13) {

                bt.click();

                return false;

            }

        }

    }

</script>
<div class="search">
    <ul class="searchbox">
        <li>
            <asp:TextBox ID="searchbox" runat="server"></asp:TextBox>
        </li>
        <li>
            <a href="#">
                <img src="~/Images/search_ico.png" runat="server" />
            </a>
        </li>
    </ul>
</div>
