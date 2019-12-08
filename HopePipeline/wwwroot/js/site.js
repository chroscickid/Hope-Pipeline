// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#reflist').DataTable({
        "ordering" : true
    });
});

$(document).ready(function () {
    $('#trackinglist').DataTable({
        "ordering": true
    });
});

$(document).ready(function () {
    $('#reportsresultlist').DataTable({
        "ordering": true
    });
});