var CntSel;
/////////////////////////////////
function InitialTimeControl(txtTime) {
    CntSel = 0;
}
//////////////////////////////
function SelectArea(txtTime) {
    if (window.event) {
        if (CntSel == 0) {
            var SelectRng = txtTime.createTextRange();
            SelectRng.moveStart('character', 0);
            SelectRng.moveEnd('character', -4);
            SelectRng.select();
        }
        else if (CntSel == 1) {
            var SelectRng = txtTime.createTextRange();
            SelectRng.moveStart('character', 1);
            SelectRng.moveEnd('character', -3);
            SelectRng.select();
        }
        else if (CntSel == 2) {
            var SelectRng = txtTime.createTextRange();
            SelectRng.moveStart('character', 3);
            SelectRng.moveEnd('character', -1);
            SelectRng.select();
        }
        else if (CntSel == 3) {
            var SelectRng = txtTime.createTextRange();
            SelectRng.moveStart('character', 4);
            SelectRng.moveEnd('character', 0);
            SelectRng.select();
        }
    }

}
//////////////////////////
function SetNum(e, txtTime, StartTime, EndTime) {
    var cCode;
    if (window.event)
        cCode = window.event.keyCode;     //IE
    else
        cCode = e.which;     //firefox

    if (cCode == 8 || cCode == 37 || cCode == 40) {
        if (CntSel > 0) {
            CntSel -= 1;
        }
        SelectArea(txtTime);

        if (window.event)
            event.cancel = true;
        else
            e.preventDefault();
        return false;
    }
    if (cCode == 38 || cCode == 39) {
        if (CntSel < 3) {
            CntSel += 1;
        }
        SelectArea(txtTime);
        if (window.event)
            event.cancel = true;
        else
            e.preventDefault();
        return false;
    }
    if ((cCode > 47 && cCode < 58) || (cCode > 95 && cCode < 106)) {
        if (cCode > 95 && cCode < 106) {
            cCode -= 48;
        }
    }
    else {
        if (window.event)
            event.cancel = true;
        else
            e.preventDefault();
        return false;
    }
    var CurNum = String.fromCharCode(cCode);
    if ((CntSel == 0 && CurNum > 2) || (CntSel == 2 && CurNum > 5)) {
        if (window.event)
            event.cancel = true;
        else
            e.preventDefault();
        return false;
    }
    var ValTime = txtTime.value.substr(0, 2) + txtTime.value.substr(3, 2);
    var NewTime;
    if (CntSel == 0) {
        NewTime = CurNum + ValTime.substr(1, 3);
    }
    else if (CntSel == 1) {
        NewTime = ValTime.substr(0, 1) + CurNum + ValTime.substr(2, 2);
    }
    else if (CntSel == 2) {
        NewTime = ValTime.substr(0, 2) + CurNum + ValTime.substr(3, 1);
    }
    else if (CntSel == 3) {
        NewTime = ValTime.substr(0, 3) + CurNum;
    }
    var IfValidSet = 0;
    if (NewTime.substr(0, 1) == 0 && StartTime.substr(0, 1) == 0) {
        if ((parseInt(NewTime.substr(1, 3)) >= parseInt(StartTime.substr(1, 3))) && (parseInt(NewTime.substr(1, 3)) <= parseInt(EndTime))) {
            IfValidSet = 1;
        }
    }
    else if (NewTime.substr(0, 1) == 0) {
        if ((parseInt(NewTime.substr(1, 3)) >= parseInt(StartTime)) && (parseInt(NewTime.substr(1, 3)) <= parseInt(EndTime))) {
            IfValidSet = 1;
        }
    }
    else if (StartTime.substr(0, 1) == 0) {
        if ((parseInt(NewTime) >= parseInt(StartTime.substr(1, 3))) && (parseInt(NewTime) <= parseInt(EndTime))) {
            IfValidSet = 1;
        }
    }
    else {
        if ((parseInt(NewTime) >= parseInt(StartTime)) && (parseInt(NewTime) <= parseInt(EndTime))) {
            IfValidSet = 1;
        }
    }
    if (IfValidSet == 1) {
        txtTime.value = NewTime.substr(0, 2) + ":" + NewTime.substr(2, 2);
        if (CntSel == 3) {
            SelectArea(txtTime);
            if (window.event)
                event.cancel = true;
            else
                e.preventDefault();
            return false;
        }
        CntSel += 1;
        SelectArea(txtTime);
    }
    else {
        if (NewTime.substr(0, 1) == 0 && CntSel == 0) {
            txtTime.value = StartTime.substr(0, 2) + ":" + StartTime.substr(2, 2);
            CntSel += 1;
            SelectArea(txtTime);
            if (window.event)
                event.cancel = true;
            else
                e.preventDefault();
            return false;
        }
        else if (NewTime.substr(0, 1) == 1 && CntSel == 0) {
            txtTime.value = EndTime.substr(0, 2) + ":" + EndTime.substr(2, 2);
            CntSel += 1;
            SelectArea(txtTime);
            if (window.event)
                event.cancel = true;
            else
                e.preventDefault();
            return false;
        }
        else if (NewTime.substr(0, 1) == 2 && CntSel == 0) {
            txtTime.value = EndTime.substr(0, 2) + ":" + EndTime.substr(2, 2);
            CntSel += 1;
            SelectArea(txtTime);
            if (window.event)
                event.cancel = true;
            else
                e.preventDefault();
            return false;
        }
    }

    if (window.event)
        event.cancel = true;
    else
        e.preventDefault();
    return false;
}