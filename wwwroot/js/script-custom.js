

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

    

    $('#originalprice').keyup(function (e) {
        convertNumber(this);
    });
    $('#saleprice').keyup(function (e) {
        convertNumber(this);
    });
    $('#inventory').keyup(function (e) {
        convertNumber(this);
    });

    // Hàm chuyển thành dấu phẩy khi nhấn xuống
    function convertNumber(id) {
        var so = $(id).val();
        so = convertToNumber(so);
        so = so.substring(0, so.length - 3); // Bỏ đuôi .00
        $(id).val(so);
    }

    // Chuyển ngược lại từ 20,000 => 20000
    function convertToNumber(numberString) {
        return formatCurrency(numberString.replace(/,/g, ""));
    }

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



/// Upload file

function readURL(input, placeToInsertImagePreview) { // Hien thi anh khi upload

    if (input.files) {
        if (CheckFileAmount(input))
        {
            var filesAmount = input.files.length;
            for (i = 0; i < filesAmount; i++) {
                var reader = new FileReader();
                reader.onload = function (event) {
                    $($.parseHTML('<img>')).attr('src', event.target.result).appendTo(placeToInsertImagePreview);
                }
                reader.readAsDataURL(input.files[i]);
            }
        }
       
    }
}

function CheckFileAmount(input) {
    if (input.files.length > 4) {
        alert("Bạn chỉ có thể upload tối đa 4 ảnh");
        return false;
    } else {
        return true;
    }
}
function remoteImage(placeRemove) { // Remove ảnh khi hiển thị rồi

    $(placeRemove).remove();
}

$("#image-file").change(function () {
    remoteImage("div.show-image.file img");
    readURL(this, "div.show-image.file");
});

$("#image-files").change(function () {
    remoteImage("div.show-image.files img");
    readURL(this, "div.show-image.files");
});


