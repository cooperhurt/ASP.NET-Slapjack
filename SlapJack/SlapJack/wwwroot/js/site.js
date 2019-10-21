// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

//Intilazation

var pageName = window.location.pathname;

if (pageName == '/') {
    document.getElementById("rules").style.display = "none";

    document.getElementById("ruleShow").addEventListener("click", displayRules);

    function displayRules() {
        if (document.getElementById("rules").style.display === "inline") {
            document.getElementById("rules").style.display = "none";
            return;
        }
        document.getElementById("rules").style.display = "inline";
    }
}