function Zombie () {

	var health = 100;

	var zombieElement = document.createElement("div");
	var healthDiv = document.createElement("div");
	var gifDiv = document.createElement("div");
	var killed = new CustomEvent("killed");
	var events = {};

	zombieElement.classList.add("zombieDiv");
	gifDiv.classList.add("gifDiv");
	healthDiv.classList.add("healthDiv");

	zombieElement.appendChild(healthDiv);
	zombieElement.appendChild(gifDiv);

	Object.defineProperty( this, "zombieBlock", {
	 	get : function () {
			return zombieElement;
		}
	});

	this.on = function ( eventName, eventCallback ) {
		events[eventName] = eventCallback;
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
			events["killed"]();
		}
	}

}