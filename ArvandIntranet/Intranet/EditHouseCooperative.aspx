<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="false" CodeFile="EditHouseCooperative.aspx.vb" Inherits="EditHouseCooperative" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function isNum(e) {
            var keycode;
            if (window.event) keycode = window.event.keyCode;
            else if (e) keycode = e.which;
            if (keycode > 31 && (keycode < 48 || keycode > 57))
                return false;
            return true;
        }
    </script>
    <style type="text/css">
        table .lbl_Rtl {
            direction: rtl;
        }

        .container {
            padding-right: 15px;
            padding-left: 15px;
            margin-right: auto;
            margin-left: auto;
        }

        td, tr, table, .webpart_btn {
            font-family: Tahoma;
            font-size: 14px;
        }

        .txtInfoRight {
            box-sizing: border-box;
            padding: 5px 10px;
            width: 50%;
            margin: 8px 0;
        }

        input[type=text] {
            border: 1px solid;
            border-radius: 4px;
        }

        .drp {
            width: 50%;
            border: 1px solid;
            padding: 5px 10px;
        }

        .suveys_btn {
            padding: 30px;
            text-align: center;
        }

        .tdInfoHeader {
            padding: 20px;
            background-color: rgb(0, 115, 153);
            border-radius: 5px;
            color: white;
        }

        .webpart_btn {
            border: 1px solid;
            padding: 10px;
            background-color: #04497d;
            border-radius: 3px;
            color: white;
            width: 70px;
            text-decoration: none;
        }

            .webpart_btn:hover {
                background-color: #0e1f42;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="webpart">
        <div class="webpart_content">
            <div class="webpart" style="font-family: tahoma;">
                <div runat="server" id="pagePannel" class="webpart_content">
                    <div>
                        <table cellspacing="3" cellpadding="3" width="100%" class="container">
                            <tr>
                                <td class="tdInfoHeader lbl_Rtl" align="center" colspan="2">
                                    <h3>ویرایش عضویت در تعاونی مسکن</h3>
                                </td>
                            </tr>
                            <tr>
                                <td width="50%" class="lbl_Rtl">
                                    <table cellspacing="3" cellpadding="3" width="100%">
                                         <tr>
                                            <td class="tdInfoItem" align="center">کد ملی</td>
                                            <td class="tdInfoItem" colspan="2">
                                                <asp:TextBox ID="txtNationalId" MaxLength="10" onkeypress="return isNum(event);" runat="server" CssClass="txtInfoRight" TabIndex="4"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="شماره ملی وارد نشده است"
                                                    Display="Dynamic" ControlToValidate="txtNationalId" Text="*"
                                                    ValidationGroup="Document"></asp:RequiredFieldValidator>

                                            </td>
                                             
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnSearch" runat="server" Text="جستجو" /> &nbsp; <asp:Button ID="btnReturn" runat="server" Text="بازگشت" />
                                            </td>
                                        </tr>
                                       <%-- <tr>
                                            <td class="tdInfoItem" align="center">نام
                                            </td>
                                            <td class="tdInfoItem">
                                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="txtInfoRight" TabIndex="1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="نام وارد نشده است"
                                                    Display="Dynamic" ControlToValidate="txtFirstName" Text="*"
                                                    ValidationGroup="Document"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdInfoItem" align="center">نام خانوادگی</td>
                                            <td class="tdInfoItem" colspan="2">
                                                <asp:TextBox ID="txtlastName" runat="server" CssClass="txtInfoRight" TabIndex="2"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="نام خانوادگی وارد نشده است"
                                                    Display="Dynamic" ControlToValidate="txtlastName" Text="*"
                                                    ValidationGroup="Document"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdInfoItem" align="center">نام پدر
                                            </td>
                                            <td class="tdInfoItem">
                                                <asp:TextBox ID="txtFatherName" runat="server" CssClass="txtInfoRight" TabIndex="3"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="نام پدر وارد نشده است"
                                                    Display="Dynamic" ControlToValidate="txtFatherName" Text="*"
                                                    ValidationGroup="Document"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                       
                                          <tr>
                                            <td class="tdInfoItem" align="center">شماره پرسنلی
                                            </td>
                                            <td class="tdInfoItem">
                                                <asp:TextBox ID="txtPersonNo" MaxLength="10" onkeypress="return isNum(event);" runat="server" CssClass="txtInfoRight" TabIndex="5"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="شماره پرسنلی وارد نشده است"
                                                    Display="Dynamic" ControlToValidate="txtPersonNo" Text="*"
                                                    ValidationGroup="Document"></asp:RequiredFieldValidator>
                                            </td>

                                        </tr>--%>

                                    </table>
                                </td>
                                <td width="50%" class="lbl_Rtl">
                                    <table cellspacing="3" cellpadding="3" width="100%">
                                       <%-- <tr>
                                            <td class="tdInfoItem" align="center">نوع استخدام
                                            </td>
                                            <td class="tdInfoItem" align="right">
                                                <asp:DropDownList ID="drpEmpType" runat="server" CssClass="drp" TabIndex="6">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="نوع استخدام انتخاب نشده است"
                                                    Display="Dynamic" ControlToValidate="drpEmpType" Text="*" InitialValue="0"
                                                    ValidationGroup="Document"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                      
                                        <tr>
                                            <td class="tdInfoItem" align="center">محل کار
                                            </td>
                                            <td class="tdInfoItem">
                                                <asp:TextBox ID="txtWorkLocation" runat="server" CssClass="txtInfoRight" TabIndex="7"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="محل کار وارد نشده است"
                                                    Display="Dynamic" ControlToValidate="txtWorkLocation" Text="*"
                                                    ValidationGroup="Document"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>--%>
                                          <tr>
                                            <td class="tdInfoItem" align="center">محل مورد تقاضای مسکن
                                            </td>
                                            <td class="tdInfoItem" align="right">
                                                <asp:DropDownList ID="drpCooperativeLocation" runat="server" CssClass="drp" TabIndex="8">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="محل تعاونی مسکن انتخاب نشده است"
                                                    Display="Dynamic" ControlToValidate="drpCooperativeLocation" Text="*" InitialValue="0"
                                                    ValidationGroup="Document"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                          <tr>
                                            <td class="tdInfoItem" align="center">شماره همراه
                                            </td>
                                            <td class="tdInfoItem">
                                                <asp:TextBox ID="txtMobileNo" runat="server" CssClass="txtInfoRight" MaxLength="11" TabIndex="9"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="شماره همراه وارد نشده است"
                                                    Display="Dynamic" ControlToValidate="txtMobileNo" Text="*"
                                                    ValidationGroup="Document"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdInfoItem" align="center">شماره محل کار</td>
                                            <td class="tdInfoItem" colspan="2">
                                                <asp:TextBox ID="txtTelNo" runat="server" CssClass="txtInfoRight" MaxLength="11" TabIndex="10"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                        </table>
                        <div class="suveys_btn">
                            <asp:LinkButton CssClass="webpart_btn" ID="lnkAccept" ValidationGroup="Document" runat="server" Visible="False" Text="تایید" TabIndex="9"></asp:LinkButton>
                            <asp:Label runat="server" ForeColor="red" ID="lblMessage"></asp:Label>
                        </div>
                        <div>
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
