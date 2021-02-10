



$('.btn-submobile').click(function () {
    $(this).prev().slideToggle(200);
    $(this).toggleClass('btnsub-active');
    $(this).parent().toggleClass('parent-active');
});

function cloneMegaMenu() {
    var breakpoints = 991;
    var doc_width = $(window).width();
    if (doc_width <= breakpoints) {
        var horizontalMegamenu = $('.sm_megamenu_wrapper_horizontal_menu .horizontal-type');
        var verticalMegamenu = $('.sm_megamenu_wrapper_vertical_menu .vertical-type');
        $('#navigation-mobile').append(horizontalMegamenu);
        $('#navigation-mobile').append(verticalMegamenu);
    } else {
        var horizontalMegamenu = $('#navigation-mobile .horizontal-type');
        var verticalMegamenu = $('#navigation-mobile .vertical-type');
        $('.sm_megamenu_wrapper_horizontal_menu .sambar-inner .mega-content').append(horizontalMegamenu);
        $('.sm_megamenu_wrapper_vertical_menu .sambar-inner .mega-content').append(verticalMegamenu);
    }
}

cloneMegaMenu();

$(window).resize(function () {
    cloneMegaMenu();


});