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

		$(document).ready(function () {
			$(function () {
    $('#accordion').on('shown.bs.collapse', function (e) {
		
        var offset = $(this).find('.panel > .panel-collapse.in').offset();
		console.log(offset);
        if(offset) {
            $('html,body').animate({
                scrollTop: $(this).find('.panel-title a').offset().top -20
            }, 500); 
        }
    }); 
				
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
		$(window).on('scroll',function(){
			$('.fixed-column').each(function( index ) {
				var $this = $(this);
				var $other = $this.next();
				$this.find('tr').each(function (i, elem) {
    $(this).height($other.find('tr:eq(' + i + ')').height());
});
			});
		});
	});
})(jQuery);