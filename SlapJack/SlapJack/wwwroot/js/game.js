// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

//Intilazation
var pageName = window.location.pathname;

if (pageName == "playGame") {
    document.getElementById("player1Name").value = name;
}


//Game code that is neded
$(document).ready(function () {
    $("#slap").click(function (e) {
        e.preventDefault();
        $.ajax({
            type: "POST",
            url: "Pages/playGame/?handler=",
            dataType: 'jason',
            data: {
                userName: $("#player1Name").val(),
                access_token: $("#access_token").val()
            },
            success: function (result) {
                alert('ok');
            },
            error: function (result) {
                alert('There was an error');
            }
        });
    });

     $("#playCard").click(function (e) {
            e.preventDefault();
            $.ajax({

                type: "POST",
                url: "Pages/playGame/?handler=",
                contentType: "application/json; charset=utf-8",
                beforeSend: function (xhr) { xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val()); },
                data: {
                    id: $("#button_1").val(),
                    access_token: $("#access_token").val()
                },
                success: function (result) {
                    alert('ok');
                },
                error: function (result) {
                    alert('error');
                }
            });
     });
});