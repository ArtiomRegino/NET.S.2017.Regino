window.addEventListener("load", function () {

	var zombie;
	var divLine = document.getElementById("divLine");
	var btnGenerate = document.getElementById("Generate");
	var btnMove = document.getElementById("Move");
	var btnShot = document.getElementById("Shot");

	btnGenerate.addEventListener("click", generate);
	btnMove.addEventListener("click", move);
	btnShot.addEventListener("click", shot);

	function generate () {

		if ( divLine.innerHTML == "" ) {

			divLine.style.marginLeft = "530px";

			zombie = new Zombie();
			var zombieBlock = zombie.zombieBlock;

			divLine.appendChild(zombieBlock);
		}
	}

	function move () {
		if (divLine.innerHTML != "") {
			
			var offset = zombie.move();
			var previousMarginL = getComputedStyle(divLine).marginLeft; 

			if ( parseInt(previousMarginL) >= offset ) {
				var currentMarginL = parseInt(previousMarginL) - offset;

				divLine.style.marginLeft = currentMarginL + "px";
			}
		}
	}

	function shot () {
		if (divLine.innerHTML != "") {
			zombie.hit(10);
		}
	}
	
})

