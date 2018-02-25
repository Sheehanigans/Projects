$(document).ready(function (){

    loadGoodies();
})

function loadGoodies(){

    clearGoodies();

    var goodieButtons = $('#goodieSelection')

    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/items',
        success: function(data, status){
            $.each(data, function (index, item){
                var id = item.id;
                var name = item.name;
                var price = item.price;
                var quantity = item.quantity;

                var goodie = '<button class="col-md-4 btn btn-default" onclick="getGoodie(' + id + ')">';
                    goodie += '<p>' + id + '</p>' + '<br/>';
                    goodie += '<p>' + name + '</p>' + '<br/>';
                    goodie += '<p>' + price + '</p>' + '<br/>';
                    goodie += '<p>' + quantity + '</p>' + '<br/>';
                    goodie += '</button>';

                goodieButtons.append(goodie);
            });
        },
        error: function(){
            $('#messageDisplay')
            .append($('<p>')
            .text('Error calling web service. Please try again later.'));
        }
    });
}

function clearGoodies(){
    $('#goodieSelection').empty();
}

var moneyInSystem = 0;

function addMoney(buttonId){    

    if(buttonId == 1){
        moneyInSystem += 1.00;
    }
    else if(buttonId == 2){
        moneyInSystem += 0.25;
    }
    else if(buttonId == 3){
        moneyInSystem += 0.10;
    }
    else if (buttonId == 4){
        moneyInSystem += 0.05;    
    }

    displayMoney(moneyInSystem);
}

function getGoodie(itemId){

    displayItem(itemId)

    var amountToSend = parseFloat(moneyInSystem).toFixed(2)

    var urlToSend = 'http://localhost:8080/money/'
        urlToSend += amountToSend.toString()
        urlToSend += '/item/'
        urlToSend += itemId.toString()

    $.ajax({
        type: 'GET',
        url: urlToSend,
        success: function(data, status){
            var quarters = data.quarters;
            var dimes = data.dimes;
            var nickels = data.nickels;
            var pennies = data.pennies;

            quarters *= 0.25
            dimes *= 0.10
            nickels *= 0.05
            pennies *= 0.01

            var change = quarters + dimes + nickels + pennies
            displayChange(change)
            displayMessage("Thank you!")
            loadGoodies()
            moneyInSystem = 0
            displayMoney(0)
        },
        error: function(data, status){
            var message = status.message
            alert(message)
            
            //displayMessage(message)
        }
    })
}

function displayChange(change){
    $('#displayChange')
    .empty()
    .append($('<h4>')
    .text("$" + parseFloat(change).toFixed(2)))
}

function displayMoney(amount){
    $('#moneyDisplay')
    .empty()
    .append($('<h4>')
    .text("$" + parseFloat(moneyInSystem).toFixed(2)))
}

function displayItem(itemId){
    $('#itemDisplay')
    .empty()
    .append($('<h4>')
    .text(itemId))
}

function displayMessage(message){
    $('#messageDisplay')
    .empty()
    .append($('<h4>')
    .text(message))
}