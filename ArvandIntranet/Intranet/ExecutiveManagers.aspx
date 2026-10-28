<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPages/MasterPage.master"
    AutoEventWireup="false" CodeFile="ExecutiveManagers.aspx.vb" Inherits="ExecutiveManagers" %>

<%@ Register Src="~/UserControls/SoftwareSideBarWUC.ascx" TagPrefix="uc1" TagName="SoftwareSideBarWUC" %>
<%@ Register Src="~/UserControls/OtherNewsWUC.ascx" TagPrefix="uc2" TagName="OtherNewsWUC" %>
<%@ Register Src="~/UserControls/OtherAnnouncementsWUC.ascx" TagPrefix="uc3" TagName="OtherAnnouncementsWUC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <script language="javascript" type="text/javascript">
         function GetManageDetails(personId) {
             $.ajax({
                 url: "../../api/Service/GetManagerDetails/" + "/fa/" + personId,
                 cache: false,
                 contentType: "application/json; charset=utf-8",
                 data: null,
                 success: function (data) {
                     RecieveManagerDetails(data);
                 },
                 error: function (data) {
                     error_Acour(data);
                 },
                 dataType: "json"
             });
         }



         function RecieveManagerDetails(data) {
             var ManagerPic;
             if (data.MANAGER_PICTURE == "") {
                 ManagerPic = "../../Images/excutive_manager_thumbnail.png"
             }
             else {
                 ManagerPic = "../../" + data.MANAGER_PICTURE
             }

             var RetTable = "<div class='mainmodal'><div class='modalform'><div class='modalhead'><span>نمایش جزئیات</span> <a href='#'>X</a> </div><div class='modalform_thumb'><img src='" + ManagerPic + "'/></div>";
             RetTable += "<div class='modalform_name'>نام : <span class='modalform_span'>" + data.PERSONName + "&nbsp;" + data.PersonLastName + "</span></div><div class='detail'>"
             RetTable += "<div class='modalform_detail'>سمت : <span class='modalform_span'>" + data.POSITION_NAME + "</span></div>"
             RetTable += "<div class='modalform_detail'>مدرک تحصیلی : <span class='modalform_span'>" + data.CERTIFICATE_NAME + "</span></div>"
             RetTable += "<div class='modalform_detail'>شماره تماس : <span class='modalform_span'>" + data.TEL_NO + "</span></div>"
             RetTable += "<div class='modalform_detail'>فکس : <span class='modalform_span'>" + data.FAX_NO + "</span></div>"
             RetTable += "<div class='modalform_detail'>پست الکترونیک : <span class='modalform_span'>" + data.EMAIL + "</span></div>"

             RetTable += "</div></div></div>";


             $('<div id="modal" class="modal">').fadeIn().insertAfter('head');
             $(RetTable).fadeIn().appendTo(".modal");

             $("#modal").click(function (evt) {
                 $(this).fadeOut();
             })
             $("#modal>*").click(function (event) {
                 event.stopPropagation();
             })
             $(document).bind('keydown', function (e) {
                 if (e.which == 27) {
                     $(".modal").fadeOut();
                 }
             });
             $('.modal a').click(function () {
                 $(this).parents(".modal").fadeOut();
             })
         }

         function error_Acour(data) {
             alert(data);
         }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="shownews_sidebar">
        <uc1:SoftwareSideBarWUC runat="server" ID="SoftwareSideBarWUC" />
        <uc2:OtherNewsWUC runat="server" ID="OtherNewsWUC" />
        <uc3:OtherAnnouncementsWUC runat="server" ID="OtherAnnouncementsWUC" />
    </div>
    <!--end of shownews sidebar !-->
    <div class="shownews_wrap">
        <div class="shownews_title">
            <div class="title">مدیران اجرایی
            </div>
        </div>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="excutive_item">
                    <div class="excutive_item_thumbnail">
                        <img src='<%#SetPicture(Container.DataItem)%>' runat="server" />
                    </div>
                    <ul class="excutive_detail">
                        <li class="excutive_title"><%#Eval("FirstName")%> <%#Eval("LastName")%></li>
                        <li>سمت : <%#Eval("PositionName")%></li>
                    </ul>
                    <a class="excutive_more" href="#" onclick='GetManageDetails(<%# Eval("ManagerId")%>)'>جزییات
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <%--<div class="excutive_item">
            <div class="excutive_item_thumbnail">
                <img src="Images/excutive_manager_thumbnail.png" />
            </div>
            <ul class="excutive_detail">
                <li class="excutive_title">نمونه نام کاربر</li>
                <li>سمت : رئیس مجتمع</li>
            </ul>
            <a class="excutive_more" href="#">جزییات
            </a>
        </div>
        <div class="excutive_item">
            <div class="excutive_item_thumbnail">
                <img src="Images/excutive_manager_thumbnail.png" />
            </div>
            <ul class="excutive_detail">
                <li class="excutive_title">نمونه نام کاربر</li>
                <li>سمت : رئیس مجتمع</li>
            </ul>
            <a class="excutive_more" href="#">جزییات
            </a>
        </div>
        <div class="excutive_item">
            <div class="excutive_item_thumbnail">
                <img src="Images/excutive_manager_thumbnail.png" />
            </div>
            <ul class="excutive_detail">
                <li class="excutive_title">نمونه نام کاربر</li>
                <li>سمت : رئیس مجتمع</li>
            </ul>
            <a class="excutive_more" href="#">جزییات
            </a>
        </div>--%>
    </div>
</asp:Content>

