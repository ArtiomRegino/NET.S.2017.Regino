
	function ZombieStrong () {
		Zombie.call(this, "Strong");
	}

	function ZombieMichael () {
		Zombie.call(this, "Michael");
	}

	function ZombieDefault () {
		Zombie.call(this, "Default");
	}

	function ZombieBallon () {
		Zombie.call(this, "Ballon");
	}

	function Zombie (type) { 

		var health = 100;

		var zombieElement = document.createElement("div");
		var healthDiv = document.createElement("div");
		var gifZombie = document.createElement("div");
		var events = {};
		var options = [{ type: "Strong", gifParam: "strongZombie", healthParam: "healthStrong" },
					   { type: "Default", gifParam: "defaultZombie", healthParam: "healthDefault" },
					   { type: "Michael", gifParam: "michaelZombie", healthParam: "healthMichael" },
					   { type: "Ballon", gifParam: "ballonZombie", healthParam: "healthBallon" }
					  ];

		zombieElement.id = "zombie";
		zombieElement.classList.add("zombieDiv");

		for (var i = 0; i < options.length; i++) {
			if ( type === options[i].type ) {
				gifZombie.classList.add(options[i].gifParam);
				healthDiv.classList.add(options[i].healthParam);
			}
		}
		
		zombieElement.appendChild(healthDiv);
		zombieElement.appendChild(gifZombie);

		Object.defineProperty( this, "zombieBlock", {
	 		get : function () {
				return zombieElement;
			}
		});

		this.on = function ( eventName, eventCallback ) {
			events[eventName] = eventCallback;
		}

		this.move = function () {
			if ( type === "Michael" ) {
				return 8;
			} 
			else if ( type === "Ballon" ) {
				return 10;
			}
			return 4;
		}

		this.hit = function ( damage ) {

			if ( health > damage ) {
				var healthWidth = getComputedStyle(healthDiv).width;
				var newWidth = parseInt(healthWidth);

				if ( type === "Strong" ) {
					newWidth -= parseInt(healthWidth) / health * damage / 2; 
				}
				else  if ( type === "Ballon" ) {
					newWidth -= parseInt(healthWidth) / health * damage * 1.5; 
				}
				else {
					newWidth -= parseInt(healthWidth) / health * damage; 
				}
				health -= damage;
				healthDiv.style.width = newWidth + "px";
			} 
			else {
				events["killed"]( this );
			}
		}

	}
