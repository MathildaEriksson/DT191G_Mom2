//Mobile menu
document.addEventListener("DOMContentLoaded", function() {
    var menu = document.getElementById("mobile-menu");
    var menuButton = document.getElementById("mobile-menu-button");

    menuButton.addEventListener("click", function() {
        menu.classList.toggle("hidden");
    });
});
