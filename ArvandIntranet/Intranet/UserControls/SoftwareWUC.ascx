<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SoftwareWUC.ascx.vb" Inherits="UserControls_SoftwareWUC" %>
<div class="software_list">
    <ul class="main_title">
        <li class="main_title_text">لینک های پر کاربرد
        </li>
        <li class="main_title_corner">
            <img src="~/Images/main_title_corner.png" runat="server" />
        </li>
    </ul>
    <ul class="dashboard">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <li>
                    <a href='<%#Eval("SoftwareUrl")%>' target="_blank">
                        <img width="32" height="32" src='<%#SetLargImage(Container.DataItem)%>' />
                    </a>
                    <span style="width:80px;"><%#Eval("SoftwareName")%>
                    </span>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
