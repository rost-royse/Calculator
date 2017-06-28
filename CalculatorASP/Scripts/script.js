var isFirst = true;
function calc() {
    var input = document.getElementById("inp").value;
    if (isInArray(input.substr(input.length - 1), operations)) {
        input = input.slice(0, -1);
    }
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        url: "/api/calc",
        data: JSON.stringify({
            "Input": input
        }),
        success: function(data) { document.getElementById("inp").value = data; },
        error: function() {
            document.getElementById("inp").value = "ERROR";
            isFirst = true;
        }
    });
}

function numberClick(symbol) {
    if (isFirst) {
        document.getElementById("inp").value = "";
        isFirst = false;
    }

    var input = document.getElementById("inp").value;
    if (isInArray(symbol, operations) && isInArray(input.substr(input.length - 1), operations)) {
        input = input.substring(0, input.length - 1);
    }
    input += symbol;
    document.getElementById("inp").value = input;
}

function clearInput() {
    document.getElementById("inp").value = "";
}

function isInArray(value, array) {
    return array.indexOf(value) > -1;
}

function addPM() {
    document.getElementById("inp").value = parseFloat(document.getElementById("inp").value) * -1;
}

var operations = ["+", "-", "*", "/"];