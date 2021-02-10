function showMessage(textMessage) {
    $('.message').text(textMessage);

    setTimeout(function () {
        $(".user-event-container").remove();
    }, 10 * 1000);
};

function showMessage(textMessage, colorMessage) {
    $('.user-event-container').show("slow");
    $('.user-event-container').css('display', 'flex');
    $('.user-event').css('background', `${colorMessage}`);
    $('.message').text(textMessage);

    setTimeout(function () {
        $(".user-event-container").hide();
    }, 15 * 1000);
};




