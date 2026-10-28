
$(function () {

    // Use the cookie plugin

    $.fn.EasyWidgets({

        behaviour: {
            useCookies: false
        },

        effects: {
            effectDuration: 1000,
            widgetShow: 'slide',
            widgetHide: 'slide',
            widgetClose: 'slide',
            widgetExtend: 'slide',
            widgetCollapse: 'slide',
            widgetOpenEdit: 'slide',
            widgetCloseEdit: 'slide',
            widgetCancelEdit: 'slide'

        }

    });

    // Some Ajax progress stuff for Widgets on demand

    $('#ajax-progress').ajaxStart(function () {
        $(this).show();
    }).ajaxStop(function () {
        $(this).hide();
    });

});

$(function () {


    /*call slideshow of gallery for first load( before edit )*/
    galleryShowEffect();

    var galleryid = $('.gallerySubjectId').val();
    $('.' + galleryid + '_galleryChecked').attr("checked", "checked");


});

function AddWidget(url, placeId) {
    $.get(url, function (html) {
        $.fn.AddEasyWidget(html, placeId);
    });
}
/* for gallery box */
var timeout;
function galleryShowEffect() {
    clearInterval(timeout);
    var count;
    $('.ppt li:gt(0)').hide();
    count = $('.ppt li').length;
    if (count == 1) {
        $('#fwd').css({ 'opacity': '0.4', 'cursor': 'default' });
        $('#back').css({ 'opacity': '0.4', 'cursor': 'default' });
        $('#playGallery').css({ 'opacity': '0.4', 'cursor': 'default' });
        $('#pauseGallery').hide();
    } else if (count > 1) {
        $('.ppt li:last').addClass('last');
        $('.ppt li:first').addClass('first');
        $('#fwd').css({ 'opacity': '1', 'cursor': 'pointer' });
        $('#back').css({ 'opacity': '1', 'cursor': 'pointer' });
        $('#playGallery').css({ 'opacity': '1', 'cursor': 'pointer' });
        var cur = $('.ppt li:first');
        showPlay();
        $('#fwd').click(function () {
            cur.fadeOut(1000);
            if (cur.attr('class') == 'last')
                cur = $('.ppt li:first');
            else
                cur = cur.next();
            cur.fadeIn(1000);
        });

        $('#back').click(function () {
            cur.fadeOut(1000);
            if (cur.attr('class') == 'first')
                cur = $('.ppt li:last');
            else
                cur = cur.prev();
            cur.fadeIn(1000);
        });
        play();
        showPause();
    }
    $('#pauseGallery').click(function () {
        pause();
        showPlay();
    });

    $('#playGallery').click(function () {
        play();
        showPause();
    });
    function showPause() {
        $('#playGallery').hide();
        $('#pauseGallery').show();
    }
    function showPlay() {
        $('#pauseGallery').hide();
        $('#playGallery').show();
    }
    function play() {
        clearInterval(timeout);
        timeout = setInterval(function () {
            cur.fadeOut(1000);
            if (cur.attr('class') == 'last')
                cur = $('.ppt li:first');
            else
                cur = cur.next();
            cur.fadeIn(1000);
        }, 3000);
    }
    function pause() {
        clearInterval(timeout);
    }
}