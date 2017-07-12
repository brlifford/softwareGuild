$(document).ready(function() {
	
	$('h1').addClass('text-center');
	$('#get-weather-form').addClass('text-center');
	$('#get-weather-button').click(function (event) {
		var zip = $('#zipcode-field').val();
		var units = $('#units-field').val();
		var haveValidationErrors = checkAndDisplayValidationErrors($('#add-form').find('input'));
		
		
		if(haveValidationErrors) {
			return false;
		}
		
		$.ajax({
			type: 'GET',
			url:'http://api.openweathermap.org/data/2.5/weather?zip=' + zip + ',us&units=' + units + '&appid=fbddcf43684bc1e6b00290e4d4bb3c61',
			success: function(weatherArray) {			
				
				var contentRows = $('#contentRows');
				var locName = weatherArray.name;
				var descript = weatherArray.weather[0].main;
				var temp = weatherArray.main.temp;
				var humidity = weatherArray.main.humidity;
				var wind = weatherArray.wind.speed;
				var iconfile = weatherArray.weather[0].icon;
				var icon = '<img src="http://openweathermap.org/img/w/' + iconfile + '.png"/>';
				
				$('#display-weather-city').text("Current Conditions in " + locName);
				var row = '<tr>';
					row += '<td>' + icon + descript + '</td>';
					row += '<td>Temperature: ' + temp + ' F<br />Humidity: '  + humidity + '%<br />Wind: ' + wind + ' miles/hour</td>';
					row += '</tr>';
					
				contentRows.html(row);
				
			},
			error: function() {
				$('#errorMessages')
					.append($('<li>')
					.attr({class: 'list-group-item list-group-item-danger'})
					.text('Error calling web service.  Please try again later.'));
			
			}
		});
		
		$.ajax({
			type: 'GET',
			url:'http://api.openweathermap.org/data/2.5/forecast/daily?zip=' + zip + ',us&units=' + units + '&cnt=5&appid=fbddcf43684bc1e6b00290e4d4bb3c61',
			success: function(weatherArray) {			
				
				var fiveDayRow = $('#fiveDayRow');
				$.each(weatherArray, function(index) {
					var locName = (this).city.name;
					var date = (this).list[index].dt
					var descript = (this).list[index].weather[0].main;
					var hiTemp = (this).list[index].temp.max;
					var loTemp = (this).list[index].temp.min;					
					var iconfile = (this).list[index].weather[0].icon;
					var icon = '<img src="http://openweathermap.org/img/w/' + iconfile + '.png"/>';
					
					var formatDate = dateFormat(date);
					
					var row = '<td>';
						row += formatDate + '<br />';
						row += icon + descript + '<br />';
						row += 'H ' + hiTemp + ' F L '  + loTemp + ' F';
						row += '</td>';
						
					contentRows.html(row);
				});
			},
			error: function() {
				$('#errorMessages')
					.append($('<li>')
					.attr({class: 'list-group-item list-group-item-danger'})
					.text('Error calling web service.  Please try again later.'));
			
			}
		});
	});
	
	
});
function dateFormat(date) {
	new Date(date), "dd mmm";
}

function loadWeather() {
	clearContactTable();
	var zip = $('#zipcode-field');
	
	
	$.ajax({
		type: 'GET',
		url: 'http://api.openweathermap.org/data/2.5/weather?zip=' + zip + ',us&appid=fbddcf43684bc1e6b00290e4d4bb3c61',
		success: function(weatherArray) {
			$.each(weatherArray, function() {
				var locName = weatherArray.name;
				var descript = weatherArray.weather[0].main;
				var temp = weatherArray.main.temp;
				
				var row = '<tr>';
					row += '<td>' + locName + '</td>';
					row += '<td>' + temp + '</td>';
					row += '<td>' + descript + '</td>';

					
					row += '</tr>';
					
				contentRows.append(row);
			});
		},
		error: function() {
			$('#errorMessages')
				.append($('<li>')
				.attr({class: 'list-group-item list-group-item-danger'})
				.text('Error calling web service.  Please try again later.'));
		}
	});
}

function clearContactTable() {
	$('#contentRows').empty();
}

function showEditForm(contactId) {
	$('#errorMessages').empty();
	
	$.ajax({
		type: 'GET',
		url: 'http://localhost:8080/contact/' + contactId,
		success: function(data, status) {
			$('#edit-first-name').val(data.firstName);
			$('#edit-last-name').val(data.lastName);
			$('#edit-company').val(data.company);
			$('#edit-phone').val(data.phone);
			$('#edit-email').val(data.email);
			$('#edit-contact-id').val(data.contactId);			
		},
		error: function() {
			$('#errorMessages')
				.append($('<li>')
				.attr({class: 'list-group-item list-group-item-danger'})
				.text('Error calling web service.  Please try again later.'));
		}
	})
	
	$('#contactTableDiv').hide();
	$('#editFormDiv').show();
}

function hideEditForm() {
	$('#errorMessages').empty();
	
	$('#edit-first-name').val('');
	$('#edit-last-name').val('');
	$('#edit-company').val('');
	$('#edit-phone').val('');
	$('#edit-email').val('');
	
	$('#editFormDiv').hide();
	$('#contactTableDiv').show();
}

function deleteContact(contactId) {
	$.ajax({
		type: 'DELETE',
		url: 'http://localhost:8080/contact/' + contactId,
		success: function() {
			loadContacts();
		}
	});
}

function checkAndDisplayValidationErrors(input) {
	$('#errorMessages').empty();
	
	var errorMessages = [];
	
	input.each(function() {
		if(!this.validity.valid) {
			var errorField = $('label[for=' + this.id + ']').text();
			errorMessages.push(errorField + ' ' + this.validationMessage);
		}
	});
	
	if(errorMessages.length > 0) {
		$.each(errorMessages, function(index, message){
			$('#errorMessages').append($('<li>').attr({class: 'list-group-item list-group-item-danger'}).text(message));
		});
	
		return true;
	} else {
		return false;
	}
}