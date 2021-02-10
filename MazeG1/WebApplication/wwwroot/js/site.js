$(document).ready(function () {
    $('.login-popup').hide();

    $('.nav-link.login').click(function () {
        $('.login-popup').show();
        return false;
    });

    $('.cover').click(function () {
        $('.login-popup').hide();
    });

    $('.close').click(function () {
        $('.login-popup').hide();
    });

    $('.loginban-popup').hide();

    $('.logban').click(function () {
        $('.loginban-popup').show();
        return false;
    });

    $('.cover').click(function () {
        $('.loginban-popup').hide();
    });

    $('.close').click(function () {
        $('.loginban-popup').hide();
    });
});
