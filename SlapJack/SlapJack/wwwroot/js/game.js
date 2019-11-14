// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

//Intilazation
var pageName = window.location.pathname;

if (pageName == "playGame") {
    document.getElementById("player1Name").value = name;
}


"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/hub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});


document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});



document.getElementById("startGame").addEventListener("click", function (event) {
    var name = prompt("What is your name?");
    myName = name;
    document.getElementById("player1").value = name;
    document.getElementById("myName").value = name
    document.getElementById("playerInfo").style.visibility = "visible";
    document.getElementById("startPlay").style.disabled = "true";
    document.getElementById("gameArena").style.visibility = "visible";
    connection.invoke("StartGame", name).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});



function joinGamePrompt() {
    var name = prompt("What is your name?");
    myName = name;
    document.getElementById("player2").value = name; 
    document.getElementById("myName").value = name
    document.getElementById("playerInfo").style.visibility = "visible";
    document.getElementById("startPlay").style.disabled = "true";
    document.getElementById("gameArena").style.visibility = "visible";
    connection.invoke("JoinGame", name).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
}

document.getElementById("deckPlay").addEventListener("click", playCard);
document.getElementById("slapDeck").addEventListener("click", slapDeck);

function slapDeck() {
    var user = document.getElementById("myName").value;
    connection.invoke("PlayerSlapped", user).catch(function (err) {
        return console.error(err.toString());
    });
}

function playCard() {
    var user = document.getElementById("myName").value;
    connection.invoke("PlayerPlayed", user).catch(function (err) {
        return console.error(err.toString());
    });
}

//---Similarly commented out as it was causeing issues and immediately ending the game on first turn.
//connection.on("updateMessage", function (player) {
//    alert("Player named " + player.Name + " Won the game!");
//    window.location.replace("/");
//});

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.on("collectPile", function (playerName) {
    document.getElementById("statusMessage").innerHTML = playerName + " Slapped the Pile! Its " + playerName + "'s turn!";
});

connection.on("penalized", function (playerName) {
    document.getElementById("statusMessage").innerHTML = playerName + " got penalized! Don't slap non-matching cards!"
});

connection.on("updateUserNames", function (players) {
    document.getElementById("player1").value = players[0].name;
    document.getElementById("player2").value = players[1].name;
    if (document.getElementById("myName").value == players[0].name) {
        document.getElementById("numberOfCards").innerHTML = players[0].hand.cards.length;
    } else {
        document.getElementById("numberOfCards").innerHTML = players[1].hand.cards.length;
    }
    
});

connection.on("updateStatus", function (message) {
    document.getElementById("statusMessage").innerHTML = message;
});

connection.on("updateCards", function (displayCards, players, turnIndex) { 
    for (i = 0; i < 5; ++i) {
        document.getElementById("card" + i).src = displayCards[i].image;
    }
    document.getElementById("currentTurn").innerHTML = players[turnIndex].name;
    if (document.getElementById("myName").value == players[0].name) {
        document.getElementById("numberOfCards").innerHTML = players[0].hand.cards.length;
    } else {
        document.getElementById("numberOfCards").innerHTML = players[1].hand.cards.length;
    }
});

connection.on("updateFacePlayed", function (player1Name, player2Name, turnCounter) {
    switch (turnCounter) {
        case 0:
            document.getElementById("statusMessage").innerHTML = player1Name + " played a Joker. " + player2Name + " has 1 turn to play a facecard.";
            break;
        case 1:
            document.getElementById("statusMessage").innerHTML = player1Name + " played a Queen. " + player2Name + " has 2 turns to play a facecard.";
            break;
        case 2:
            document.getElementById("statusMessage").innerHTML = player1Name + " played a King. " + player2Name + " has 3 turns to play a facecard.";
            break;
        case 3:
            document.getElementById("statusMessage").innerHTML = player1Name + " played an Ace. " + player2Name + " has 4 turns to play a facecard.";
            break;
        default:
            document.getElementById("statusMessage").innerHTML = "Bruh lol"
            break;
    }
});
connection.on("WeHaveAWinner", function (player){
    alert(player.Name + " has Won! Thanks for playing!");
    document.location.href = window.location.origin;
});

