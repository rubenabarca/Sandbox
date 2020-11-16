
function setupProcessing(){
    const vw = Math.max(document.documentElement.clientWidth || 0, window.innerWidth || 0);
    const vh = Math.max(document.documentElement.clientHeight || 0, window.innerHeight || 0);
    size(vw, vh);
    backgroundShade = random(255);
}

function drawProcessing(){
    background(64);
    ellipse (45,76,45,76);
    
    document.getElementById("label").innerHTML = "Mouse coordinates: " + mouseX + ", " + mouseY;
}