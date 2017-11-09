$(document).ready(function () {
	function link();
});

$(function link() {
	$('#urlddl').change(function () {
		var url = $(this).val();
		if (url != null && url != '') {
			window.location.href = url;
		}
	});
});