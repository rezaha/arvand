/* Behaviour needed by the original Web Forms controls, without their old skin. */
window.clickButton = function (event, id) {
    if ((event.which || event.keyCode) !== 13) return true;
    var button = document.getElementById(id);
    if (button) button.click();
    return false;
};
if (window.jQuery) jQuery(function ($) {
    if ($.fn.PikaChoose && $('#pikame').length) $('#pikame').PikaChoose({carousel: true});
    if ($.fn.cycle && $('#s7').children().length > 1) $('#s7').cycle({fx: 'fade', timeout: 5000});
    if ($.fn.list_ticker) $('#slide,.rules').each(function () {
        if ($(this).children().length > 1) $(this).list_ticker({speed: 8000, effect: 'fade'});
    });
    // A failed article photo must not displace the surrounding article or list.
    $('.portal-content img').bind('error', function () { this.classList.add('portal-image-unavailable'); });
    $('.portal-content img').each(function () {
        if (this.complete && this.naturalWidth === 0) this.classList.add('portal-image-unavailable');
    });
});
