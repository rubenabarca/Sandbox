
function setupProcessing(){
    const vw = Math.max(document.documentElement.clientWidth || 0, window.innerWidth || 0);
    const vh = Math.max(document.documentElement.clientHeight || 0, window.innerHeight || 0);
    size(vw, vh);
    backgroundShade = random(255);
}

function drawProcessing(){
    background(64);
    
    setInterval(function(){ 
        const shapeindex=(int)(Math.random()*3);
        const ramdomr=(int)(Math.random()*255);
        const ramdomg=(int)(Math.random()*255);
        const ramdomb=(int)(Math.random()*255);
        fill(ramdomr,ramdomg,ramdomb);
        switch(shapeindex){
    
            case 0:
            ellipse(mouseX, mouseY, 20, 20);
            break;
            case 1:
            triangle(mouseX,mouseY,mouseX+20,mouseY-20,mouseX+20,mouseY+20);
            break;
            case 2:
            rect(mouseX,mouseY,20,20);
            break;
        }
        
    }, 16);
    

    
    document.getElementById("label").innerHTML = "Mouse coordinates: " + mouseX + ", " + mouseY;
}