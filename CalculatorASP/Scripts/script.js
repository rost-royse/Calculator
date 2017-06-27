
function calc() {
    document.getElementById("inp").value
    $.ajax({
        type: "POST",
        url: 'localhost:5000/registrar',
        data: {
            "exp": document.getElementById("inp").value,
         
        },
        success: function () { $('#register').html('<h1>Login successfull</h1>'); },
        error: function () { $('#register').html('<h1>Login error</h1>'); },
        dataType: dataType
    });
}

function numberClick(number) {
    document.getElementById("inp").value += number;
}

