'use strict';
for (var i = 0; i < data.length; i++) {
	var result = `data[${i}]=${data[i]}`;

	result = result.replace("undefined", "не определено");
	result = result.replace("null", "не указано");

	console.log(result);
}