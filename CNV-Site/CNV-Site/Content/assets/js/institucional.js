jQuery.noConflict();
(function ($) {
	$(function () {
		$(document).ready(function () {
			$('#saber-mas').on('click', function () {
				$(this).toggleClass('on');
				$(this).next().slideToggle();
				if($(this).hasClass('on')) {
					$(this).html('OCULTAR <i class="fa fa-caret-up" aria-hidden="true"></i>');
				}else{
					$(this).html('SABER MÁS <i class="fa fa-caret-down" aria-hidden="true"></i>');
				}
			});
			$('#acuerdos-internacionales,#colaboracion').on('click', function () {
				$(this).toggleClass('on');
				$(this).next().slideToggle();
				if($(this).hasClass('on')) {
					$(this).html('OCULTAR <i class="fa fa-caret-up" aria-hidden="true"></i>');
				}else{
					$(this).html($(this).data('title') + ' <i class="fa fa-caret-down" aria-hidden="true"></i>');
				}
			});
			$('.collapse.in').prev('.panel-heading').addClass('active');
			$('#accordion, #bs-collapse')
				.on('show.bs.collapse', function (a) {
					$(a.target).prev('.panel-heading').addClass('active');
				})
				.on('hide.bs.collapse', function (a) {
					$(a.target).prev('.panel-heading').removeClass('active');
				});
			$('.btn-ver-mas').on('click',function(event){
				event.preventDefault();
				 id = $(this).data('box');
				$('.data').slideUp();
				$('#data'+id).slideDown();
				$('.box').fadeIn();
				$('#box'+id).fadeOut();
			});
			$('.btn-volver').on('click',function(){
				
				$('.data').slideUp();
				
				$('.box').fadeIn();
				
			});
		});
	});
})(jQuery);