var isMouseTracking = false;

// We need a function to update the position 
// On our front-end we have two labels - 
// one for X and one for Y
function updateMousePosition() {

    // If trackin is enabled, update the labels 
    if (isMouseTracking) {

        //We can get the mouse position with 
        // event.clientX and event.clientY 
        // We can update the rest of the HTML document 
        // with the innerText property
        var positionX = document.getElementById("mousePositionX");
        positionX.innerText = event.clientX;

        var positionY = document.getElementById("mousePositionY");
        positionY.innerText = event.clientY;
    }
}

// We need a function to toggle whether tracking is enabled 
function toggleTracking() {

    // If isMouseTracking is true, set it to false
    // Otherwise it is false, and needs to be true
    isMouseTracking = !isMouseTracking;

    // Update the tracking status to show whether it is enabled
    if (isMouseTracking) {
        document.getElementById("trackingStatus").innerText = "TRACKING";
    } else {
        document.getElementById("trackingStatus").innerText = "NOT TRACKING";
    }
}