<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="false" CodeFile="ShowPoll.aspx.vb" Inherits="ShowPoll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="webpart">
        <div class="webpart_content">
            <div class="webpart" style="font-family: tahoma;">
                <div runat="server" id="pagePannel" class="webpart_content">
                    <h2 style="font-size: 17px; font-weight: normal; text-indent: 35px;">
                        <asp:Label ID="lblMultiQuesOneAnswer" runat="server" Text="سوالات چند گزینه ای" meta:resourcekey="lblMultiQuesOneAnswerResource1"></asp:Label>
                    </h2>
                    <table class="question">
                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <asp:HiddenField ID="HfQID" runat="server" Value='<%# Eval("QuestionId") %>' />
                                    <td><%#Eval("QuestionDescription")%></td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="radio_button_container">
                                            <asp:RadioButtonList ID="rbtnAnswers" runat="server" CellPadding="5" CellSpacing="3" RepeatDirection="Horizontal" CssClass="radio_button" Width="100%">
                                            </asp:RadioButtonList>
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>

                    </table>
                    <h2 style="font-size: 17px; font-weight: normal; text-indent: 35px;">
                        <asp:Label ID="lblRemarkQuestion" runat="server" Text="سوالات تشریحی" meta:resourcekey="lblRemarkQuestionResource1"></asp:Label>
                    </h2>
                    <table class="question">
                        <asp:Repeater ID="Repeater3" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <asp:HiddenField ID="HfQID" runat="server" Value='<%# Eval("QuestionId") %>' />
                                    <td><%#Eval("QuestionDescription")%></td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="radio_button_container">
                                            <asp:TextBox CssClass="surveys_exp" TextMode="MultiLine" ID="txtAnswerDescription" runat="server" meta:resourcekey="txtAnswerDescriptionResource1"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <div class="suveys_btn">
                        <asp:LinkButton CssClass="webpart_btn" ID="lnkAccept" runat="server" Text="تایید" meta:resourcekey="lnkAcceptResource1"></asp:LinkButton>
                        <asp:LinkButton CssClass="webpart_btn" ID="lnkCleare" runat="server" Text="دوباره نویسی" meta:resourcekey="lnkCleareResource1"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
