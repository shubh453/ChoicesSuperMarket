// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(() => {
    document.querySelectorAll('.unit-count')
        .forEach((ele) => {
            if (+ele.innerHTML > 0 && !$('.order-process').is(':visible')) { $('.order-process').show(); }
        });
});
$(function () {
    $("ul.dropdown-menu [data-toggle='dropdown']").on("click", function (event) {
        event.preventDefault();
        event.stopPropagation();

        $(this).siblings().toggleClass("show");

        if (!$(this).next().hasClass('show')) {
            $(this).parents('.dropdown-menu').first().find('.show').removeClass("show");
        }
        $(this).parents('li.nav-item.dropdown.show').on('hidden.bs.dropdown', function (e) {
            $('.dropdown-submenu .show').removeClass("show");
        });
    });
});

const addOrderItem = function (productId, userId) {
    let units = parseInt($('#unit_count_' + productId).html())
    document.querySelectorAll('.unit-count')
        .forEach((ele) => {
            if (+ele.innerHTML > 0 && !$('.order-process').is(':visible')) { $('.order-process').show(); }
        });

    $.ajax({
        url: 'Home/AddOrderItem',
        data: {
            ProductId: productId,
            CustomerId: userId,
        },
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            if (result.isAdded) {
                $('#unit_count_' + productId).html(units + 1);
                $('#message_' + productId).show().html("Added");
                setTimeout(() => { $('#message_' + productId).hide(); }, 2000)
            } else {
                $('#message_' + productId).css('color', 'red').show().html("Error");
                setTimeout(() => { $('#message_' + productId).hide(); }, 2000)
            }
        },
        error: function (error) {
            $('#message_' + productId).css('color', 'red').show().html("Error");
            setTimeout(() => { $('#message_' + productId).hide(); }, 2000)
        }
    });
    return false;
};

const removeOrderItem = function (productId, userId) {
    let units = parseInt($('#unit_count_' + productId).html());
    if (units === 0)
        return;
    let totalUnits = 0;
    document.querySelectorAll('.unit-count')
        .forEach((ele) => {
            totalUnits += +ele.innerHTML;
        });
    if (totalUnits === 0) { $('.order-process').hide(); }

    $.ajax({
        url: 'Home/RemoveOrderItem',
        data: {
            ProductId: productId,
            CustomerId: userId,
        },
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            if (result.isRemoved) {
                $('#unit_count_' + productId).html(units - 1);
                $('#message_' + productId).show().html("Removed");
                setTimeout(() => { $('#message_' + productId).hide(); }, 2000)
            } else {
                $('#message_' + productId).css('color', 'red').show().html("Error");
                setTimeout(() => { $('#message_' + productId).hide(); }, 2000)
            }
        },
        error: function (error) {
            $('#message_' + productId).css('color', 'red').show().html("Error");
            setTimeout(() => { $('#message_' + productId).hide(); }, 2000)
        }
    });
    return false;
}

const cancel = (customerId) => {
    $.ajax({
        url: 'Home/CancelOrder',
        data: { userId: customerId },
        success: function (result) {
            if (result.isCanceled) {
                window.location.reload();
            }
            else {
                $('#error-message').show().html(result.message);
                setTimeout(() => {
                    $('#error-message').hide();
                }, 2000);
            }
        },
        error: function (error) {
            $('#error-message').show().html(error.message);
            setTimeout(() => {
                $('#error-message').hide();
            }, 2000);
        }
    });
};