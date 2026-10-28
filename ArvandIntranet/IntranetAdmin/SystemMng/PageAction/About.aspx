<%@ Page Title="" Language="VB" MasterPageFile="~/SystemMng/MasterPage.master" AutoEventWireup="false"
    CodeFile="About.aspx.vb" Inherits="SystemMng_Define_About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellspacing="3" cellpadding="3" width="100%">
        <tr>
            <td class="tdInfoHeader" align="center" colspan="3">درباره واحد</td>
        </tr>
        <tr>
            <td>
                <div id="divTopShared">
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <table cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td>
                            <table cellspacing="0" cellpadding="0" width="100%">
                                <tr>
                                    <td class="tdInfoItem Infotxt" align="right">متن خلاصه
                                        <img id="Img1" src="~/Images/NotNull.png" alt="NotNull" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdInfoItem" align="right">
                                        <telerik:RadEditor runat="server" ID="txtHtml_content_persian_summary" SkinID="DefaultSetOfTools" Height="300px"
                                            DialogsCssFile="../Css/Editor/RadEditor_Dialogs_RTL.css"
                                            ContentAreaCssFile="../Css/Editor/EditorContentArea_RTL.css"
                                            ToolsFile="EditorToolsFileLimited.xml" DialogHandlerUrl="~/Telerik.Web.UI.DialogHandler.axd">
                                            <ImageManager EnableAsyncUpload="true"></ImageManager>
                                        </telerik:RadEditor>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="متن خلاصه وارد نشده است"
                                            Display="None" ControlToValidate="txtHtml_content_persian_summary" Text="*" ValidationGroup="p"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdInfoItem Infotxt" align="right">متن ادامه مطلب
                                        <img id="Img35" src="~/Images/NotNull.png" alt="NotNull" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdInfoItem" align="right">
                                        <telerik:RadEditor runat="server" ID="txtHtml_content_persian" SkinID="DefaultSetOfTools" Height="700px"
                                            DialogsCssFile="../Css/Editor/RadEditor_Dialogs_RTL.css"
                                            ContentAreaCssFile="../Css/Editor/EditorContentArea_RTL.css"
                                            ToolsFile="EditorToolsFileLimited.xml" DialogHandlerUrl="~/Telerik.Web.UI.DialogHandler.axd">
                                            <ImageManager EnableAsyncUpload="true"></ImageManager>
                                        </telerik:RadEditor>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="5px">
                                <tr>
                                    <td style="text-align: center;">
                                        <asp:Button Text="ذخیره" runat="server" Style="width: 100px; text-align: center;" ID="btnSave" ValidationGroup="p"
                                            CssClass="btn-act act-add" />
                                        <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false" runat="server" ValidationGroup="p"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</asp:Content>

