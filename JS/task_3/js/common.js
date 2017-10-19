function generate() {
	var mainElement = document.getElementById('divContainer');
	var counterForId = 0;

	if ( mainElement.innerHTML != '' ) {
		clearDiv();
	}

	for (var i = 0; i < 3; i++) {
		var divLineElement = document.createElement("div");
		
		divLineElement.classList.add("divLine");

		for (var j = 0; j < 6; j++) {
			var innerElement = document.createElement("div");

			innerElement.innerHTML = Math.floor((Math.random() * 100) + 1);
			innerElement.id = `innerDiv${counterForId}`;
			innerElement.classList.add("innerDiv");
			divLineElement.appendChild(innerElement);

			counterForId ++;
		}

		mainElement.appendChild(divLineElement);
	}
}

function clearDiv() {
    document.getElementById('divContainer').innerHTML = '';
}

function setColor() {

	if ( document.getElementById(`innerDiv${0}`) == null ) {
		return;
	}

	for (var i = 0; i < 18; i++) {
		var element = document.getElementById(`innerDiv${i}`);
		var elementInnerValue = +element.innerHTML;
		var color = '#f0f0f0';

		if ( elementInnerValue > 75 ) {
			color = '#f44336';
		} 
		else if ( elementInnerValue > 50 ) {
			color = '#ff9800';
		} 
		else if ( elementInnerValue > 25 ) {
			color = '#4caf50';
		} 

		element.style.backgroundColor = color;
	}
}