$(document).ready(function () {
    
});
$("h1").css("text-align", "center");
$("h2").css("text-align", "center");
$("h1").removeClass("#myBannerHeading");
$("h1").addClass("page-header");
$("#yellowHeading").text("Yellow Team");
$("#yellowHeading").css('background-color', 'yellow');
$("#orangeHeading").css('background-color', 'orange');
$("#blueHeading").css('background-color', 'blue');
$("#redHeading").css('background-color', 'red');
$("#yellowTeamList").html("<li>Joseph Banks</li> <li>Simon Jones</li>");
$("#oops").hide();
$("#footerPlaceholder").remove();
$("#footer").append('p').text("Brad Lifford - brlifford@gmail.com")
.css({"font-family" : "Courier", "font-size" : "24px"})