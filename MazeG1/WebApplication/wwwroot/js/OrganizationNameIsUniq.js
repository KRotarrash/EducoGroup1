$(document).ready(function () {

    var nameInput = $("#Name");  
    var submitBatton = $(".submitBatton");
    nameInput.blur(function () {
        OrganizationNameIsUnique();
    });

    submitBatton.click(function () {
        OrganizationNameIsUnique();
    });

    function OrganizationNameIsUnique () {
        if (nameInput.val().trim() != "") {
            var name = nameInput.val();
            var url = `/Job/OrganizationNameIsUniq?orgName=${name}`;
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
