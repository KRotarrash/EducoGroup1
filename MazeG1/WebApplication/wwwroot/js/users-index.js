$(document).ready(function () {

    init();

    function init() {
        $('.login-popup .login-content').empty();
        var origin = $('.user-adresses');

        var adressBlock = origin.clone();
        $('.login-content').width(500);
        $('.login-popup .login-content').append(adressBlock);

        origin.remove();
    }

    $('.user-adress').click(function () {
        var userId = $(this).closest('tr').data('id');
        var url = '/user/GetAdresses?userId=' + userId;

        $.get(url)
            .done(function (data) {
                $('.user-adresses .adress:not(.template)').remove();

                $('.login-popup').show();

                if (data.length > 0) {
                    for (var i = 0; i < data.length; i++) {
                        var adress = data[i];
                        drawAdress(adress);
                    }
                } else {
                    drawAdress({ street: 'Пока нет адресов', id: -1 });
                }
            });

        function drawAdress(adress) {
            var newAdress = $('.user-adresses .template').clone();
            $('.user-adresses').append(newAdress);
            newAdress.removeClass('template');
            newAdress.find('.street').text(adress.street);
            newAdress.data('id', adress.id);
            newAdress.find('.remove-adress').click(removeAdress);
        }

        function removeAdress() {
            var adressTag = $(this).closest('.adress');
            var adressId = adressTag.data('id');
            var removeAdressUrl = '/user/removeAdress?id=' + adressId;
            $.get(removeAdressUrl)
                .done(function (answer) {
                    if (answer === true) {
                        adressTag.remove();
                    }
                });
        }
    });
});
