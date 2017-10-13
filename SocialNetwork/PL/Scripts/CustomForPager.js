var dataModule = (function () {
    var _includeData = function (data) {
        $(".image_handler").show();

        for (var j = 0; j < data.PagingInfo.ItemsPerPage; j++) {
            if (data.Images[j] == undefined) {
                $(".image_handler-" + j).hide();
                continue;
            }
            $(".image-description" + j).text(data.Images[j].Description);
            $(".image-" + j).attr('src', data.Images[j].ImageSmall);
            $(".image__ligthbox-" + j).attr('href', data.Images[j].Image);
        }
    };

    var _backData = function (data) {
        _includeData(data);
    }

    return {
        includeData: _includeData,
        backData: _backData
    }
}());

