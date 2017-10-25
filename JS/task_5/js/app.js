window.addEventListener("load", function () {

	var divContainer = document.getElementById("container");
	var btnStart = document.getElementById("Start");
	var btnStartLevel = document.getElementById("StartLevel");
	var divLines = [];
	var peaShooters = [];
	var peaBullets = [];
	var zombies = [];
	var zombieCount = 0;
	var processGenerate;
	var processMoveZombie;
	var processMovePeaBullet;
	var levelGameProcess;
	var level = 1;
	var score = 0;

	btnStart.addEventListener( "click", start );
	btnStartLevel.addEventListener( "click", startLevel );

	for (var i = 0; i < 5; i++) {

		divLines[i] = document.createElement( "div" );
		divLines[i].classList.add( "divLine" );
		divLines[i].id = `${i}`;

		divContainer.appendChild( divLines[i] );
	}

	generatePeaShooters();
	subscribeToPeaShooters();
	

	function start () {
		if ( btnStart.value == "Start" ) {
			var gameTextElement;

			gameTextElement = document.getElementById( "gameText" );
			gameTextElement.style.visibility = 'hidden';
			gameTextElement = document.getElementById( "gameTextWon" );
			gameTextElement.style.visibility = 'hidden';
			btnStart.value = "Pause";

			clearTimeout(processMoveZombie);
			generateZombies();
			moveZombie();
			movePeaBullet();
		}
		else {

			clearTimeout(processGenerate);
			clearTimeout(processMoveZombie);
			clearTimeout(processMovePeaBullet);
			clearTimeout(levelGameProcess);

			btnStart.value = "Start";
		}
	}

	function startLevel () {

		btnStartLevel.disabled = true;
		btnStart.disabled = true;
		
		start();
		checkScore();

		btnStart.value = "Pause";
	}

	function checkScore () {

		levelGameProcess = setTimeout( function () {

			if ( score >= level * 20 ) {
				
				clearTimeout( processGenerate );
				clearTimeout( levelGameProcess );
				checkIfWon();
			}
			else {
				checkScore();
			}
			
		}, 3000);
	}

	function checkIfWon () {

		levelGameProcess = setTimeout( function () {
			var win = true;
			var gameTextElement;

			for (var i = 0; i < zombies.length; i++) {
				if ( zombies[i] !== undefined ) {
					win = false;
				}
			}
			if ( win ) {
				gameTextElement = document.getElementById( "gameTextWon" );
				gameTextElement.style.visibility = 'visible';
				btnStartLevel.disabled = false;
				btnStart.disabled = false;
			} 
			else {
				checkIfWon();
			}

		}, 3000);
	}

	function generateZombies () {

		processGenerate = setTimeout( function () {

			var currentLine = random( 0, divLines.length );
			var zombieBlock;

			zombies[zombieCount] = {
				currentLine : currentLine,
				zombie :  GetRandomZombie()
			};

			zombies[zombieCount].zombie.on( 'killed', function ( zombie ) {
				for (var i = 0; i < zombies.length; i++) {

					if ( zombies[i] == undefined ) continue; 
					if( zombies[i].zombie ===  zombie ) {
						zombies[i] = undefined;
						score += 5;
						break;
					}
				}
				zombie.zombieBlock.remove();
			});

			zombieBlock = zombies[zombieCount].zombie.zombieBlock;

			divLines[currentLine].appendChild( zombieBlock );

			zombieCount++;
			generateZombies();

		}, 2000);
	}

	function movePeaBullet () {

		processMovePeaBullet = setTimeout( function () {

			for (var j = 0; j < peaBullets.length; j++) {
				var curBullet = peaBullets[j];
				var innerBullet = curBullet.peaBullet;
				var thisLineZombies = [];
				var count = 0;

				if ( curBullet === undefined ) continue;

				var previousMarginL = getComputedStyle( innerBullet ).marginLeft; 
				var currentMarginL = parseInt( previousMarginL ) + 10;

				if ( currentMarginL >=  880 ) {
					innerBullet.remove();
					curBullet = undefined;
					continue;
				}
				innerBullet.style.marginLeft = currentMarginL + "px";

				for (var i = 0; i < zombies.length; i++) {

					if ( zombies[i] === undefined ) continue;
					if ( zombies[i].currentLine == curBullet.currentLine ) {
						thisLineZombies[count] = zombies[i].zombie;
						count++;
					}
				}
				if( thisLineZombies === undefined ) continue;

				for (var i = 0; i < thisLineZombies.length; i++) {

					var zombieMargin = thisLineZombies[i].zombieBlock.style.marginLeft;

					if ( parseInt( zombieMargin ) <= currentMarginL ) {
						if( curBullet === undefined || innerBullet === undefined ) continue;

						innerBullet.parentNode.removeChild( innerBullet );
						curBullet = undefined;

						if ( thisLineZombies[i] === undefined ) continue;
						thisLineZombies[i].hit(10);
					}
				}
				
			}
			movePeaBullet();

		}, 100);
	}

	function moveZombie () {

		processMoveZombie = setTimeout( function () {

			for (var j = 0; j < zombies.length; j++) {
				
				if ( zombies[j] === undefined ) continue;

				var zombie = zombies[j].zombie;
				var offset = zombie.move();
				var previousMarginL = getComputedStyle(zombie.zombieBlock).marginLeft; 

				if ( parseInt( previousMarginL ) >= offset ) {
					var currentMarginL = parseInt( previousMarginL ) - offset;

					zombie.zombieBlock.style.marginLeft = currentMarginL + "px";
				}
				else {
					endOfGame();
				}
			}
			moveZombie();

		}, 150);
	}
	
	function GetRandomZombie () {
		var number = random( 1, 4 );
		var zombie;

		if ( number == 1 ) {
			zombie = new ZombieStrong();
		}
		else if ( number == 2 ) {
			zombie = new ZombieMichael();
		}
		else if ( number == 3 ) {
			zombie = new ZombieDefault();
		}
		else {
			zombie = new ZombieBallon();
		}

		return zombie;
	}

	function generatePeaShooters () {

		for (var i = 0; i < 5; i++) {

			peaShooters[i] = document.createElement( "div" );
			peaShooters[i].classList.add( "peaShooter" );
			peaShooters[i].id = `shooter${i}`;

			divLines[i].appendChild( peaShooters[i] );
		}
	}

	function generatePeaBullet ( event ) {

		var currentPeaBulletId = peaBullets.length;
		var divLineId = +event.currentTarget.parentNode.id;
		var peaBullet;

		peaBullets[ currentPeaBulletId ] = { 
			currentLine : divLineId,
			peaBullet : document.createElement( "div" ) 
		};

		peaBullet = peaBullets[ currentPeaBulletId ].peaBullet;

		peaBullet.classList.add( "peaBullet" );
		peaBullet.id = `peaBullet${currentPeaBulletId}`;

		event.currentTarget.parentNode.appendChild( peaBullet );
	}

	function subscribeToPeaShooters () {
		for (var i = 0; i < peaShooters.length; i++) {

			var btnShot = peaShooters[i];
			btnShot.addEventListener( "click", generatePeaBullet );
		}
	}

	function endOfGame () {
		var gameTextElement = document.getElementById("gameText");

		btnStartLevel.disabled = false;
		btnStart.disabled = false;
		btnStart.value = "Start";
		gameTextElement.style.visibility = 'visible';

		clearTimeout( processGenerate );
		clearTimeout( processMoveZombie );
		clearTimeout( levelGameProcess );
		clearTimeout( processMovePeaBullet );

		for (var i = 0; i < divLines.length; i++) {
			divLines[i].innerHTML = "";
		}

		zombies = [];
		zombieCount = 0;
		peaShooters = [];
		peaBullets = [];

		generatePeaShooters ();
		subscribeToPeaShooters();
	}
});