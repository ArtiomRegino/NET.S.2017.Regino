'use strict';
for (var i = 0; i < data.length; i++) {
	var result = `data[${i}]=${data[i]}`;

	if (result.includes(undefined)) {
		result = "не определено";
	}
	else if (result.includes(null)) {
		result = "не указано";
	}

	console.log(result);
}