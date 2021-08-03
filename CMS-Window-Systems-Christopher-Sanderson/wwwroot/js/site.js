// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
    var qrcode = document.getElementById("qrcode");
    if(qrcode.style.display != "none") {
    window.print();
}
//var barcodeInput = document.getElementById("qrText");
//var regExp = /[a-zA-Z/g;];
//var alphabet = ['A', 'a', 'B', 'b', 'C', 'c', 'D', 'd', 'E', 'e', 'F', 'f', 'G', 'g', 'H', 'h', 'I', 'i', 'J', 'j', 'K', 'k', 'L', 'l', 'M', 'm', 'N', 'n', 'O', 'o', 'P', 'p', 'Q', 'q', 'R', 'r', 'S', 's', 'T', 't', 'U', 'u', 'V', 'v', 'W', 'w', 'X', 'x', 'Y', 'y', 'Z', 'z'];
//if (regExp.test(barcodeInput.onkeyup)) {
//    foreach(var item in alphabet)
//    {
//        if (barcodeInput.hasAttribute() == item) {
//            barcodeInput.removeAttribute(item);
//        }
//    }
//}
