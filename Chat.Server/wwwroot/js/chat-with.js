window.onload = function () {

    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/chathub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.start()
        .catch(err => console.error(err.toString()))
        .then(() => subscribe(connection));

}

function subscribe(connection) {

    connection.on("Received", (user, date, message) => {
        $("#chat-messages ").append('<div class="chat-message row"><div class="col-md-4 col-xs-12"><p>' + message + '</p></div></div>');
    });

    var send = function () {
        var text = $("#chat-text").val();
        connection.invoke("send", username, text);
        $("#chat-messages ").append('<div class="chat-message row right"><div class="col-md-4 offset-8 col-xs-12"><p>' + text + '</p></div></div>');
    }

    $("#chat-send-button").click(send);

    $("#chat-text").keyup(e => {
        if (e.keyCode == 13) send();
    });
}