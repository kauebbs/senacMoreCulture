$('.banner').slick({
  slidesToShow: 1,
  slidesToScroll: 1,
  autoplay: true,
  autoplaySpeed: 2000,
  dots: true,
});

$('.slideservico').slick({
  slidesToShow: 4,
  slidesToScroll: 1,
  dots: true,
  responsive: [
    {
      breakpoint: 1200,
      settings: {
        slidesToShow: 3,
        slidesToScroll: 1,
      }
    },
    {
      breakpoint: 600,
      settings: {
        slidesToShow: 3,
        slidesToScroll: 1,
      }
    },
    {
      breakpoint: 480,
      settings: {
        slidesToShow: 3,
        slidesToScroll: 1
      }
    }
  ]
});

$('.slideequipe').slick({
  slidesToShow: 1,
  slidesToScroll: 1,
  dots: true,
});

/* MENU MOBILE */

document.querySelector(".abrirMenu").onclick = function () {
  document.documentElement.classList.add("menuAtivo");

}

document.querySelector(".fecharMenu").onclick = function () {
  document.documentElement.classList.remove("menuAtivo");
}

new WOW().init();

