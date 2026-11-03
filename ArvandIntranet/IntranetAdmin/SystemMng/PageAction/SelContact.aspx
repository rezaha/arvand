<%@ Page Title="" Language="VB" MasterPageFile="~/SystemMng/MasterPage.master" AutoEventWireup="false"
    CodeFile="SelContact.aspx.vb" Inherits="SystemMng_Define_SelContact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView ID="gridview1" runat="server" CssClass="grid" GridLines="None" AutoGenerateColumns="False"
                  EmptyDataText="داده وجود ندارد..." ShowFooter="false" BackColor="White" BorderColor="White"
                  BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
                  AllowPaging="True">
        <RowStyle CssClass="row" />
        <AlternatingRowStyle CssClass="altrow" />
        <SelectedRowStyle CssClass="selectedrow" />
        <Columns>
            <asp:TemplateField HeaderText="خوانده شده" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnRead" runat="server" ImageUrl="~/Images/icon-pencil.gif"
                                     CommandName="read" CausesValidation="false" CommandArgument='<%#CLSHash.Encode(Eval("CONTACT_ID")) %>' />
                    <asp:Literal ID="litIS_READ" runat="server" Visible="False" Text='<%#Eval("IS_READ")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="نام مخاطب" ItemStyle-HorizontalAlign="Center"
                               HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="CONTACT_NAME" runat="server" Text='<%#Eval("CONTACT_NAME")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ایمیل" ItemStyle-HorizontalAlign="Center"
                               HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="CONTACT_EMAIL" runat="server" Text='<%#Eval("CONTACT_EMAIL")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="متن پیام" ItemStyle-HorizontalAlign="Center"
                               HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="CONTACT_TEXT" runat="server" Text='<%#Eval("CONTACT_TEXT")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="تاریخ" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="CONTACT_DATE" runat="server" Text='<%#Eval("CONTACT_DATE")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ساعت" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="CONTACT_TIME" runat="server" Text='<%#Eval("CONTACT_TIME")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="حذف" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnDelete" runat="server" ImageUrl="~/Images/icon-delete.gif"
                                     CommandName="del" CausesValidation="false" CommandArgument='<%#CLSHash.Encode(Eval("CONTACT_ID"))%>'
                                     OnClientClick="return confirm('آیا دستور حذف را تایید می کنید؟');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>
