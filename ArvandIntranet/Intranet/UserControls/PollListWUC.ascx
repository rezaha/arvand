<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PollListWUC.ascx.vb" Inherits="UserControls_PollListWUC" %>
<div class="webpart">
    <div class="webpart">
        <ul class="webpart_header">
            <li class="webpart_title">نظر سنجی
            </li>
            <li>
                <img src="../../images/menu_header_corner.png" />
            </li>
        </ul>
        <table class="fileSharing">
            <tr class="fileSharing_title">
                <td>عنوان نظرسنجی</td>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <a class="fileSharing_name" href='<%#SetPollLinks(Eval("PollId"))%>' target="_blank">
                                <img id="Img1" src="~/Images/folder_ico.png" runat="server" />
                                <span><%# Eval("PollName")%>
                                </span>
                            </a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </table>
    </div>

</div>
