// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let product_name = document.querySelector("#product_name");

function fetchJSONData() {
    fetch('./json/testProducts.json')
        .then((res) => {
            if (!res.ok) {
                throw new Error(`Entre em contato com o administrador! Error Status: ${res.status}`);
            }
            return res.json();
        })
        .then((data) => data.Products.map((product) => {
            console.log(product);
        })
        .catch((error) => console.error("Não foi possível carregar JSON", error)));
}

fetchJSONData();