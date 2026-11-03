<%@ Page Title="ارتباط با ما" Language="VB" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="false" CodeFile="ContactUs.aspx.vb" Inherits="ContactUs" %>

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
            <h2>تماس با ما
            </h2>

        </div>
        <p class="contact_txt">
            اطلاعات مورد نیاز را وارد کرده و روی دکمه ارسال کلیک کنید
        </p>
        <ul class="contact_ui">

            <li>
                <span>نام شما  :
                </span>
                <asp:TextBox ID="txtName" CssClass="textbox" runat="server"></asp:TextBox>
            </li>
            <li>
                <span>آدرس ایمیل  :
                </span>
                <asp:TextBox ID="txtEmail" CssClass="textbox" runat="server"></asp:TextBox>
            </li>
            <li>
                <span style="vertical-align: top">متن  :
                </span>
                <asp:TextBox TextMode="MultiLine" Height="70" CssClass="textbox" ID="txtBody" runat="server"></asp:TextBox>
            </li>
            <li>
                <span style="vertical-align: top">تصویر امنیتی  :
                </span>
                <asp:Image ID="imgCaptchaText" runat="server" AlternateText="CaptchaImage" />
                <asp:ImageButton ID="btnRefreshCaptcha" runat="server" ImageUrl="~/images/contact/refresh.png"
                    OnClick="btnRefreshCaptcha_Click" Style="width: 15px" />
                <asp:HiddenField ID="hfCaptchaText" runat="server" />
            </li>
            <li>
                <asp:TextBox CssClass="contact_txt_left" ID="txtCaptcha" runat="server" AutoCompleteType="None"></asp:TextBox>
            </li>
            <li>
                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Text=""></asp:Label>
            </li>
            <li>
                <asp:LinkButton ID="lnkBtnSend" runat="server" CssClass="contact_btn">ارسال</asp:LinkButton>
            </li>
        </ul>
        <ul class="contact_adrress">
            <li>
                <img src="~/Images/building_ico.png" runat="server" />
                <span class="contact_title">آدرس :</span>
            </li>
            <li>
                <p class="contact_detail" id="lblAddress" runat="server">
                    منطقه ویژه اقتصادی سایت 15 - شرکت پتروشیمی
                </p>
            </li>
            <li>
                <img src="~/Images/telephone_ico.png" runat="server" />
                <span class="contact_title">شماره تماس :</span>
            </li>
            <li>
                <span class="contact_detail" id="lblTel" runat="server">09273849586743
                </span>
            </li>
            <li>
                <img src="~/Images/fax_ico.png" runat="server" />
                <span class="contact_title">ایمیل :</span>
            </li>
            <li>
                <span class="contact_detail" id="lblRayaName" runat="server">09273849586743
                </span>
            </li>
        </ul>
    </div>
</asp:Content>
