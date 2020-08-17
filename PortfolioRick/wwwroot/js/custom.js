jQuery(document).ready(function () {
    jQuery("div.col-md-6.Aligner").hover(function () {
        $(this).children("span").stop(true, true).fadeIn(400);
    }, function () {
        $(this).children("span").stop(true, true).fadeOut(300);
    });
});