var myJSON_Object;

var xmlHttp;

var GuID;

var xmlHttp_OneTime;
var xmlHttp_Process;

var Endgame = false;

function load() {
    try {
        xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    catch (e) {
        try {
            xmlHttp = new XMLHttpRequest();
        }
        catch (e) {
        }
    }
    var url;
    if (Endgame)
        var url = "Handler.ashx?cmd=load&endgame=true&guid=" + GuID;
    else
        var url = "Handler.ashx?cmd=load&endgame=false&guid=" + GuID;
    Endgame = false;
    xmlHttp.open("POST", url, true);
    xmlHttp.onreadystatechange = load2;
     xmlHttp.send();
}

function load2() {
    if (xmlHttp.readyState == 4) {
        var myJSON_Text = xmlHttp.responseText;
        myJSON_Object = eval(myJSON_Text);
        Init();
    }
}
function onLoadJavaScript() {
    try {
        xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");

        xmlHttp_OneTime = new ActiveXObject("Microsoft.XMLHTTP");
        xmlHttp_Process = new ActiveXObject("Microsoft.XMLHTTP");
    }
    catch (e) {
        try {
            xmlHttp = new XMLHttpRequest();

            xmlHttp_OneTime = new XMLHttpRequest()
            xmlHttp_Process = new XMLHttpRequest()
        }
        catch (e) {
        }
    }

    var url = "Handler.ashx?cmd=register";
    xmlHttp_OneTime.open("POST", url, true);
    xmlHttp_OneTime.onreadystatechange = getResponse_Connect;
    xmlHttp_OneTime.send();

}

function getResponse_Connect() {
    if (xmlHttp_OneTime.readyState == 4) {
        load();
        GuID = xmlHttp_OneTime.responseText;
        ProcessFunction();

    }
}

function myUnLoad() {
    var url = "Handler.ashx?cmd=unregister&guid=" + GuID;
    xmlHttp_OneTime.open("POST", url, true);
    xmlHttp_OneTime.send();
}

function ProcessFunction() {

    var url = "Handler.ashx?cmd=process&guid=" + GuID;
    xmlHttp_Process.open("POST", url, true);
    xmlHttp_Process.onreadystatechange = getResponse_Process;
    xmlHttp_Process.send();
}

function getResponse_Process() {
    if (xmlHttp_Process.readyState == 4) {
        load();
        ProcessFunction();

    }
}

function Init() {
    if (myJSON_Object[0].clientGuid == GuID)
    {
        var numOfCards = myJSON_Object[0].numOfCards.toString();
        var opponentCards = myJSON_Object[0].numOfCards.toString();
        var left = 25;
        for (var i = 0; i < numOfCards; i++) {

            var number = myJSON_Object[0].cards[i].number;
            var color = myJSON_Object[0].cards[i].color;
            var myButton = document.createElement('input');
            myButton.type = 'button';
            myButton.style.width = '90px';
            myButton.style.height = '120px ';
            myButton.style.fontSize = 'XX-Large';
            myButton.style.position = 'absolute';
            myButton.style.top = '600px';
            myButton.style.left = left + '%';
            myButton.value = number;
            myButton.style.backgroundColor = color;
            body.appendChild(myButton);
            left += 5;
        }
        left = 25;
        for (var i = 0; i < opponentCards; i++) {

            var number = myJSON_Object[0].cards[i].number;
            var color = myJSON_Object[0].cards[i].color;
            var myButton = document.createElement('input');
            myButton.type = 'button';
            myButton.style.width = '90px';
            myButton.style.height = '120px ';
            myButton.style.fontSize = 'XX-Large';
            myButton.style.position = 'absolute';
            myButton.style.top = '130px';
            myButton.style.left = left + '%';
            myButton.style.backgroundSize = 'cover';
            myButton.style.backgroundImage = 'url(Images/back.png)';
            body.appendChild(myButton);
            left += 2;
        }

        var myButton = document.createElement('input');
        myButton.type = 'button';
        myButton.style.width = '90px';
        myButton.style.height = '120px ';
        myButton.style.fontSize = 'XX-Large';
        myButton.style.position = 'absolute';
        myButton.style.top = '350px';
        myButton.style.left = '400px';
        myButton.style.backgroundSize = 'cover';
        myButton.style.backgroundImage = 'url(Images/back.png)';
        body.appendChild(myButton);


        var number = myJSON_Object[0].lastCard.number;
        var color = myJSON_Object[0].lastCard.color;
        var myButton = document.createElement('input');
        myButton.type = 'button';
        myButton.style.width = '90px';
        myButton.style.height = '120px ';
        myButton.style.fontSize = 'XX-Large';
        myButton.style.position = 'absolute';
        myButton.style.top = '350px';
        myButton.style.left = '45%';
        myButton.value = number;
        myButton.style.backgroundColor = color;
        body.appendChild(myButton);
    }
    else
    {
        var numOfCards = myJSON_Object[1].numOfCards.toString();
        var opponentCards = myJSON_Object[1].numOfCards.toString();
        var left = 25;
        for (var i = 0; i < numOfCards; i++) {

            var number = myJSON_Object[1].cards[i].number;
            var color = myJSON_Object[1].cards[i].color;
            var myButton = document.createElement('input');
            myButton.type = 'button';
            myButton.style.width = '90px';
            myButton.style.height = '120px ';
            myButton.style.fontSize = 'XX-Large';
            myButton.style.position = 'absolute';
            myButton.style.top = '600px';
            myButton.style.left = left + '%';
            myButton.value = number;
            myButton.style.backgroundColor = color;
            body.appendChild(myButton);
            left += 5;
        }
        left = 25;
        for (var i = 0; i < opponentCards; i++) {

            var number = myJSON_Object[1].cards[i].number;
            var color = myJSON_Object[1].cards[i].color;
            var myButton = document.createElement('input');
            myButton.type = 'button';
            myButton.style.width = '90px';
            myButton.style.height = '120px ';
            myButton.style.fontSize = 'XX-Large';
            myButton.style.position = 'absolute';
            myButton.style.top = '130px';
            myButton.style.left = left + '%';
            myButton.style.backgroundSize = 'cover';
            myButton.style.backgroundImage = 'url(Images/back.png)';
            body.appendChild(myButton);
            left += 2;
        }

        var myButton = document.createElement('input');
        myButton.type = 'button';
        myButton.style.width = '90px';
        myButton.style.height = '120px ';
        myButton.style.fontSize = 'XX-Large';
        myButton.style.position = 'absolute';
        myButton.style.top = '350px';
        myButton.style.left = '400px';
        myButton.style.backgroundSize = 'cover';
        myButton.style.backgroundImage = 'url(Images/back.png)';
        body.appendChild(myButton);


        var number = myJSON_Object[1].lastCard.number;
        var color = myJSON_Object[1].lastCard.color;
        var myButton = document.createElement('input');
        myButton.type = 'button';
        myButton.style.width = '90px';
        myButton.style.height = '120px ';
        myButton.style.fontSize = 'XX-Large';
        myButton.style.position = 'absolute';
        myButton.style.top = '350px';
        myButton.style.left = '45%';
        myButton.value = number;
        myButton.style.backgroundColor = color;
        body.appendChild(myButton);
    }

    
}

function myClick(myButton) {

    var url = "Handler.ashx?cmd=Move&guid=" + GuID + "&ID=" + myButton.id;
    xmlHttp.open("POST", url, true);
    xmlHttp.send();

}

function movebutton(a, b) {
    var numOfCards = myJSON_Object[0].numOfCards.toString();
}


window.onload = onLoadJavaScript;
window.onunload = myUnLoad;