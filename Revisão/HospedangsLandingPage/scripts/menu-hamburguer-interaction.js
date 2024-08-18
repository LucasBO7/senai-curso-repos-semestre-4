var menuHamburguer = document.getElementById("checkbox");
var mobileNav = document.getElementById("nav-box");

menuHamburguer.onclick = function () {
  if (menuHamburguer.checked) {
    mobileNav.classList.replace("nav-box-closed", "nav-box-opened");
  } else {
    mobileNav.classList.replace("nav-box-opened", "nav-box-closed");
  }
};
