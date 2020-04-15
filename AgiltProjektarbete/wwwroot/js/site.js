// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var slider = document.getElementById("pricePerKmSlider");
var output = document.getElementById("pricePerKm");
output.innerHTML = slider.value + " kr";

slider.oninput = function () {
    output.innerHTML = this.value + " kr";
} 