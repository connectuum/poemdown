function setHtml(selector, html) {
	$(selector).html(html);
}

function setEditorOverlayHtml(html) {
	setHtml(".editor .overlay", html);
}

function getEditorTextareaValue() {
	return ($(".editor textarea").val() || "");
}
