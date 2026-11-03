<%@ Page Title="" Language="VB" MasterPageFile="~/SystemMng/MasterPage.master"
    AutoEventWireup="false" CodeFile="DesignHomePage.aspx.vb" Inherits="SystemMng_Home_DesignHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script src='<%# ResolveUrl("~/SystemMng/Scripts/jquery_0.js") %>' type="text/javascript"></script>
    <script src='<%# ResolveUrl("~/SystemMng/Scripts/jquery_1.js") %>' type="text/javascript"></script>
    <script src='<%# ResolveUrl("~/SystemMng/Scripts/arvand-v1.js") %>' type="text/javascript"></script>
    <script src='<%# ResolveUrl("~/SystemMng/Scripts/PageDemoScript.js") %>' type="text/javascript"></script>
    <style type="text/css">
        .btn-act {
            color: #003366;
            font-family: Tahoma;
            font-size: 12px;
            background-color: #FFFFFF;
            border: 1px solid #000000;
            padding: 5px;
            text-align: right;
            background-position: 2% 40%;
            padding-left: 30px;
            background-repeat: no-repeat;
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
            -khtml-border-radius: 4px;
            -border-radius: 4px;
            min-width: 90px;
        }

        .act-edit {
            background-image: url('../../Images/icon/save.png');
        }

        .btn-act:hover {
            color: #336699;
            background-color: #FFFFCC;
            border: 1px solid #3366CC;
            cursor: hand;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="widget-place" id="widget_place_0" style="width: 30%;" runat="server"
        clientidmode="Static">
        <div id="widget_child" class="widget">
            <div class="widget-header">
                <img src="../../Images/arrow_left.png" id="ImgCircle" alt="" />
                سیستم های موجود
            </div>
            <div class="widget-content">
                <input id="btnSubmitChange" type="button" value="ذخیره تغییرات" onclick="return UpdateWidget('default.aspx');"
                    class="btn-act act-edit" />
                <div id="MsgDiv">
                </div>
            </div>
            <div class="box-footer">
            </div>
        </div>
    </div>
    <div class="widget-place" id="widget_place_1" style="width: 30%;" runat="server"
        clientidmode="Static">
        <div id="Div1" class="widget">
            <div class="widget-header">
                <img src="../../Images/Widget/circle.png" id="Img1" />
                پنل 1
            </div>
            <div class="widget-content">
                در این پنل رها کنید
            </div>
            <div class="box-footer">
            </div>
        </div>
    </div>
    <div class="widget-place" id="widget_place_2" style="width: 30%;" runat="server"
        clientidmode="Static">
        <div id="Div3" class="widget">
            <div class="widget-header">
                <img src="../../Images/Widget/circle.png" id="Img2" />
                پنل 2
            </div>
            <div class="widget-content">
                در این پنل رها کنید
            </div>
            <div class="box-footer">
            </div>
        </div>
    </div>
</asp:Content>
