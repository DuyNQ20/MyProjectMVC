

$(document).ready(function () {
    // Không cho phép nhập chữ và quá 20 ký tự
    $('#number').keypress(function (e) {
        if (e.charCode < 48 || e.charCode > 57) {
            return false;
        }
    });
})

$(document).ready(function () {
    // Không cho phép nhập chữ và quá 20 ký tự
    $('.number').keypress(function (e) {
        if (e.charCode < 48 || e.charCode > 57) {
            return false;
        }
    });
})


// cho tăng số lượng sản phẩm trong giỏ hàng
$(".btn-down").click(function () {
    var id = $(this).next().attr('id');
    IncreaseOneUnit(id, false);
});

$(".btn-up").click(function () {
    var id = $(this).prev().attr('id');
    
    IncreaseOneUnit(id, true);
});


// operator == true <=> cộng
function IncreaseOneUnit(id, operator) {
    var number = $("#" + id).val();
    number = operator ? ++number : --number;
   
    if (number < 1) return;
    $("#" + id).val(number);
}