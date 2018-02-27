var c1 = document.getElementById("canvas1");
var ctx1 = c1.getContext("2d");

//background gradient
var grd = ctx1.createLinearGradient(0,0,600,0);
grd.addColorStop(0, "red");
grd.addColorStop(1, "white");

//fill with gradient
ctx1.fillStyle = grd;
ctx1.fillRect(0,0,600,300);

//words
ctx1.font = "50px Arial";
ctx1.strokeText("HACKERMAN",140,180)

//line bottom
ctx1.moveTo(0,190);
ctx1.lineTo(600,190);
ctx1.stroke();

//line top
ctx1.moveTo(0,135);
ctx1.lineTo(600,135);
ctx1.stroke();

var c2 = document.getElementById("canvas2");

