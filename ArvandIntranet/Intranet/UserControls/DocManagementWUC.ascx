<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DocManagementWUC.ascx.vb" Inherits="UserControls_DocManagementWUC" %>
<div class="webpart">
    <ul class="webpart_header">
        <li class="webpart_title"><%=WebpartTitle%>
        </li>
        <li>
            <img src="~/images/menu_header_corner.png" runat="server" />
        </li>
    </ul>
    <table class="fileSharing">
    <tr class="fileSharing_title">
        <td>نام فایل</td>
        <td>دانلود</td>
    </tr>
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <tr>
                <td>
                    <a class="fileSharing_name" href='<%#SetDownloadLink(Container.DataItem)%>' target="_blank">
                        <img id="Img1" src="~/Images/folder_ico.png" runat="server" />
                        <span><%# SetLinkText(Container.DataItem)%>
                        </span>
                    </a>
                </td>
                <td>
                    <a class="download-ico" href='<%#SetDownloadLink(Container.DataItem)%>' target="_blank">
                        <img id="Img2" src="~/Images/download_ico.png" runat="server" />
                    </a>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    <%-- <tr class="even">
        <td>
            <a class="fileSharing_name" href="#">
                <img src="Images/folder_ico.png" />
                <span>نمونه فایل دانلودی
                </span>
            </a>
        </td>
        <td>
            <a class="download-ico" href="#">
                <img src="Images/download_ico.png" />
            </a>
        </td>
    </tr>
    <tr>
        <td>
            <a class="fileSharing_name" href="#">
                <img src="Images/folder_ico.png" />
                <span>نمونه فایل دانلودی
                </span>
            </a>
        </td>
        <td>
            <a class="download-ico" href="#">
                <img src="Images/download_ico.png" />
            </a>
        </td>
    </tr>--%>
</table>
</div>
<!-- end of webpart_title ul !-->



<!-- end of webpart_title ul !-->

<!-- end of webpart div !-->