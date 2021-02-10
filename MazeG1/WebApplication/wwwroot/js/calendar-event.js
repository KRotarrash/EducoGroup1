$( document ).ready( function () {

    init();

    function init() {
        var url = "/CalendarEvent/GetCalendarEvents";
        $.get(url).done( function (data) {
            for (var i = 0; i < data.length; i++) {
                $(".calendarEvent").show(500);

                var tagCalendarEvent = $(".calendarEvent-container.template").clone();
                tagCalendarEvent.removeClass("template");
                var calendarEventText = data[i];
                tagCalendarEvent.find(".message").text(calendarEventText);
                tagCalendarEvent.find(".bad").click(close);
                $(".calendarEvent").append(tagCalendarEvent);
            }

            setTimeout( function () {
                $(".calendarEvent-container:not(.template)").remove();
            }, 10 * 1000 );
        } );
    }

    $(".calendarEvent .bad").click(close);

    function close() {
        $( this ).closest(".calendarEvent-container").remove();
    }
} );

