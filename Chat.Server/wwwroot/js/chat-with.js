window.onload = function () {

    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/chathub")
        .build();

    connection.start()
        .catch(err => console.error(err.toString()))
        .then(() => subscribe(connection));

}

// R '<div class="chat-message row"><div class="col-md-4 col-xs-12"><p>' + message + '</p></div></div>'
// S '<div class="chat-message row right"><div class="col-md-4 offset-8 col-xs-12"><p>' + text + '</p></div></div>'
// keyup 13, messages.scrollTop(messages.prop("scrollHeight"));

function subscribe(connection) {
        
}