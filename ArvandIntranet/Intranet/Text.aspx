<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Text.aspx.vb" Inherits="Text" MasterPageFile="~/MasterPages/MasterPage2.master" %>

<%@ Register Src="UserControls/WriteCommentWUC.ascx" TagName="WriteCommentWUC" TagPrefix="uc2" %>
<%@ Register Src="UserControls/ShowCommentWUC.ascx" TagName="ShowCommentWUC" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/OtherNewsWUC.ascx" TagPrefix="uc1" TagName="OtherNewsWUC" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="<%# ResolveUrl("~/Scripts/ticker00.js") %>" type="text/javascript"></script>
    <script src="<%# ResolveUrl("~/Scripts/jquery.poshytip.min.js") %>" type="text/javascript"></script>
    <script src="<%# ResolveUrl("~/Scripts/jquery.infieldlabel.min.js") %>" type="text/javascript"></script>
    <script src="<%# ResolveUrl("~/Scripts/function.js") %>" type="text/javascript"></script>
    <link href='<%=ResolveClientUrl("~/Css/tip-yellowsimple.css")%>' rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#fade').list_ticker({
                speed: 2000,
                effect: 'fade'
            });
            $('#slide').list_ticker({
                speed: 10000,
                effect: 'slide'
            });
        })
    </script>
    <script type="text/javascript">
        $(function () {
            $('.tooltip').poshytip({
                className: 'tip-yellowsimple',
                showTimeout: 1,
                alignTo: 'target',
                alignX: 'center',
                alignY: 'bottom',
                slide: false,
                fade: false,
                offsetY: 5,
            });
        });
    </script>
    <script type="text/javascript" charset="utf-8">
        $(function () { $("label").inFieldLabels(); });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="news_section" style="width: 97%">
        <div class="news_subject">
            <span style="margin-right: 15px;" runat="server" id="lblTitle"></span>
            <span class="news_date" runat="server" id="lblDate"></span>
        </div>
        <div class="news_Hachure"></div>
        <div class="news_Summery">
            <img src="images/news/news_summery.png" runat="server" id="lblLargeImage" />
            <div class="news_Summery_text" runat="server" id="lblSummary" style="margin-right: 0px; width: 100%;">
            </div>
        </div>
        <div class="news_Complete" style="width: 92%">
            <span runat="server" id="lblContent"></span>
        </div>
    </div>
</asp:Content>
