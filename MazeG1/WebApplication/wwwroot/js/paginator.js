$(document).ready(function () {
    $(".paginator-block .page").click(function () {
        var pageSize = $(".pageSize").val();
        var page = $(this).data("page") - 0;
        var sortColumn = $("#SortColumn").val();
        var sortDirection = $("#SortDirection").val();
        updatePage(page, pageSize, sortColumn, sortDirection);

        return false;
    });

    $(".pageSize").change(function () {
        var pageSize = $(this).val();
        var sortColumn = $("#SortColumn").val();
        var sortDirection = $("#SortDirection").val();
        updatePage(0, pageSize, sortColumn, sortDirection);
    });
});

function updatePage(page, pageSize, sortColumn, sortDirection) {
     window.location.href = paginatorUrl + `?page=${page}&pageSize=${pageSize}&sortColumn=${sortColumn}&sortDirection=${sortDirection}`;
}
