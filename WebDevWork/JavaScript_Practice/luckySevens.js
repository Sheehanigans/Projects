function greeting(){

    alert("Welcome to Lucky Sevens! If you roll a 7, you get $4. If you don't, you lose $1. Now place a bet!");
       
}

function validate(){
    var bet = document.getElementById("betAmount").value;
    if (bet <= 0){
        alert("Bet must be a number greater than 0.");
        return false;
    } else {
        playGame();
        document.getElementById("startingBet").innerText = bet;
    }
}

function playGame(){

    var gameMoney = document.getElementById("betAmount").value;
    var rolls = 0; 

    do {
        var dice1 = (Math.ceil(Math.random() * (1 + 6 - 1)));
        var dice2 = (Math.ceil(Math.random() * (1 + 6 - 1)));

        if (dice1 + dice2 != 7){
            gameMoney--;
            rolls++;
        } else {
            gameMoney++;
            gameMoney++;
            gameMoney++;
            gameMoney++;
            rolls++;
        }
    } 
    while (gameMoney > 0);
    document.getElementById("totalRolls").innerText = rolls;
    document.getElementById("play").innerText = "Play Again?";
    document.getElementById("results").style.display = "block";
    document.getElementById("rollingDiceGif").style.display = "block";
}