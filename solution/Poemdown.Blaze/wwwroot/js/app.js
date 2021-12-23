function allowTextareaTabKey() {
	var $input = $("textarea");

	$input.on(`keydown`, (event) => {
		if ( event.keyCode !== 9 ) { //ignore everything except '\t' tab char
			return;
		}

		event.preventDefault();

		var value = $input.val();
		var startIndex = $input.prop("selectionStart");
		var endIndex = $input.prop("selectionEnd");
		var newIndex = endIndex+1;
		var pre = value.substring(0, startIndex);
		var post = value.substring(endIndex);
		//console.log("val", value, startIndex, endIndex, pre, post);

		$input.val(`${pre}\t${post}`);
		$input.prop("selectionEnd", newIndex); //startIndex+1);
		$input.prop("selectionStart", newIndex);
	});
}
