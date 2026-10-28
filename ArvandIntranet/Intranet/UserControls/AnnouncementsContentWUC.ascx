<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AnnouncementsContentWUC.ascx.vb" Inherits="UserControls_AnnouncementsContentWUC" %>
<asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
        <div class="annonce_item">
            <figure>
                <a href='<%#SetAnnoncmentsUrl(Container.DataItem)%>' target="_blank">
                    <img src='<%# "~/" + Eval("SmallPictureLink")%>' runat="server" width="175" height="117" />
                </a>
            </figure>
            <h2><a href='<%#SetAnnoncmentsUrl(Container.DataItem)%>' target="_blank"><%# AnnouncementsTitle(Container.DataItem)%>
            </a>
            </h2>
            <p>
                <%# AnnouncementsSummary(Container.DataItem)%>
            </p>
            <a class="ann-readmore" href='<%#SetAnnoncmentsUrl(Container.DataItem)%>' target="_blank">ادامه مطلب
            </a>
        </div>
    </ItemTemplate>
</asp:Repeater>

