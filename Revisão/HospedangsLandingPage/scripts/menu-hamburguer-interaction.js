const menuHamburguer = document.getElementById("checkbox");
const mobileNav = document.getElementById("nav-box");

menuHamburguer.onclick = () => {
  menuHamburguer.checked
    ? mobileNav.classList.replace("nav-box-closed", "nav-box-opened")
    : mobileNav.classList.replace("nav-box-opened", "nav-box-closed");
};