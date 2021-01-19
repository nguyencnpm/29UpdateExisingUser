// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var SiteController = function () {
    this.initialize = function () {
        regsiterEvents();
        LoadData();
    }

    function regsiterEvents() {
        $('body').on('click', '.btn-add-cart', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            const culture = $("#hidCulture").val();
            $.ajax({
                type: "POST",
                dataType: 'json',
                url: '/' + culture + '/cart/AddToCart',
                data: {
                    id: id,
                    languageId: culture
                },
                success: function (res) {
                    console.log(res);
                    $('#lbl_number_items_header').text(res.length); // LoadData();
                },
                error: function (err) {
                    console.log(err);
                }
            });
        });
    }

    function LoadData() {
        const culture = $("#hidCulture").val();
        $.ajax({
            type: "GET",
            dataType: 'json',
            url: '/' + culture + '/cart/GetListItems',
            success: function (res) {
                $('#lbl_number_items_header').text(res.length);
            }
        });
    }
}

function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}
