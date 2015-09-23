$(function () {
    $('#btnConvert').click(function () {
        var city = $('#txtCity').val();
        $.ajax({
            type: "GET",
            //url:
            data: "{city:" + city +"'}",
            ContentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $('#brottsplats_result').html(data.d);
            }
        });
    });
});