			
$(document).ready(function() {
	setResultImagesSize();
	$( window ).resize(setResultImagesSize);
	
	$("img.resultframe").one("load", function() {
		$(this).next().children().each(function() {
			$(this).width($(this).height());
		});
	});
})

function setResultImagesSize() {
	$("div.resultcircle").each(function() {
		$(this).width($(this).height());
	});
}