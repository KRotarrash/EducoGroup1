$(document).ready(function () {

    $('.userban').click(function () {
        $('#logban').css('display', 'flex');

        var id = $(this).attr('data-id');
        var name = $(this).attr('data-name');

        $('#user-id').val(id);
        $('#user-name').val(name);
    });

    $('.cancel').click(function () {
        $('#logban').hide();
    });

    $('.block').click(function () {
        $('#logban').hide();

        var id = $('#user-id').val();
        var name = $('#user-name').val();
        var dateBan = $('#dateban').val();

        if ($('#forever').is(':checked')) {
            var dateBan = "9999-12-31 23:59:59"
        } 

        var url = `/Police/UserBlock?id=${id}&dateBan=${dateBan}`;

        $.get(url).done(function () {
            $('.user-event-container').show("slow");
            $('.user-event-container').css('display', 'flex');

            showMessage(`Пользователь ${name} заблокирован`);
        });
    });

    $('.close-message').click(function () {
        $('.user-event-container').hide();
    });

});
