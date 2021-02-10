$( document ).ready( function () {

    init();

    function init() {
        var url = "/User/GetNotificationsNew";
        $.get(url).done(function (data) {
            for (var i = 0; i < data.length; i++) {
                $(".userNotifications").show(500);

                var tagCalendarEvent = $(".userNotifications-container.template").clone();
                tagCalendarEvent.removeClass("template");
                tagCalendarEvent.addClass("new");
                var calendarEventText = data[i].content;
                tagCalendarEvent.find(".message").text(calendarEventText);
                tagCalendarEvent[0].id = data[i].id;
                tagCalendarEvent.find(".check").click(accept);
                tagCalendarEvent.find(".remove").click(reject);
                tagCalendarEvent.find(".seen").click(view);
                $(".userNotifications").append(tagCalendarEvent);

                if (data[i].type != 1 && data[i].type != 2) {
                    tagCalendarEvent.addClass("notification");
                }
                else {
                    tagCalendarEvent.addClass("request");
                }
            }

            // render old
            var url = "/User/GetNotificationsOld";
            $.get(url).done(function (dataOld) {
                renderOld(dataOld);
            });
        });
    }

    function renderOld(data) {
            for (var i = 0; i < data.length; i++) {
                $(".userNotifications").show(500);

                var tagCalendarEvent = $(".userNotifications-container.template").clone();
                tagCalendarEvent.removeClass("template");
                tagCalendarEvent.addClass("old");
                var calendarEventText = data[i].content;
                tagCalendarEvent.find(".message").text(calendarEventText);
                tagCalendarEvent.find(".remove").click(reject);
                $(".userNotifications").append(tagCalendarEvent);
            }
    }

    function view() {
        var div = $(this).closest(".userNotifications-container");
        window.location.href = "/User/SeenNotification?notificationId=" + div[0].id;
    }

    function accept() {
        var div = $(this).closest(".userNotifications-container");
        window.location.href = "/User/RequestAgree?notificationId=" + div[0].id;
    }

    function reject() {
        var div = $(this).closest(".userNotifications-container");
        window.location.href = "/User/RequestReject?notificationId=" + div[0].id;
    }
} );

