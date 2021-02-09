$(document).ready(function () {

    $(".checkBoxClass").on("click", function (event) {
        var $underSpan = $(this).next(); 
        $underSpan.toggleClass("lineThroughClass");
        
    });
    $(".btnEditContent").on("click", function (event) {

        
        $(this).parent().next().toggleClass("hiddenEditPanel");
    });

});


