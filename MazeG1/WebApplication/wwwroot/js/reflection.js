$(document).ready(function () {

    $('.spoiler .header')
        .click(function()  {
            var header = $(this);
            header.toggleClass('open');
         $(this)
             .closest('.spoiler')
             .find('> .content')
             .toggle();
        });

});
