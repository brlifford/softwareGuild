$(document).ready(function () {
 

	$("#akronInfoDiv").hide();
	$("#minneapolisInfoDiv").hide();
	$("#louisvilleInfoDiv").hide();

	$("#mainButton").on("click", function hideAll() {
		$("#akronInfoDiv").hide();
		$("#minneapolisInfoDiv").hide();
		$("#louisvilleInfoDiv").hide();
		$("#mainInfoDiv").show();
	});

	$("#akronButton").on("click", function(hideAll) {
		$("#mainInfoDiv").hide();
		$("#akronInfoDiv").show();
			
	});

	$("#minneapolisButton").on("click", function(hideAll) {
		$("#mainInfoDiv").hide();
		$("#minneapolisInfoDiv").show();
	});

	$("#louisvilleButton").on("click", function(hideAll) {
		$("#mainInfoDiv").hide();
		$("#louisvilleInfoDiv").show();
	});

	$(".btn-default").on("click", function() {
		$("#akronWeather").toggle();
		$("#minneapolisWeather").toggle();
		$("#louisvilleWeather").toggle();
	});

	


	$("tr").hover( function() {
		$(this).css("background-color", "WhiteSmoke");
	},
	function() {
		$(this).css("background-color", "");
	});

	$("table > tr:first").hover( function() {
		$(this).css("background-color", "AliceBlue");
	},
	function() {
		$(this).css("background-color", "");
	});
   
});