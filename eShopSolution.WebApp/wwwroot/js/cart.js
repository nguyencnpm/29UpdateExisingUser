var CartController = function () {

    this.initialize = function () {
        LoadData();
        regsiterEvents();
    }

    function LoadData() {
        const culture = $("#hidCulture").val();
        const baseAddress = $("#hidBaseAddress").val();
        $.ajax({
            type: "GET",
            dataType: 'json',
            url: '/' + culture + '/cart/GetListItems',
            success: function (res) {
                if (res.length === 0) {
                    $('#tbl_cart').hide();
                }
                var resHtml = '';
                var total = 0;
                $.each(res, function (i, item) {
                    var amount = item.price * item.quantity;

                    resHtml += "<tr>"
                        + " <td> <img width=\"60\" src=\"" + baseAddress + item.image + "\" alt=\"" + item.name + "\" /></td>"
                        + " <td>" + item.description +"</td>"
                        + " <td>"
                        + " <div class=\"input-append\">"
                        + " <input id=\"txt_quantity_" + item.productId + "\" class=\"span1\" placeholder=\"1\" value=\"" + item.quantity + "\" size=\"16\" type=\"text\" style=\"max-width: 34px\">"
                        + " <button class=\"btn btn_minus\" data-id=\"" + item.productId +"\" type = \"button\" > <i class=\"icon-minus\"></i></button >"
                        + " <button class=\"btn btn_plus\" data-id=\"" + item.productId +"\" type=\"button\"><i class=\"icon-plus\"></i></button>"
                        + " <button class=\"btn btn-danger btn_remove\" data-id=\"" + item.productId +"\" type=\"button\"><i class=\"icon-remove icon-white\"></i></button>"
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

    function updateCart(id, quantity) {
        const culture = $("#hidCulture").val();
        $.ajax({
            type: "POST",
            dataType: 'json',
            url: '/' + culture + '/cart/UpdateCart',
            data: {
                id: id,
                quantity: quantity
            },
            success: function (res) {
                console.log(res);
                LoadData();
            },
            error: function (err) {
                console.log(err);
            }
        });
    }

    function regsiterEvents() {
        $('body').on('click', '.btn_plus', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const quantity = parseInt($("#txt_quantity_" + id).val()) + 1;
            updateCart(id, quantity);
        });

        $('body').on('click', '.btn_minus', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const quantity = parseInt($("#txt_quantity_" + id).val()) - 1;
            updateCart(id, quantity);
        });

        $('body').on('click', '.btn_remove', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const quantity = 0;
            updateCart(id, quantity);
        });
    }
}