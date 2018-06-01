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

    var textinput = $("#chat-text");
    var messages = $("#chat-messages");

    connection.on("Received", (user, date, message) => {
        messages.append('<div class="chat-message row"><div class="col-md-4 col-xs-12"><p>' + message + '</p></div></div>');
        messages.scrollTop(messages.prop("scrollHeight"));
    });

    var send = function () {
        var text = textinput.val();
        connection.invoke("send", username, text);
        messages.append('<div class="chat-message row right"><div class="col-md-4 offset-8 col-xs-12"><p>' + text + '</p></div></div>');
        messages.scrollTop(messages.prop("scrollHeight"));
        textinput.val('');
    }

    $("#chat-send-button").click(send);

    $("#chat-text").keyup(e => {
        if (e.keyCode == 13) send();
    });
}