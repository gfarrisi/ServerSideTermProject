//Simple HTML5 Music Player by design1online.com, LLC

var currentTrack = null;
var paused = false;

$(document).ready(function () {
    //currentTrack = $('#currentTrack').val();

    $("#play").click(function () { play(); });
    //$("#stop").click(function () { stop(); });
    //$("#pause").click(function () { pause(); });
});

function play() {
    console.log("play")
    ////set the track back to the beginning
    //if (!paused) {
    //    stop();
    //    currentTrack = $('#currentTrack').val();

    //    //make sure track starts from the begining each time
    //    document.getElementById(currentTrack).load();
    //}

    ////play the track
    //document.getElementById(currentTrack).play();
}

////stop playing the current track
//function stop() {
//    if (currentTrack) {
//        document.getElementById(currentTrack).pause();
//        paused = false;
//    }
//}

////stop the track but don't go back to the beginning
//function pause() {
//    paused = true;
//    document.getElementById(currentTrack).pause();
}


(function ($) {
  "use strict"; // Start of use strict

  // Smooth scrolling using jQuery easing
  $('a.js-scroll-trigger[href*="#"]:not([href="#"])').click(function() {
    if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
      var target = $(this.hash);
      target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
      if (target.length) {
        $('html, body').animate({
          scrollTop: (target.offset().top - 54)
        }, 1000, "easeInOutExpo");
        return false;
      }
    }
  });

  // Closes responsive menu when a scroll trigger link is clicked
  $('.js-scroll-trigger').click(function() {
    $('.navbar-collapse').collapse('hide');
  });

  // Activate scrollspy to add active class to navbar items on scroll
  $('body').scrollspy({
    target: '#mainNav',
    offset: 56
  });

  // Collapse Navbar
  var navbarCollapse = function() {
    if ($("#mainNav").offset().top > 100) {
      $("#mainNav").addClass("navbar-shrink");
    } else {
      $("#mainNav").removeClass("navbar-shrink");
    }
  };
  // Collapse now if page is not at top
  navbarCollapse();
  // Collapse the navbar when page is scrolled
  $(window).scroll(navbarCollapse);

  // Hide navbar when modals trigger
  $('.portfolio-modal').on('show.bs.modal', function(e) {
    $('.navbar').addClass('d-none');
  })
  $('.portfolio-modal').on('hidden.bs.modal', function(e) {
    $('.navbar').removeClass('d-none');
  })

})(jQuery); // End of use strict
