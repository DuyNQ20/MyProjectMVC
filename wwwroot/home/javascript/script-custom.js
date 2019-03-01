

$(document).ready(function () {
    // Không cho phép nhập chữ và quá 20 ký tự
    $('#number').keypress(function (e) {
        if (e.charCode < 48 || e.charCode > 57) {
            return false;
        }
    });
})
