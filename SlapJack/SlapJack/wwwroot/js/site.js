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

document.getElementById("slap").addEventListener("click", slapDeck);
document.getElementById("slap").addEventListener("click", playCard);


function slapDeck() {
    alert("you slapped the deck");
}

function playCard() {
    alert("You played a card");
}