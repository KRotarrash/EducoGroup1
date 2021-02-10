$(document).ready(function () {

    $('[name=Password]').keypress(function (evt, elem) {
        hideErrorText();
        return true;
    });

    function hideErrorText() {
        $('.error-message ').hide();
    }

    $('[name=UserName]')
        .change(function () {
            var name = $(this).val();
            var indexSymbol = name.indexOf('.');
            var isValid = indexSymbol > 0 && indexSymbol < name.length - 1;
            $('.error-short-name-format').toggle(!isValid);
            $(this).toggleClass('input-validation-error', !isValid);})
        .change(function () {
            var name = $(this).val();
            var indexSymbol = name.indexOf('.');
            var result = name.length - indexSymbol - 1;
            var isValid = result > 2 ;
            $('.error-short-name-lenght').toggle(!isValid);
            $(this).toggleClass('input-validation-error', !isValid);})
        .change(function () {
            var isValidName = $(this).val().length > 0;
            $('.error-short-name').toggle(!isValidName);
            $(this).toggleClass('input-validation-error', !isValidName);
    });

    $('[name=Password]').change(function () {
        var isValidPass = $(this).val().length >= 6;
        $('.error-short-password').toggle(!isValidPass);
        $(this).toggleClass('input-validation-error', !isValidPass);
    });

    $('.form-user-login').submit(function () {
        return checkInputNotEmpty('UserName')
            && checkInputNotEmpty('Password');
    });

    function checkInputNotEmpty(inputName) {
        var tag = $(`[name=${inputName}]`);
        var isValid = !!tag.val();
        tag.toggleClass('input-validation-error', !isValid);
        return isValid;
    }

    function one() {
        var indexSymbol = $(this).val().indexOf('.');
        var isValid = indexSymbol < 0;
        $('.error-short-name-format').toggle(!isValid);
        $(this).toggleClass('input-validation-error', !isValid);
    };

});
