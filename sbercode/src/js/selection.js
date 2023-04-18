function reply(body, response){
    var replydata = {
        type: "raw",
        body: body
    };
    response.replies = response.replies || [];
    response.replies.push(replydata);
};

function addAction(action, context){
    var command = {
        type: "smart_app_data",
        action: action
    };
    var response = {items: [{command: command}]};
    reply(response, context.response);
}

function startGame(context){
    addAction({
        type: "startGame",
    }, context);
}

function restartGame(context){
    addAction({
        type: "restartGame",
    }, context);
}

function firstAnswer(context){
    addAction({
        type: "firstAnswer",
    }, context);
}

function secondAnswer(context){
    addAction({
        type: "secondAnswer",
    }, context);
}

function thirdAnswer(context){
    addAction({
        type: "thirdAnswer",
    }, context);
}

function fourthAnswer(context){
    addAction({
        type: "fourthAnswer",
    }, context);
}

function fifthAnswer(context){
    addAction({
        type: "fifthAnswer",
    }, context);
}

function sixthAnswer(context){
    addAction({
        type: "sixthAnswer",
    }, context);
}