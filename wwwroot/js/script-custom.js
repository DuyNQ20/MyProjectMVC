

$(document).ready(function () {
// Không cho phép nhập số và quá 20 ký tự
    $('#originalprice').keypress(function (e) {
        if (e.charCode < 48 || e.charCode > 57 || $(this).val().length > 20) {
            return false;
        }
    });
    $('#saleprice').keypress(function (e) {
        if (e.charCode < 48 || e.charCode > 57 || $(this).val().length > 20) {
            return false;
        }
    });
    $('#inventory').keypress(function (e) {
        if (e.charCode < 48 || e.charCode > 57 || $(this).val().length > 20) {
            return false;
        }
    });



// Chuyển tiền sang dạng dấu phảy

    function convertNumber(id) {
        var so = $(id).val();
        so = formatCurrency(so.replace(/,/g, "")); // chuyển từ 20,000 => 20000
        so = so.substring(0, so.length - 3); // Bỏ đuôi .00
        $(id).val(so);

       
    }

    $('#originalprice').keyup(function (e) {
        convertNumber(this);
    });
    $('#saleprice').keyup(function (e) {
        convertNumber(this);
    });
    $('#inventory').keyup(function (e) {
        convertNumber(this);
    });

    // Chuyển tiền sang dạng có phẩy (20,000.00)
    function formatCurrency(total) {
        var neg = false;
        if (total < 0) {
            neg = true;
            total = Math.abs(total);
        }
        return (neg ? "" : '') + parseFloat(total, 10).toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, "$1,").toString();
    }
// END Chuyển tiền sang dạng dấu phảy

})