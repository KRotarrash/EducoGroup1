$(document).ready(function () {

    $('.spoiler .header').click(function () {
        $(this)
            .closest('.spoiler')
            .find('.content')
            .toggle();
    });

    //Вычисление и запись в БД результата
    $('.GetResultAjax').click(function () {
        $('.GetResultAjax').attr('disabled', 'disabled');
        var number1 = $('#Number1').val();
        var number2 = $('#Number2').val();
        var operation = $("select[name$='Operation']").val();
        var url = `/Calc/Calculate?num1=${number1}&num2=${number2}&operation=${operation}`;

        $.get(url)
            .done(function (data) {
                $('.answer').text(data.answer);
                $('.GetResultAjax').removeAttr('disabled');
                addRow(data);
            });       
    })


    //Очистка БД
    $('.clearTable').click(function () {
        var url = `/Calc/DeleteTableHist`;
        $.get(url)
            .done(function () {
                $('.calcHistoryTable').find('tr:gt(0)').remove();
            });           
    })


    //Добавление строки в таблицу
    function addRow(data)
    {
        var index = parseInt($('.calcHistoryTable tr:last td:first p').html());
        if (!index)
        {
            index = 0;
        }
        var newRow = `<tr>
            <td><p>${index+=1}</p></td>
            <td><p>${data.number1}</p></td>
            <td><p>${data.number2}</p></td>
            <td><p>${operationName(data.operation)}</p></td>
            <td><p>${data.answer}</p></td>
            </tr>`;

        $('.calcHistoryTable tr:last').after(newRow);
    }

    function operationName(operation) {
        switch (operation) {
            case 0: return 'Division';
            case 1: return 'Multiplication';
            case 2: return 'Addition';
            case 3: return 'Subtraction';
            default: return 'Неизвестная операция'
        }
    }


});
