$(document).ready(function () {

    showIconIntoUserName();
    onOrganizationChange();

    $('#organization').change(onOrganizationChange);

    $('.user-name-block .icon.question').click(function () {
        showIconIntoUserName('wait');
        var name = $('[name=UserName]').val();
        var url = '/User/IsUniqName?name=' + name;
        $.get(url).done(function (answer) {
            if (answer) {
                showIconIntoUserName('check');
            } else {
                showIconIntoUserName('bad');
            }
        });
    });

    $('[name=UserName]').keypress(function (evt, elem) {
        // 63 == '?'
        if (evt.keyCode == 63) {
            $('.error-forbidden-symbol').show();
            return false;
        }

        $('.error-forbidden-symbol').hide();
        showIconIntoUserName();
        return true;
    });

    $('[name=Age]').change(function () {
        var isValidAge = $(this).val() >= 18;
        $('.error-age-yang').toggle(!isValidAge);
        $(this).toggleClass('input-validation-error', !isValidAge);
    });

    $('[name=Password]').change(function () {
        checkPasswords()
    });

    $('[name=PasswordRepeat]').change(function () {
        checkPasswords()
    });

    $('.button-user-create').click(function () {

        var go = checkAllFields();

        if (go) {

            var data = {
                userName: $('#UserName').val(),
                age: $('#Age').val(),
                password: $('#Password').val(),
                height: $('#Height').val()
            }

            var url = `/Mayoralty/AddUserAjax?name=${data.name}&age=${data.age}&password=${data.password}&height=${data.height}`;

            $.post(url, data).done(function (result) {

                if (result) {
                    showMessage(`Пользователь ${data.name} успешно добавлен`, 'aquamarine');
                }
                else {
                    showMessage(`ПОЛЬЗОВАТЕЛЬ ${data.name} НЕ ДОБАВЛЕН`, '#bf2626');
                }
            });
        }
    });

    $('.close-message').click(function () {
        $('.user-event-container').hide();
    });

    function onOrganizationChange() {
        var id = $('#organization').val();
        if (!id) {
            return;
        }

        var url = `/Job/GetPositions?id=${id}`;

        $.get(url).done(function (positions) {
            $('#position').empty();
            $.each(positions, function (index, position) {
                $('#position')
                    .append($('<option/>', { value: position.id, text: position.name }))
            })
        });
    }

    function checkAllFields() {
        return checkInputNotEmpty('UserName')
            && checkPasswords()
            && checkInputNotEmpty('Age')
            && checkInputNotEmpty('Height');
    }

    function checkInputNotEmpty(inputName) {
        var tag = $(`[name=${inputName}]`);
        var isValid = !!tag.val();
        tag.toggleClass('input-validation-error', !isValid);
        return isValid;
    }

    function checkPasswords() {
        var tagPassword = $('[name=Password]');
        var tagPasswordRepeat = $('[name=PasswordRepeat]');

        var isValidPassNotEmpty = checkInputNotEmpty('Password');
        var isValidPassRepeatNotEmpty = checkInputNotEmpty('PasswordRepeat');

        var isValidPassLength = tagPassword.val().length >= 6;
        $('.error-short-password').toggle(!isValidPassLength);

        var isValidPass = isValidPassNotEmpty && isValidPassLength;
        tagPassword.toggleClass('input-validation-error', !isValidPass);

        var isValidPassRepeatLength = tagPasswordRepeat.val().length >= 6;
        $('.error-short-password-repeat').toggle(!isValidPassRepeatLength);

        var isValidPassRepeatEquals = tagPassword.val() == tagPasswordRepeat.val();
        $('.not-equal-password').toggle(!isValidPassRepeatEquals);

        var isValidPassRepeat = isValidPassRepeatNotEmpty && isValidPassRepeatLength && isValidPassRepeatEquals;
        tagPasswordRepeat.toggleClass('input-validation-error', !isValidPassRepeat);

        return isValidPass && isValidPassRepeat;
    }

    function showIconIntoUserName(iconShow = 'question') {
        $('.user-name-block .icon').hide();
        $('.user-name-block .icon.' + iconShow).show();
    }
});
