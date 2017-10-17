for (var i = 0; i < data.length; i++) {

	if ( data[i] != null) {

		if( "" === data[i]) {
			data[i] = data[i] + 10;
		}
		else if ( !( data[i] !== data[i] ) && isFinite( data[i] ) )
		{
			if ( data[i] == 0 ) {
				data[i] = +data[i] + 10;
			} 
			else if ( data[i] > 100 ){
				data[i] = +data[i] - 100;
			}
			else if ( data[i] < 100 ) {
				data[i] = +data[i] + 100;
			}
		}
	}
}

