// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

//Intilazation
var pageName = window.location.pathname;
var player1 = "";
var player2 = "";

if (pageName == "playGame") {
    document.getElementById("player1Name").value = name;
}


"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/hub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});



connection.on("UpdatePlayer", function (player1Name, player2Name) {
    document.getElementById("player1").value = player1Name;
    document.getElementById("player2").value = player2Name;
    alert("done");
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
    document.getElementById("player1").value = name;
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
    player2 = name;
    document.getElementById("player2").value = name;
    document.getElementById("playerInfo").style.visibility = "visible";
    document.getElementById("startPlay").style.disabled = "true";
    document.getElementById("gameArena").style.visibility = "visible";
    connection.invoke("updatePlayer", name).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
}