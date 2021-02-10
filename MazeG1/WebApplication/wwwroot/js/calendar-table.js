$( document ).ready( function () {

    init();

    function init() {
        var cachedName = sessionStorage.getItem("calendar-table-name");
        var calendarTableName = !!cachedName
            ? cachedName
            : $(".calendar-table").attr("name");
        showOneTable(calendarTableName);
    }

    function showOneTable(calendarTableName) {
        $(".calendar-event").hide();
        $(".calendar-table").attr("name", calendarTableName);
        sessionStorage.setItem("calendar-table-name", calendarTableName);
        var calendarEventName = GetEventName(calendarTableName);
        $(calendarEventName).show();
    }

    $(".calendar-block .icon.event-title").click( function () {
        var classEvent = $(this).attr("data-table-class");
        showOneTable(classEvent);
    } );

    function GetEventName(calendarTableName) {
        switch (calendarTableName) {
            case "table-main-event": return ".calendar-main-event";
            case "table-past-event": return ".calendar-past-event";
            case "table-coming-event": return ".calendar-coming-event";
            default: return '.calendar-main-event'
        }
    }

    $(".calendar-block").click( function () {
        var pageSize = $(".pageSize").val();
        var sortColumn = $("#SortColumn").val();
        var sortDirection = $("#SortDirection").val();
        updatePage(0, pageSize, sortColumn, sortDirection);

        return false;
    } );

    $(".form-calendar-create").submit( function () {
        return checkInputNotEmpty("Title")
            && checkInputNotEmpty("Description");
    } );

    $(".form-calendar-typeEvent-create").submit( function () {
        return checkInputNotEmpty("NameOfTypeEvent");
    } );

    function checkInputNotEmpty(inputName) {
        var tag = $( `[name=${inputName}]` );
        var isValid = !!tag.val();
        tag.toggleClass("input-validation-error", !isValid);
        return isValid;
    }
} );

