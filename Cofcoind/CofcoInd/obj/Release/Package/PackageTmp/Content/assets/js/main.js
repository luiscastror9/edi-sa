jQuery.noConflict();
(function ($) {
	$(function () {
		var touch = 'ontouchstart' in document.documentElement
            || navigator.maxTouchPoints > 0
            || navigator.msMaxTouchPoints > 0;

if (touch) { // remove all :hover stylesheets
    try { // prevent exception on browsers not supporting DOM styleSheets properly
        for (var si in document.styleSheets) {
            var styleSheet = document.styleSheets[si];
            if (!styleSheet.rules) continue;

            for (var ri = styleSheet.rules.length - 1; ri >= 0; ri--) {
                if (!styleSheet.rules[ri].selectorText) continue;

                if (styleSheet.rules[ri].selectorText.match(':hover')) {
                    styleSheet.deleteRule(ri);
                }
            }
        }
    } catch (ex) {}
        }
        // Nombre Empresa Autocompletacion
        $(document).ready(function () {
$(function () {
    
    $("#nombreempresa").autocomplete({
       // source: "http://" + window.location.host + "/Empresas/AutoComplete",      
        minLength: 3,
        source: function (request, response) {
            var itemnamecodes = new Array();
            $.ajax({
                async: false, cache: false,
                //type: "POST",
                url: "http://" + window.location.host + window.location.pathname.substring(0, window.location.pathname.lastIndexOf("/") + 1) + "/Empresas/AutoComplete",
                data: { "term": request.term },
                success: function (data) {
                    for (var i = 0; i < data.length; i++) {
                        itemnamecodes[i] = { label: data[i].descripcion, Id: data[i].id };
                    }
                }
            });
            response(itemnamecodes);
        }
        
    });

    $("#nombre-registrado").autocomplete({
        // source: "http://" + window.location.host + "/Empresas/AutoComplete",      
        minLength: 3,
        source: function (request, response) {
            var itemnamecodes = new Array();
            $.ajax({
                async: false, cache: false,
                //type: "POST",
                url: "http://" + window.location.host + window.location.pathname.substring(0, window.location.pathname.lastIndexOf("/") + 1) + "/AutoCompleteRazon",
                data: { "term": request.term },
                success: function (data) {
                    for (var i = 0; i < data.length; i++) {
                        itemnamecodes[i] = { label: data[i].razonSocial, Id: data[i].dni };
                    }
                }
            });
            response(itemnamecodes);
        }

    });

    $("#nombre").autocomplete({
        // source: "http://" + window.location.host + "/Empresas/AutoComplete",      
        minLength: 3,
        source: function (request, response) {
            var itemnamecodes = new Array();
            $.ajax({
                async: false, cache: false,
                //type: "POST",
                url: "http://" + window.location.host + window.location.pathname.substring(0, window.location.pathname.lastIndexOf("/") + 1) + "/AutoCompleteNombre",
                data: { "term": request.term },
                success: function (data) {
                    for (var i = 0; i < data.length; i++) {
                        itemnamecodes[i] = { label: data[i].nombreApellido, Id: data[i].dni };
                    }
                }
            });
            response(itemnamecodes);
        }

    });

    $("#denominacionFF").autocomplete({
        // source: "http://" + window.location.host + "/Empresas/AutoComplete",      
        minLength: 3,
        source: function (request, response) {
            var itemnamecodes = new Array();
            $.ajax({
                async: false, cache: false,
                //type: "POST",
                url: "http://" + window.location.host + "/FideicomisosFinancieros/AutoCompletedenominacion",
                data: { "term": request.term },
                success: function (data) {
                    for (var i = 0; i < data.length; i++) {
                        itemnamecodes[i] = { label: data[i].denominacion, Id: data[i].id };
                    }
                }
            });
            response(itemnamecodes);
        }

    });

    $("#programaFF").autocomplete({
        // source: "http://" + window.location.host + "/Empresas/AutoComplete",      
        minLength: 3,
        source: function (request, response) {
            var itemnamecodes = new Array();
            $.ajax({
                async: false, cache: false,
                //type: "POST",
                url: "http://" + window.location.host + "/FideicomisosFinancieros/AutoCompleteprograma",
                data: { "term": request.term },
                success: function (data) {
                    for (var i = 0; i < data.length; i++) {
                        itemnamecodes[i] = { label: data[i].denominacion, Id: data[i].id };
                    }
                }
            });
            response(itemnamecodes);
        }

    });

    $("#fiduciarioFF").autocomplete({
        // source: "http://" + window.location.host + "/Empresas/AutoComplete",      
        minLength: 3,
        source: function (request, response) {
            var itemnamecodes = new Array();
            $.ajax({
                async: false, cache: false,
                //type: "POST",
                url: "http://" + window.location.host + "/FideicomisosFinancieros/AutoCompletefiduciario",
                data: { "term": request.term },
                success: function (data) {
                    for (var i = 0; i < data.length; i++) {
                        itemnamecodes[i] = { label: data[i].descripcion, Id: data[i].id };
                    }
                }
            });
            response(itemnamecodes);
        }

    });

});
});
        /////////////////
		$(document).ready(function () {
			$(function () {
				$('#ver-mas').on('click',function(){
					$(this).css('display','none');
					$('#ver-mas-contenido').css('display','block');
				});
				$('.switch').on('click',function(){
					
					$(this).parent().siblings('p').toggleClass('invisible');
					$(this).parents('.directivo').find('h3').toggleClass('invisible');
					if($(this).hasClass('esp')){
						$(this).html('Version en español');
					}else{
						$(this).html('English version');
					}
					$(this).toggleClass('esp');
				});
                $('.table-responsive').prepend('<div class="icon-scroll on"><img src="' + window.location.host + window.location.pathname.substring(0, window.location.pathname.lastIndexOf("/") + 1) +'Content/assets/img/horizontal-scroll.png"></div>');



               

				//if($('.icon-scroll')){
				//setTimeout(function(){
    //        $('.icon-scroll').removeClass('on');
    //    }, 3500);
				//	}
    $('#accordion').on('shown.bs.collapse', function (e) {
		
        var offset = $(this).find('.panel > .panel-collapse.in').offset();
		console.log(offset);
        if(offset) {
            $('html,body').animate({
                scrollTop: $(this).find('.panel-title a').offset().top -20
            }, 500); 
        }
 //   }); 
				
});
			$('.table').each(function( index ) {
						var $table = $(this);
var $fixedColumn = $table.clone().insertBefore($table).addClass('fixed-column');

$fixedColumn.find('th:not(:first-child),td:not(:first-child)').remove();

$fixedColumn.find('tr').each(function (i, elem) {
    $(this).height($table.find('tr:eq(' + i + ')').height());
});
			});
	
			
		});
		$(window).resize(function(){
			$('.fixed-column').each(function( index ) {
				var $this = $(this);
				var $other = $this.next();
				$this.find('tr').each(function (i, elem) {
    $(this).height($other.find('tr:eq(' + i + ')').height());
});
			});
		});
//		$(window).on('scroll',function(){
//			$('.table-responsive').each(function(){
//				var windowtop = $(window).scrollTop();
//				var top = $(this).offset().top;
//				if(top>windowtop && top < windowtop + $(window).height() ){
//					$(this).children('.icon-scroll').removeClass('on');
//				  $(this).children('.icon-scroll').addClass('on');
//					if($('.icon-scroll')){
//				setTimeout(function(){
//            $('.icon-scroll').removeClass('on');
//        }, 4000);
//					}
//				   }else{
//					// $(this).children('.icon-scroll').removeClass('on');
//				   }
				
//			});
//			$('.fixed-column').each(function( index ) {
//				var $this = $(this);
//				var $other = $this.next();
//				$this.find('tr').each(function (i, elem) {
//    $(this).height($other.find('tr:eq(' + i + ')').height());
//});
//			});
//		});
});
    });
})(jQuery);