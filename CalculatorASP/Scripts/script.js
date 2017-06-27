function calc() {
    $.ajax({
        type: "POST",
        dataType: 'json',
        contentType: 'application/json',
        url: '/api/calc',
        data: JSON.stringify({
            "Input": document.getElementById("inp").value,
         
        }),
        success: function (data) { document.getElementById("inp").value = data; },
        error: function () { alert("error"); }
    });
}

function numberClick(number) {
    document.getElementById("inp").value += number;
}

