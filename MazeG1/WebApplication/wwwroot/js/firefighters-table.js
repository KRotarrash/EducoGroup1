$( document ).ready( function () {

    init();

    function init() {
        var cachedName = sessionStorage.getItem("firefighters-table-name");
        var firefightersTableName = !!cachedName
            ? cachedName
            : $(".firefighters-table").attr("name");
        showOneTable(firefightersTableName);
    }

    function showOneTable(firefightersTableName) {
        $(".firefighters-inspection").hide();
        $(".firefighters-table").attr("name", firefightersTableName);
        sessionStorage.setItem("firefighters-table-name", firefightersTableName);
        var firefightersInspectionName = GetTabName(firefightersTableName);
        $(firefightersInspectionName).show();
    }

    $(".firefighters-block .icon.inspection-title").click( function () {
        var classInspection = $(this).attr("data-table-class");
        showOneTable(classInspection);
    } );

    function GetTabName(firefightersTableName) {
        switch (firefightersTableName) {
            case "table-main-inspection": return ".firefighters-main-inspection";
            case "table-schedule-inspection": return ".firefighters-schedule-inspection";
            default: return '.firefighters-main-inspection'
        }
    }

    $(".firefighters-block").click( function () {
        var pageSize = $(".pageSize").val();
        var sortColumn = $("#SortColumn").val();
        var sortDirection = $("#SortDirection").val();
        updatePage(0, pageSize, sortColumn, sortDirection);

        return false;
    } );

    $(".form-firefighters-typeSafe-create").submit( function () {
        return checkInputNotEmpty("NameOfTypeSafetyAssessment");
    } );

    function checkInputNotEmpty(inputName) {
        var tag = $( `[name=${inputName}]` );
        var isValid = !!tag.val();
        tag.toggleClass("input-validation-error", !isValid);
        return isValid;
    }
} );

