var data = [ {}, {}, {}, {}, {} ];

for (var i = 0; i < data.length; i++) {

	var type = random( 1, 3 );

	data[i][`getCount${ type }` ] = function() {
		return this.count;
	}

	data[i]['count'] = random( 1, 10 );

	console.log( `Element: type=${type}, count=${ data[i].count}` );
}

