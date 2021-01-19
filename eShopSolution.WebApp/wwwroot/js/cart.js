var CartController = function () {

    this.initialize = function () {
        LoadData();
    }

    function LoadData() {
        const culture = $("#hidCulture").val();
        const baseAddress = $("#hidBaseAddress").val();
        $.ajax({
            type: "GET",
            dataType: 'json',
            url: '/' + culture + '/cart/GetListItems',
            success: function (res) {
                var resHtml = '';
                var total = 0;
                $.each(res, function (i, item) {
                    var amount = item.price * item.quantity;

                    resHtml += "<tr>"
                        + " <td> <img width=\"60\" src=\"" + baseAddress + item.image + "\" alt=\"" + item.name + "\" /></td>"
                        + " <td>" + item.description +"</td>"
                        + " <td>"
                        + " <div class=\"input-append\">"
                        + " <input class=\"span1\" style=\"max - width: 34px\" placeholder=\"1\" id=\"appendedInputButtons\" size=\"16\" type=\"text\">"
                        + " <button class=\"btn\" type = \"button\" > <i class=\"icon-minus\"></i></button >"
                        + " <button class=\"btn\" type=\"button\"><i class=\"icon-plus\"></i></button>"
                        + " <button class=\"btn btn - danger\" type=\"button\"><i class=\"icon-remove icon-white\"></i></button>"
                        + " </div >"
                        + " </td>"
                        + " <td>" + numberWithCommas(item.price) +"</td>"
                        + " <td>--</td>"
                        + " <td>--</td>"
                        + " <td>" + numberWithCommas(amount) +"</td>"
                        + " </tr>";

                    total += amount;
                });

                $("#cart-body").html(resHtml);
                $("#lbl-number-of-items").text(res.length);
                $("#lbl-total").text(numberWithCommas(total));
            },
            error: function (err) {
                console.log(err);
            }
        });
    }
}