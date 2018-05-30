function clearErrors() {    
    for (var loopCounter = 0; 
        loopCounter < document.forms["displayEvens"].elements.length; 
        loopCounter++) {
        if (document.forms["displayEvens"].elements[loopCounter]
           .parentElement.className.indexOf("has-") != -1) {
            
            document.forms["displayEvens"].elements[loopCounter]
               .parentElement.className = "form-group";
        }
    }    
}
function resetForm() {
    clearErrors();
    document.forms["displayEvens"]["startingNumber"].value = "";
    document.forms["displayEvens"]["endingNumber"].value = "";
    document.forms["displayEvens"]["step"].value = "";
    document.getElementById("results").style.display = "none";
    document.getElementById("submitButton").innerText = "DisplayEvens";
    document.forms["displayEvens"]["startingNumber"].focus();
}
function displayEvens(startingNumber, endingNumber, step) {

    var startingNumber = parseInt(document.getElementById("startingNum").value);
    var endingNumber = parseInt(document.getElementById("endingNum").value);
    var step = parseInt(document.getElementById("stepNum").value);
    var evenNums = [];
    for (var i = startingNumber; i < endingNumber; i += step) {
        if (i % 2 == 0) {
            evenNums.push(i);
        }
    }
    document.getElementById("evens").innerText = evenNums;
}
function validateItems() {
    clearErrors();
    displayEvens(startingNumber, endingNumber, step);

    var startingNumber = document.forms["displayEvens"]["startingNumber"].value;
    var endingNumber = document.forms["displayEvens"]["endingNumber"].value;
    var step = document.forms["displayEvens"]["step"].value;
    if (startingNumber == "" || isNaN(startingNumber)) {
        alert("Starting Number must be filled in with a number.");
        document.forms["displayEvens"]["startingNumber"]
           .parentElement.className = "form-group has-error";
        document.forms["displayEvens"]["startingNumber"].focus();
        return false;
    }
   if (endingNumber == "" || isNaN(endingNumber)) {
       alert("Ending Number must be filled in with a number.");
       document.forms["displayEvens"]["endingNumber"]
          .parentElement.className = "form-group has-error"
       document.forms["displayEvens"]["endingNumber"].focus();
       return false;
   }
   /*if (endingNumber <= startingNumber) {
       alert("Ending Number must be greater than the Starting number.");
       document.forms["displayEvens"]["endingNumber"]
          .parentElement.className = "form-group has-error"
       document.forms["displayEvens"]["endingNumber"].focus();
       return false;*/
   }
   /*if (step == "" || isNaN(step)) {
       alert("Step Number must be filled in with a number.");
       document.forms["displayEvens"]["step"]
          .parentElement.className = "form-group has-error"
       document.forms["displayEvens"]["step"].focus();
       return false;*/
   }
    if (step < 0) {
       alert("Step Number must be filled in with a positive number.");
       document.forms["displayEvens"]["step"]
          .parentElement.className = "form-group has-error"
       document.forms["displayEvens"]["step"].focus();
       return false;
   }

    document.getElementById("results").style.display = "block";
    document.getElementById("submitButton").innerText = "Recalculate";
    document.getElementById("startingNum").innerText = Number(startingNumber);
    document.getElementById("endingNum").innerText = Number(endingNumber);
    document.getElementById("stepNum").innerText = Number(step);
    document.getElementById("evens").innerText = Number(evenNums);
    return false;
}