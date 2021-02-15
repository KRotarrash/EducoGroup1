$(document).ready(function () {
    console.log('111');
    $("#searchInput").on('keyup', function () {
        console.log('123');
        var value = $(this).val().toLowerCase();
        $("#userTable tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
   
});
