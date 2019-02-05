'use strict'

jQuery.noConflict();
(function( $ ) {
  $(function() {
	  
	  
	  
    $(document).ready(function(){
		              new WOW().init();


//scroll content
$('.scroll').on('click',function(event){
	event.preventDefault();
	var body = $(".scroll-content");
	var yy = $($(this).attr('href')).position();
	
	body.stop().animate({scrollTop:yy.top}, 500);
});

	//slider home
		
		$('#slider-home').carousel({
			pause: 'none'
		});
		
	//MENU OPEN
		$('.btn-open').on('click',function(){
			$('.sidebar.int').addClass('open');
			$('#logo').addClass('open');
		});
		$('.container-fluid.int').on('mouseenter',function(){
			$('.sidebar.int').removeClass('open');
			$('#logo').removeClass('open');
		});
		//ALTO SCROLL
		if($('.display-flex').height() < $(window).height()){
				$('.display-flex').addClass('full-height');
			}else{
				$('.display-flex').removeClass('full-height');
			}
		$(window).resize(function(){
			if($('.display-flex').height() < $(window).height()){
				$('.display-flex').addClass('full-height');
			}else{
				$('.display-flex').removeClass('full-height');
			}
		});
		
	});
	
	     
  });
})(jQuery);