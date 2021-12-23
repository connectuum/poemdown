
function setHtml(selector, html) {
	$(selector).html(html);
}

function setEditorOverlayHtml(html) {
	setHtml(".editor .overlay", html);
}
