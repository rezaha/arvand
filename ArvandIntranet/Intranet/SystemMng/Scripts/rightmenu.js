window.onload= function () {
    pageLoad();
}

function pageLoad() {
    menu_load()
}
function menu_load() {
    var MenuStatusVal = document.getElementById("MenuStatus");
    if (MenuStatusVal.value == "1") {
        document.getElementById("CloseMenu").style.display = "block";
        document.getElementById("OpenMenu").style.display = "none";
        document.getElementById("Rightmenu").style.display = "block";
        document.getElementById("tdRightmenu").style.width = "200px";
    }
    else {
        document.getElementById("CloseMenu").style.display = "none";
        document.getElementById("OpenMenu").style.display = "block";
        document.getElementById("Rightmenu").style.display = "none";
        document.getElementById("tdRightmenu").style.width = "0px";
    }
}
function menu_open(e) {
    document.getElementById("MenuStatus").value = "1";
    menu_load();
}
function menu_close(e) {
    document.getElementById("MenuStatus").value = "0";
    menu_load();
}
