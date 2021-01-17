﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('body').on('click', '.btn-add-cart', function (e) {
    e.preventDefault();
    const id = $(this).data('id');
    const culture= $("#hidCulture").val();
    $.ajax({
        type: "POST",
        dataType: 'json',
        url: '/' + culture +'/cart/AddToCart',
        data: {
            id: id,
            languageId: culture
        },
        success: function (res) {
            console.log(res);
        },
        error: function (err) {
            console.log(err);
        }
    });
});
