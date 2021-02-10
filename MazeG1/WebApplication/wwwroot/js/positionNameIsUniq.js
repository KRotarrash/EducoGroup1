$(document).ready(function () {

    var positionNameInput = $("#Position_Name");
    var organizationIdInput = $("#Organization_Id");
    var submitBatton = $(".submitBatton");
    positionNameInput.blur(function () {        
        positionNameIsUnique();
    });

    submitBatton.click(function () {
        positionNameIsUnique();
    })

    function positionNameIsUnique() {
        if (positionNameInput.val().trim() != "") {
            var positionName = positionNameInput.val();
            var organizationName = organizationIdInput.val();
            var url = `/Job/PositionNameIsUniq?organizationId=${organizationName}&positionName=${positionName}`;
            $.get(url).done(function (data) {
                var alert = $(".alertMessage");            
                if (!data) {
                    alert.css('display', 'inline');
                    submitBatton.attr('disabled', 'disabled');
                }
                else {
                    alert.css('display', 'none');
                    submitBatton.removeAttr('disabled');
                }
            });
        }
    }
});
