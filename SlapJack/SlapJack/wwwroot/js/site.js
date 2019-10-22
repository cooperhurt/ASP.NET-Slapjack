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