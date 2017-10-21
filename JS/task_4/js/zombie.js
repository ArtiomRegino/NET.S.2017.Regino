function Zombie () {

	var health = 100;

	var zombieElement = document.createElement("div");
	var healthDiv = document.createElement("div");
	var gifDiv = document.createElement("div");
	var killed = new CustomEvent("killed");

	zombieElement.classList.add("zombieDiv");
	gifDiv.classList.add("gifDiv");
	healthDiv.classList.add("healthDiv");

	zombieElement.appendChild(healthDiv);
	zombieElement.appendChild(gifDiv);

	on( "killed", function() {
		zombieElement.parentNode.removeChild(zombieElement);
	});

	Object.defineProperty( this, "zombieBlock", {
	 	get : function () {
			return zombieElement;
		}
	});

	function on ( eventName, eventCallback ) {
		zombieElement.addEventListener(eventName, eventCallback);
	}

	this.move = function () {
		return 10;
	}

	this.hit = function ( damage ) {

		if ( health > damage ) {
			var healthWidth = getComputedStyle(healthDiv).width;
			var newWidth = parseInt(healthWidth) - parseInt(healthWidth) / health * damage; 

			health -= damage;
			healthDiv.style.width = newWidth + "px";
		} 
		else {
			zombieElement.dispatchEvent(killed);
		}
	}

}