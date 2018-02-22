$(document).ready(function () {
    $('#akronInfoDiv').hide();
    $('#minneapolisInfoDiv').hide();
    $('#louisvilleInfoDiv').hide();
    $('#akronWeather').hide();
    $('#minneapolisWeather').hide();
    $('#louisvilleWeather').hide();

    $('tr').hover( function(){
        $(this).parent().css('background-color' , 'WhiteSmoke');
    }, function(){
        $(this).parent().css('background-color', 'white');
    })
});

$('#akronButton').click( function(){
    $('#akronInfoDiv').show();
    $('#minneapolisInfoDiv').hide();
    $('#louisvilleInfoDiv').hide();
    $('#mainInfoDiv').hide();
})
$('#louisvilleButton').click( function(){
    $('#louisvilleInfoDiv').show();
    $('#akronInfoDiv').hide();
    $('#minneapolisInfoDiv').hide();
    $('#mainInfoDiv').hide();
})

$('#minneapolisButton').click( function(){
    $('#minneapolisInfoDiv').show();
    $('#akronInfoDiv').hide();
    $('#louisvilleInfoDiv').hide();
    $('#mainInfoDiv').hide();
})

$('#akronWeatherButton').click( function(){
    $('#akronWeather').toggle();
})

$('#louisvilleWeatherButton').click( function(){
    $('#louisvilleWeather').toggle();
})

$('#minneapolisWeatherButton').click( function(){
    $('#minneapolisWeather').toggle();
})
