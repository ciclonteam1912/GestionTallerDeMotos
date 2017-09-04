$(".btn-menu").click(function () {
    console.log("adgaga");
    $(".menu-principal .menu").slideToggle();
});

$(window).resize(function () {
    if ($(document).width() > 768) {
        $(".menu-principal .menu").css({ "display": "block" });
    } else {
        $(".menu-principal .menu").css({ "display": "none" });
    }
});