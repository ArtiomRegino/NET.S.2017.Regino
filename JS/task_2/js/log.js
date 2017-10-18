var sum = [ { type: 1, count: 0 },
  			{ type: 2, count: 0 },
  			{ type: 3, count: 0 }]

for (var i = 0; i < data.length; i++) {

	for (var j = 0; j < sum.length; j++) {

		if (`getCount${ sum[j].type }` in data[i] ) {
			sum[j].count += data[i][`getCount${ j + 1 }` ]();
			break;
		}
	}
}

for (var i = 0; i < sum.length; i++) {
	console.log( `count{${ sum[i].type }}={${ sum[i].count }}` );
}