﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Admin -> Edit customer -> Show password
//$(document).ready(function () {
//    $('.showPassword').on('change', function () {
//        var isChecked = $(this).prop('checked');
//        if (isChecked) {
//            $('.my-password').attr('type', 'text');
//        } else {
//            $('.my-password').attr('type', 'Password');
//        }
//    });
//});


function showPassword() {
    var x = document.getElementById("inputPassword");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
};