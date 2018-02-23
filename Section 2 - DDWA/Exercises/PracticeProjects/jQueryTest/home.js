function handleReady() {
    alert("Ready to go!");
}
 
// Run a named function when the document is ready.
$(document).ready(handleReady);
 
// Run an anonymous function when the document is ready.
$(document).ready(function () {
    $('H1').hide();
});

$('#emptyDiv').append('p').text('A new paragraph of text...');

$('p').remove();

$('H1').css('color','blue');

$('#emptyDiv').css({'width': '400', 'background-color': 'cornflowerBlue'});

$('H1').removeClass('notOriginal');

$('#add-button').addClass('btn btn-default');

$("#newButton").on("click", function () {
    $("h2").toggle("slow");
})

$("div").hover(
    // in callback
    function () {
        $(this).css("background-color", "CornflowerBlue");
    },
    // out callback
    function () {
        $(this).css("background-color", "");
    }
);