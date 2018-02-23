$(document).ready(function () {
    $('h1').css({'text-align' : 'center'});
    $('h2').css({'text-align' : 'center'});
    $('.myBannerHeading').addClass('page-header').removeClass('myBannerHeading');
    $('#yellowHeading').text('Yellow Team');
    $('#orangeTeamList').css({'background-color' : 'orange'});
    $('#blueTeamList').css({'background-color' : 'blue'});
    $('#yellowTeamList').css({'background-color' : 'yellow'});
    $('#redTeamList').css({'background-color' : 'red'});
    $('#yellowTeamList').append($('<li>').text('Joseph Banks'));
    $('#yellowTeamList').append($('<li>').text('Simon Jones'));
    $('#oops').hide();
    $('#footerPlaceholder').remove();
    $('.footer').append($('<p>')).text('Ryan Sheehan RyanSheehan22@gmail.com');
    $('.footer').css({'font-family' : 'Courier'});
    $('.footer').css({'font-size' : '24'});
});