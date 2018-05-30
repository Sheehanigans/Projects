function displayEvens(startNum, endNum, stepNum){

    validateForm();

    var startNum = parseInt(document.getElementById("startingNumberInput").value);
    var endNum = parseInt(document.getElementById("endingNumberInput").value);
    var stepNum = parseInt(document.getElementById("stepInput").value);
    var evenNums = [];

    for (var i = startNum; i < endNum; i += stepNum){
        if (i % 2 == 0) {
            evenNums.push(i);
        }
    }
    document.getElementById("results").innerText = evenNums.join('\n');
    document.getElementById("displayStartingNumber").innerText = startNum;
    document.getElementById("displayEndingNumber").innerText = endNum;
    document.getElementById("displayStep").innerText = stepNum;
    document.getElementById("display").style.display = "block";
}

function validateForm(){

    var startNum = parseInt(document.getElementById("startingNumberInput").value);
    var endNum = parseInt(document.getElementById("endingNumberInput").value);
    var stepNum = parseInt(document.getElementById("stepInput").value);

    if (startNum == "" || isNaN(startNum)){
        alert("Starting Number must be filled with a number.")
    }
    if (endNum == "" || isNaN(endNum)){
        alert("Ending Number must be filled with a number.")
    }
    if (stepNum == "" || isNaN(stepNum)){
        alert("Step must be filled with a number.")
    }
    if (stepNum < 0){
        alert("Step must be greater than 0.")
    }
    if (endNum <= startNum){
        alert("Ending Number must be greater than Starting Number.")
    }
}

function formReset(){

    document.getElementById("results").innerText = "";
    document.getElementById("display").style.display = "none";
}