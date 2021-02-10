$(document).ready(function () {
        //работает не до конца правильно
    $('.btn-add').click(function ChangeBtn() {
        var change = document.getElementById("btnchange");
        change.innerHTML = "Добавлено";
    });


    $('.btn-check').click(function Check() {
        var change = document.getElementById("checkout");
        change.innerHTML = "Заказ сформирован!";
    });
});