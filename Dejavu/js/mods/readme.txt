use the popup mods by assigning them to the awe.popup, example:

awe.popup = bootstrapPopup;

you can also use multiple mods at the same time, example:

var defaultPopup = awe.popup;
awe.popup = function(o){
	if (condition) return bootstrapPopup(o);
	return defaultPopup(o);
};
