function getElementInPage() {
    var Content = document.getElementsByTagName("div");
    var retStr = '';
    for (var i = 0; i < Content.length; i++) {
        if (Content[i].id != null) {
            if (Content[i].id.toString().indexOf("widget_place") > -1) {
                var ContentChild = Content[i].childNodes;
                for (var j = 0; j < ContentChild.length; j++) {
                    if (ContentChild[j].id != null) {
                        if (ContentChild[j].id.toString().indexOf("widget_child") > -1) {
                            retStr += Content[i].id + "@" + ContentChild[j].id;

                            var bb = document.getElementById(ContentChild[j].id).getElementsByTagName("input");
                            for (k = 0; k < bb.length; k++) {
                                if (bb[k].type == "checkbox") {
                                    retStr += bb[k].checked ? "_1" : "_0";
                                }
                            }
                            retStr += "|";
                        }
                    }
                }
            }
        }
    }
    return retStr;
}

function UpdateWidget(pagename) {

    var strq = getElementInPage();
    document.getElementById("MsgDiv").innerHTML = "در حال ذخیره تغییرات...";

    var callSubArtt = "PageContetnt=" + strq;
    $.ajax({
        type: "POST",
        url: "../Handler/AssignWebparts.ashx?p=in&page=" + pagename,
        data: callSubArtt,
        cache: false,
        success: function (data) {
            SuccessAction(data);
        }
    });
    return false;
}

function SuccessAction(retData) {
    if (retData == "0") {
        document.getElementById("MsgDiv").innerHTML = "خطا در عملیات ، صفحه پس از چند ثانیه مجددا بارگزاری می شود.";
        setTimeout("Go2NewUrl('Home/DesignHomePage.aspx')", 5000);
    }
    else {
        document.getElementById("MsgDiv").innerHTML = retData;
    }
}
function Go2NewUrl(url) {
    document.getElementById("MainFrame").src = url;
}
function ErroreAction(RetErrore) {
    __doPostBack('', '');
    document.getElementById("MsgDiv").innerHTML = RetErrore;
}