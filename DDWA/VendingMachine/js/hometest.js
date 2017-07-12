$(document).ready(function() {
	
	loadItems();

	$('#add-dollar').click(function (event) {
		var amountToAdd = 1;
		var total = 0;
		var display = $('#amount-display').text();

		if(display == "") {
			total += amountToAdd;
		}
		else {
			total = parseFloat(display.substr(1));
			total += amountToAdd;
		}
		var textTotal = total.toFixed(2);
		$('#amount-display').empty();
		$('#amount-display').text("$" + textTotal);
	});

	$('#add-quarter').click(function (event) {
		var amountToAdd = 0.25;
		var total = 0;
		var display = $('#amount-display').text();

		if(display == "") {
			total += amountToAdd;
		}
		else {
			total = parseFloat(display.substr(1));
			total += amountToAdd;
		}
		var textTotal = total.toFixed(2);
		$('#amount-display').empty();
		$('#amount-display').text("$" + textTotal);
	});

	$('#add-dime').click(function (event) {
		var amountToAdd = 0.10;
		var total = 0;
		var display = $('#amount-display').text();

		if(display == "") {
			total += amountToAdd;
		}
		else {
			total = parseFloat(display.substr(1));
			total += amountToAdd;
		}
		var textTotal = total.toFixed(2);
		$('#amount-display').empty();
		$('#amount-display').text("$" + textTotal);
	});

	$('#add-nickel').click(function (event) {
		var amountToAdd = 0.05;
		var total = 0;
		var display = $('#amount-display').text();

		if(display == "") {
			total += amountToAdd;
		}
		else {
			total = parseFloat(display.substr(1));
			total += amountToAdd;
		}
		var textTotal = total.toFixed(2);
		$('#amount-display').empty();
		$('#amount-display').text("$" + textTotal);
	});

	$('#make-purchase').click(function (event) {
		var item = $('#item-select').val();
		itemNum = parseInt(item);
		var amountDisplay = $('#amount-display').text();
		amountAdded = parseFloat(amountDisplay.substr(1));
		//checkItemQuantity(itemNum, amountAdded);
		checkChange(itemNum, amountAdded);
		checkAmount(itemNum, amountAdded);
	});	

	$('#change-return').click(function(event){
		$('#amount-display').text('$0.00');
		$('#item-display').text('Item #');
		$('#item-select').val('');
		$('#change-amount-display').html('<br>');
		$('#vending-items-div').empty();
		loadItems();
	})
});

// function checkItemQuantity(itemNum, amountAdded) {
// 	$.ajax({
// 		type: 'GET',
// 		url: 'http://localhost:8080/items',
// 		success: function(data) {
// 			var price = data[itemNum-1].price;
// 			var quantity = data[itemNum -1].quantity;
// 			if(quantity < 1){
// 				$('#item-display').empty();
// 				$('#item-display').text("SOLD OUT!");
// 				return false;
// 			}
// 		},
// 		error: function() {
// 			$('#errorMessages')
// 				.append($('<li>')
// 				.attr({class: 'list-group-item list-group-item-danger'})
// 				.text('Error calling web service.  Please try again later.'));
// 		}
// 	});
// }


function checkChange(itemNum, amount){
	$.ajax({
		type: 'GET',
		url: 'http://localhost:8080/money/' + amount + '/item/' + itemNum,
		success: function(data) {
			var quarters = data.quarters;
			var dimes = data.dimes;
			var nickels = data.nickels;
			var pennies = data.pennies;
			
			var totalChange = "";

			if(quarters > 0){
				if(quarters == 1){
					var quartText = quarters + " Quarter "
				}
				else{
					quartText = quarters + " Quarters "
				}
				totalChange += quartText;
			}
			else if(dimes > 0){
				var dimeText = dimes + " Dimes "
				totalChange += dimeText;
			}
			else if(nickels > 0){
				var nickText = nickels + " Nickels "
				totalChange += nickText;
			}
			else if(pennies > 0){
				var penText = pennies + " Pennies "
				totalChange += penText;
			}

			else{
				totalChange = "No change due."
			}
				$('#item-display').empty();
				$('#item-display').text("Thank you!!");
				$('#change-amount-display').text(totalChange)
		},

		error: function(data) {
			var message = data.responseJSON.message;
			$('#item-display').empty();
			$('#item-display').text(message);
		}		
	});
}

function checkAmount(itemNum, amountAdded) {
	$.ajax({
		type: 'GET',
		url: 'http://localhost:8080/items',
		success: function(data) {
			var id = data[itemNum-1].id;
			var name = data[itemNum-1].name;
			var price = data[itemNum-1].price.toFixed(2);
			var quantity = data[itemNum-1].quantity;
			

				
			data[itemNum-1].quantity -= 1;
			$('#id' + id).html(
				'<button type="button" value="'+id+'" class="btn btn-secondary">'+
				'<p style="text-align: left">'+
				id + '</p><br/>' +
				'<p>' + name + '<br/>' +
				"$" + price + '<br/>' +
				"Quantity Left: " + quantity + '</p></button>');

		},
		error: function() {
			$('#errorMessages')
				.append($('<li>')
				.attr({class: 'list-group-item list-group-item-danger'})
				.text('Error calling web service.  Please try again later.'));
		}
	});
}

function loadItems() {
	
	$.ajax({
		type: 'GET',
		url: 'http://localhost:8080/items',
		success: function(data) {
			$.each(data, function(index, data) {
				var id = data.id;
				var name = data.name;
				var price = data.price.toFixed(2);
				var quantity = data.quantity;
				var imageUrl = "images/png/" + id +".png";
				
				$('#vending-items-div').append(
					'<div id="id'+id+'" data-id="'+id+'" class="form-group col-xs-4 item">'+
					'<button type="button" value="'+id+'" style="background:url(' + imageUrl + ') no-repeat" class="btn btn-secondary">'+
					'<p style="text-align: left">'+
					id + '</p><br/>' +
					'<p>' + name + '<br/>' +
					"$" + price + '<br/>' +
					"Quantity Left: " + quantity + '</p></button></div>');		
			});

			$('.btn-secondary').click(function(event){
				var rawId = $(this.parentElement).attr("data-id");
				var id = parseInt(rawId);
				loadItem(id);		
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