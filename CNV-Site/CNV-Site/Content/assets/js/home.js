jQuery.noConflict();
(function ($) {
	$(function () {
		
		$(document).ready(function () {
			$('.filter-home .btn-blue').on('click',function(){
				var filter = $(this).data('filter');
				$('.filter-home .btn-blue').toggleClass('active');
				$('#carousel-novedades,#carousel-hechos-relevantes').toggleClass('visible');
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
		
		
	});
})(jQuery);