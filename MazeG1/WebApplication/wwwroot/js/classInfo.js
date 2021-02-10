$(document).ready(function () {
    $('.class-list-element a').click(function () {
        $(this).closest('.class-block')
            .find('.class-info')
            .toggle();
    });
});
