$(document).ready(function () {
 

	$("#akronInfoDiv").hide();
	$("#minneapolisInfoDiv").hide();
	$("#louisvilleInfoDiv").hide();

	$("#mainButton").on("click", function() {
		$("#akronInfoDiv").hide();
		$("#minneapolisInfoDiv").hide();
		$("#louisvilleInfoDiv").hide();
		$("#mainInfoDiv").show();
	});

	$("#akronButton").on("click", function() {
		$("#mainInfoDiv").hide();
		$("#akronInfoDiv").show();
		$("#akronWeather").hide();
		$("#minneapolisInfoDiv").hide();
		$("#louisvilleInfoDiv").hide();
		
	});

	$("#minneapolisButton").on("click", function() {
		$("#mainInfoDiv").hide();
		$("#minneapolisInfoDiv").show();
		$("#minneapolisWeather").hide();
		$("#akronInfoDiv").hide();
		$("#louisvilleInfoDiv").hide();
	});

	$("#louisvilleButton").on("click", function() {
		$("#mainInfoDiv").hide();
		$("#louisvilleInfoDiv").show();
		$("#louisvilleWeather").hide();
		$("#akronInfoDiv").hide();
		$("#minneapolisInfoDiv").hide();
	});

	$(".btn-default").on("click", function() {
		$("#akronWeather").toggle();
		$("#minneapolisWeather").toggle();
		$("#louisvilleWeather").toggle();
	});

	


	$("tr:not([bgcolor])").hover( function() {
		$(this).css("background-color", "WhiteSmoke");
	},
	function() {
		$(this).css("background-color", "");
	});
   
});