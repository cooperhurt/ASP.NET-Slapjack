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


connection.on("updateUserNames", function (players) {
    document.getElementById("player1").value = players[0].name;
    document.getElementById("player2").value = players[1].name;
});


connection.on("updateCards", function (displayCards) {
    for (i = 0; i < 5; ++i){
        document.getElementById("card" + i).src = displayCards[i].image;
    }
});

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

connection.on("collectPile", function () {
    alert("You Got the Pile! Its your turn!");
});

connection.on("penalized", function () {
    alert("You got penalized! Don't slap out of turn!");
});


document.getElementById("deckPlay").addEventListener("click", playCard);
document.getElementById("slapDeck").addEventListener("click", slapDeck)

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


connection.on("updateMessage", function (player1Name, message) {
    alert("User " + player1Name + " " + message);
});



connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});