var imageIndex = 1;
var imageClassCount = 8;
window.onload = setInterval(rotateHomeBackground, 7000);

function rotateHomeBackground()
{
    var homeBackground = document.getElementById("home-background");
    homeBackground.classList.remove('home-background-image-' + imageIndex);
    imageIndex = (imageIndex + 1) % imageClassCount;
    homeBackground.classList.add('home-background-image-' + imageIndex);
}