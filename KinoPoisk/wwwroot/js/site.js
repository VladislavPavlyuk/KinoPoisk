// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#btnSearch').click(function () {
        var movieName = $('#txtMovieName').val();
        $.ajax({
            url: '/Home/GetMovieInfo',
            type: 'GET',
            data: { movieName: movieName },
            success: function (data) {
                $('#movieInfo').html(data);
            },
            error: function () {
                $('#movieInfo').html('Ошибка при получении данных.');
            }
        });
    });
});
