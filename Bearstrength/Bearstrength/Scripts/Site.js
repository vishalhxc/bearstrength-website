var imageIndex = 1;
var imageClassCount = 8;
window.onload = setInterval(scrollHomeBackground, 7000);

//Scrolls through the images on the home page.
function scrollHomeBackground()
{
    var homeBackground = document.getElementById("home-background");
    homeBackground.classList.remove('home-background-image-' + imageIndex);
    imageIndex = (imageIndex + 1) % imageClassCount;
    homeBackground.classList.add('home-background-image-' + imageIndex);
}