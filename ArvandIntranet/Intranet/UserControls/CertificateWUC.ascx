<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CertificateWUC.ascx.vb" Inherits="UserControls_CertificateWUC" %>

<script type="text/javascript">
    $(function () {
        $('.certificate').cycle({
            fx: 'turnUp',
            prev: '.cer_next',
            next: '.cer_prev',
            speed: 1000,
            backwards: true,
            pause: true,
            easeOut: 'easeInOutExpo',
            easeIn: 'easeInOutExpo',
            pauseOnPagerHover: 1,
        });
    })
</script>
<div class="webpart">
    <table cellpadding="0" cellspacing="0" class="part_header">
        <tr>

            <td class="webpart_text">
                <a>
                    <img src="~/images/webpart_ico/about_header_icon.png" runat="server" />
                    <span style="vertical-align: top;">گواهینامه ها
                    </span>
                </a>
            </td>
            <td class="webpart_border"></td>
        </tr>
    </table>
    <div class="content-div">
        <div class="certificate">
           
            <div class="cer_item">
                <div class="cer_thumb">
                    <a href="~/UploadFiles/Cert/HSE-MS-(P).jpg" target="_blank" runat="server" >
                        <img height="107" width="75" id="Img1" src="~/UploadFiles/Cert/thumb/HSE-MS-(P)-thumb.jpg" runat="server"/>
                    </a>
                </div>
                <div class="cer_content">
                    <a class="cer_title">توضیحات
                    </a>
                    <a class="cer_description">سيستم مديريت HSE مبتني بر نظامنامه HSE وزارت نفت ايران 
                    </a>
                </div>
            </div>


            <div class="cer_item">
                <div class="cer_thumb">
                    <a href="~/UploadFiles/Cert/IMS-(P).jpg" target="_blank" runat="server" >
                        <img height="107" width="75" id="Img2" src="~/UploadFiles/Cert/thumb/IMS-(P)-thumb.jpg" runat="server" />
                    </a>
                </div>
                <div class="cer_content">
                    <a class="cer_title">توضیحات
                    </a>
                    <a class="cer_description">سيستم مديريت يكپارچه  (IMS) 
                    </a>
                </div>
            </div>


            <div class="cer_item">
                <div class="cer_thumb">
                    <a href="~/UploadFiles/Cert/ISO-9001-2008-(P).jpg" target="_blank" runat="server">
                        <img height="107" width="75" id="Img3" src="~/UploadFiles/Cert/thumb/ISO-9001-2008-(P)-thumb.jpg" runat="server" />
                    </a>
                </div>
                <div class="cer_content">
                    <a class="cer_title">توضیحات
                    </a>
                    <a class="cer_description">سيستم مبتني بر ISO 9001 
                    </a>
                </div>
            </div>


            <div class="cer_item">
                <div class="cer_thumb">
                    <a href="~/UploadFiles/Cert/ISO-14001-2004-(P).jpg" target="_blank" runat="server" >
                        <img height="107" width="75" id="Img4" src="~/UploadFiles/Cert/thumb/ISO-14001-2004-(P)_Thumb.jpg" runat="server" />
                    </a>
                </div>
                <div class="cer_content">
                    <a class="cer_title">توضیحات
                    </a>
                    <a class="cer_description">سيستم مبتني بر ISO 14001 
                    </a>
                </div>
            </div>

            <div class="cer_item">
                <div class="cer_thumb">
                    <a href="~/UploadFiles/Cert/OHSAS-18001-2007-(P).jpg" target="_blank" runat="server">
                        <img height="107" width="75" id="Img5" src="~/UploadFiles/Cert/thumb/OHSAS-18001-2007-Thumb.jpg" runat="server"/>
                    </a>
                </div>
                <div class="cer_content">
                    <a class="cer_title">توضیحات
                    </a>
                    <a class="cer_description">سيستم مبتني بر OHSAS 18001 
                    </a>
                </div>
            </div>

             <div class="cer_item">
                <div class="cer_thumb">
                    <a  href="~/UploadFiles/Cert/null_000.jpg" target="_blank" runat="server">
                        <img height="107" width="75" id="Img6" src="~/UploadFiles/Cert/thumb/null_000-thumb.jpg" runat="server"/>
                    </a>
                </div>
                <div class="cer_content">
                    <a class="cer_title">توضیحات
                    </a>
                    <a class="cer_description">گواهی سرآمدی پروژه
                    </a>
                </div>
            </div>


             <div class="cer_item">
                <div class="cer_thumb">
                    <a   href="~/UploadFiles/Cert/tali-2.jpg" target="_blank" runat="server">
                        <img height="107" width="75" id="Img7" src="~/UploadFiles/Cert/thumb/tali-2-thumb.jpg" runat="server"/>
                    </a>
                </div>
                <div class="cer_content">
                    <a class="cer_title">توضیحات
                    </a>
                    <a class="cer_description">گواهینامه تعالی
                    </a>
                </div>
            </div>

              <div class="cer_item">
                <div class="cer_thumb">
                    <a   href="~/UploadFiles/Cert/tali-4.jpg" target="_blank" runat="server">
                        <img height="107" width="75" id="Img8" src="~/UploadFiles/Cert/thumb/tali-4-thumb.jpg" runat="server"/>
                    </a>
                </div>
                <div class="cer_content">
                    <a class="cer_title">توضیحات
                    </a>
                    <a class="cer_description">جایزه تعالی صنایع پتروشیمی
                    </a>
                </div>
            </div>


        </div>
        <div class="cer_nav">
            <a class="cer_next" href="#">قبلی</a>
            <a class="cer_prev" href="#">بعدی</a>
        </div>
    </div>


</div>
