$(document).ready(function () {

    $('.keyClassesItem ').click(function () {
        $(this)
            .closest('.keyClassesItem')
            .find('.keyClassPropertys')
            .toggle();
    });

});

