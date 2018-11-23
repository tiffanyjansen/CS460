var interval = 5000;
console.log("interval = " + interval);
window.setInterval(ajax_call, interval);

var ajax_call = function () {
    clearTable();
    var source = "/Home/Table/";
    console.log(source);
    $.ajax({
        type: "GET",
        dataType: "json",
        url: source,
        success: successAjax,
        error: errorAjax
    });
}

function successAjax(result) {
    console.log("IT WORKED");
    var json = JSON.parse(result);
    console.log(json);
    $('#Items table').append('<tbody>');
    success = true;
    i = 0;
    while (i < json.length) {
        $('#Items table').append('<tr><td>' + json[i]["ItemID"] + '</td><td>' + json[i]["ItemName"] + '</td><td>' + json[i]["BuyerName"] + '</td><td>' + json[i]["BidAmount"] + '</td><td>' + json[i]["TimeStamp"] + '</td></tr>');
        i++;
    }
    $('#Items table').append('</tbody>');
}
function errorAjax() {
    console.log("Error");
}

function createTable() {
    $('#Items').append('<table align="center" style="width: 90%;"/>');
    $('#Items table').append('<thead><tr><th>' + 'Item ID' + '</th><th>' + 'Item Name' + '</th><th>' + "Buyer" + '</th><th>' + "Bid Amount" + '</th><th>' + "Time of Bid" + '</th></tr></thead>');
}

function clearTable() {
    $('#Items table').remove();
    createTable();
}