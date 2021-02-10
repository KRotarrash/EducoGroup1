$(document).ready(function () {

    var form = document.getElementById('officeAddForm');
    var office = document.getElementById('AddedOfficeId');
    form.addEventListener('submit', function (evt) {
        evt.preventDefault();
        if (!office.value) {
            $('.alertMessage').css('display', 'inline')
            return;
        }

        this.submit();
    });

    office.onclick = function () {
        $('.alertMessage').css('display', 'none');
    }

});