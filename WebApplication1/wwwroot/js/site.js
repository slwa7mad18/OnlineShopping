//var connection = new signalR.HubConnectionBuilder()
//    .withUrl("/reviewHub") // Provide the URL to your hub
//    .configureLogging(signalR.LogLevel.Information) // Optionally, configure logging
//    .build();


//connection.on("ReceiveMessage", function (fromUser, message)
//{
//    var msg = fromUser + ": " + message;
//    var li = document.createElement("li");
//    li.textContent = msg;
//    $("#list").prepend(li);




//    connection.start();


//    $("#btbSend").on("click", function () {
//        var formUser = $("#txtUser").val();
//        var message = $("#txtMessage").val();

//        connection.invoke("SendMessage", fromUser, message);
//    }
//}