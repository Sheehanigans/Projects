function rollDice(minimum, maximum) {
    return Math.ceil(Math.random() * (1 + maximum - minimum));
}
/*
for (var i = 0; i < 10; i++) {
    console.log(rollDice());
}*/