//NOTE: this file uses a magic filename (see Blazor interop docs)

export function beforeStart(options, extensions) {
	console.log("beforeStart", options, extensions);
}

export function afterStarted(blazor) {
	console.log("afterStarted", blazor);
	allowTextareaTabKey();
}
