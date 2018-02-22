
function handleReady() {
    alert("Welcome to the game!");
}

$(document).ready(ShellGame);

var pup1 = (Math.ceil(Math.random() * 6));
var pup2 = (Math.ceil(Math.random() * 6));
var pup3 = (Math.ceil(Math.random() * 6));

function ShowPups(){
    var validPups = false;
    
    while(!validPups){

        if(pup1 == pup2){
            pup1 = (Math.ceil(Math.random() * 6));
        }
        else if(pup1 == pup3){
            pup1 = (Math.ceil(Math.random() * 6));
        }
        else if (pup2 == pup3){
            pup2 = (Math.ceil(Math.random() * 6));
        }

        if(pup1 != pup2  && pup1 != pup3&& pup2 != pup3);
    }
}

function ShellGame(){

    var gameOver = false;

    var winningNumber = (Math.ceil(Math.random() * 3));

    $("#shell1").on("click", function () {
        PlayAgainButton();
        if(!gameOver){
            if(winningNumber == 1){
                document.getElementById("winner").style.display = "block";
            }
            else{
                document.getElementById("loser").style.display = "block";
            }
        }
        gameOver = true;        
    })
    
    $("#shell2").on("click", function () {
        PlayAgainButton();
        if(!gameOver){
            if(winningNumber == 2 && !gameOver){
                document.getElementById("winner").style.display = "block";
            }
            else{
                document.getElementById("loser").style.display = "block";
            }
        }
        gameOver = true;        
    })
    
    $("#shell3").on("click", function () {
        PlayAgainButton();
        if(!gameOver){
            if(winningNumber == 3 && !gameOver){
                document.getElementById("winner").style.display = "block";
            }
            else{
                document.getElementById("loser").style.display = "block";
            }
        }
        gameOver = true;        
    })

    $('#playAgain').click(function(){
        location.reload();
    });

}

function PlayAgainButton(){
    document.getElementById("playAgain").style.display = "block";
}
