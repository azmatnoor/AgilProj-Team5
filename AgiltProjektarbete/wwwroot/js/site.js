// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let slider = document.getElementById("pricePerKmSlider");
let output = document.getElementById("pricePerKm");
output.innerHTML = slider.value + " kr";

slider.oninput = function () {
    output.innerHTML = this.value + " kr";
} 

let deletebutton = document.getElementById("deleteButton");
let deleteInput = document.getElementById("deleteCheck")
let restaurantName = document.getElementById("restaurantName");

deleteInput.oninput = function () {
    console.log(deleteInput.value + " : " + restaurantName.innerHTML);
    if (deleteInput.value == restaurantName.innerHTML) {
        deleteButton.disabled = false;
    } else {
        deletebutton.disabled = true;
    }
}