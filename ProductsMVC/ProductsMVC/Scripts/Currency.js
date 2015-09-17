
$(function() {
    $('#btnConvert').click(function() {
        var amount = $('#txtAmount').val();
        var from = $('#ddlfrom').val();
        var to = $('#ddlto').val();
        $.ajax({ type: "POST",
            url: "https://www.google.com/finance/converter?a",
            data: "{amount:" + amount + ",fromCurrency:'" + from + "',toCurrency:'" + to + "'}",
            ContentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(data) {
                $('#currency_converter_result').html(data.d);
            }
        });
    });
});