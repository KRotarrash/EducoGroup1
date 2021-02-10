$(document).ready(function () {
    init();

    function init() {
        var url = '/Restaurant/GetDishCountInBasket';
        $.get(url)
            .done(function (data) {
                if (data > 0) {
                    $('.dishCountInBasket').css('display', 'flex');
                    $('.dishCountInBasket').text(data);
                } else {
                    $('.dishCountInBasket').remove();
                }   
            });
    }

    $('.dish-name-search').keyup(function (e) {
        var text = $(this).val();
        var restaurantId = $('.restaurantId').val();

        var url = `/Restaurant/GetDishByName?text=${text}&restaurantId=${restaurantId}`;

        $.get(url)
            .done(function (dishes) {
                var dishesBlock = $('.dish-options');
                if (dishes.length > 0) {
                    dishesBlock.removeClass('hide');
                } else {
                    dishesBlock.addClass('hide');
                }

                dishesBlock.empty();

                for (var i = 0; i < dishes.length; i++) {
                    var dish = dishes[i];

                    var span = $('<span>');
                    span.addClass('dish-option');
                    span.data('id', dish.id);
                    span.text(dish.name);
                    span.click(addDishGoClick);

                    dishesBlock.append(span);
                }
            });
    });

    function addDishGoClick() {
        var dishId = $(this).data('id');
        var restaurantId = $('.restaurantId').val();
        window.location = `/Restaurant/AddToBasket?dishId=${dishId}&restId=${restaurantId}`;
    }

    function addDishTextClick() {
        var text = $(this).text();
        $('.dish-name-search').val(text);
        $('.dish-options').addClass('hide');
    }
});