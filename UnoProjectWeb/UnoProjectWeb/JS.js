var myJSON_Object;

var xmlHttp;

var GuID;

var xmlHttp_OneTime;
var xmlHttp_Process;

var turn;

var flag;

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
        GuID = xmlHttp_OneTime.responseText;
        load();
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


    var myNode = document.getElementById("opponent");
    while (myNode.firstChild) {
        myNode.removeChild(myNode.firstChild);
    }



    if (myJSON_Object[0].clientGuid == GuID)
    {
        
        document.getElementById('ctl00_ContentPlaceHolder1_labelWelcome').style.visibility = 'hidden';
        turn = myJSON_Object[0].turn.toString();

        if (turn == GuID)
            document.getElementById('ctl00_ContentPlaceHolder1_label1').innerHTML = 'My turn';
        else
            document.getElementById('ctl00_ContentPlaceHolder1_label1').innerHTML = 'His turn';

        var numOfCards = myJSON_Object[0].numOfCards.toString();
        var opponentCards = myJSON_Object[0].oponnentCards.toString();
        var packOfCards = myJSON_Object[0].packOfCards.toString();

        if (numOfCards == 0 || opponentCards == 0 || packOfCards==0)
        {
            if (packOfCards == 0)
            {
                if (numOfCards >= opponentCards)
                    window.alert("You won");
                else
                    window.alert("You lost");
            }
            else if (numOfCards==0)
                window.alert("You won");
            else
                window.alert("You lost");

            var myNode = document.getElementById("opponent");
            while (myNode.firstChild) {
                myNode.removeChild(myNode.firstChild);
            }

            var myNode = document.getElementById("cards");
            while (myNode.firstChild) {
                myNode.removeChild(myNode.firstChild);
            }

            var myNode = document.getElementById("middlecards");
            while (myNode.firstChild) {
                myNode.removeChild(myNode.firstChild);
            }

            var url = "Handler.ashx?cmd=load&endgame=true&guid=" + GuID;
            Endgame = false;
            xmlHttp.open("POST", url, true);
            xmlHttp.onreadystatechange = load2;
            xmlHttp.send();
            return;
        }

        var left = 25;
        var j = 0;
        for (var i = 0; i < numOfCards; i++,j++) {

            var number = myJSON_Object[0].cards[i].number;
            var color = myJSON_Object[0].cards[i].color;
            if (document.getElementById(number.toString() + ":" + color.toString()) == null)
            {
                var myButton = document.createElement('input');
                myButton.type = 'button';
                myButton.style.width = '90px';
                myButton.style.height = '120px ';
                myButton.style.fontSize = 'XX-Large';
                myButton.style.position = 'relative';
                myButton.value = number;
                myButton.style.backgroundColor = color;
                myButton.id = number.toString() + ":" + color.toString();
                myButton.onclick = function () { myClick(this); return false; };
                cards.appendChild(myButton);
                left += 5;
            }
        }
        left = 25;
        for (var i = 0; i < opponentCards; i++,j++) {
            var myButton = document.createElement('input');
            myButton.type = 'button';
            myButton.style.width = '90px';
            myButton.style.height = '120px ';
            myButton.style.fontSize = 'XX-Large';
            myButton.style.backgroundSize = 'cover';
            myButton.style.backgroundImage = 'url(Images/back.png)';
            opponent.appendChild(myButton);
        }
        
    }
    else if (myJSON_Object[1].clientGuid == GuID) {
        document.getElementById('ctl00_ContentPlaceHolder1_labelWelcome').style.visibility = 'hidden';
        turn = myJSON_Object[1].turn.toString();


        if (turn == GuID)
            document.getElementById('ctl00_ContentPlaceHolder1_label1').innerHTML = 'My turn';
        else
            document.getElementById('ctl00_ContentPlaceHolder1_label1').innerHTML = 'His turn';

        var numOfCards = myJSON_Object[1].numOfCards.toString();
        var opponentCards = myJSON_Object[1].oponnentCards.toString();


        if (numOfCards == 0 || opponentCards == 0 || packOfCards == 0) {
            if (packOfCards == 0) {
                if (numOfCards >= opponentCards)
                    window.alert("You won");
                else
                    window.alert("You lost");
            }
            else if (numOfCards == 0)
                window.alert("You won");
            else
                window.alert("You lost");

            var myNode = document.getElementById("opponent");
            while (myNode.firstChild) {
                myNode.removeChild(myNode.firstChild);
            }

            var myNode = document.getElementById("cards");
            while (myNode.firstChild) {
                myNode.removeChild(myNode.firstChild);
            }

            var myNode = document.getElementById("middlecards");
            while (myNode.firstChild) {
                myNode.removeChild(myNode.firstChild);
            }

            var url = "Handler.ashx?cmd=load&endgame=true&guid=" + GuID;
            Endgame = false;
            xmlHttp.open("POST", url, true);
            xmlHttp.onreadystatechange = load2;
            xmlHttp.send();
            return;
        }

        var j = 0;
        for (var i = 0; i < numOfCards; i++, j++) {

            var number = myJSON_Object[1].cards[i].number;
            var color = myJSON_Object[1].cards[i].color;

            if (document.getElementById(number.toString() + ":" + color.toString()) == null) {
                var myButton = document.createElement('input');

                myButton.type = 'button';
                myButton.style.width = '90px';
                myButton.style.height = '120px ';
                myButton.style.fontSize = 'XX-Large';
                myButton.style.position = 'relative';
                myButton.value = number;
                myButton.style.backgroundColor = color;
                myButton.id = number.toString() + ":" + color.toString();
                myButton.onclick = function () { myClick(this); return false; };
                cards.appendChild(myButton);
            }

        }
        for (var i = 0; i < opponentCards; i++) {
            var myButton = document.createElement('input');
            myButton.type = 'button';
            myButton.style.width = '90px';
            myButton.style.height = '120px ';
            myButton.style.fontSize = 'XX-Large';
            myButton.style.backgroundSize = 'cover';
            myButton.style.backgroundImage = 'url(Images/back.png)';
            opponent.appendChild(myButton);
            left += 2;
        }


    }
    else {
        var myNode = document.getElementById("opponent");
        while (myNode.firstChild) {
            myNode.removeChild(myNode.firstChild);
        }

        var myNode = document.getElementById("cards");
        while (myNode.firstChild) {
            myNode.removeChild(myNode.firstChild);
        }

        var myNode = document.getElementById("middlecards");
        while (myNode.firstChild) {
            myNode.removeChild(myNode.firstChild);
        }
        document.getElementById('ctl00_ContentPlaceHolder1_labelWelcome').style.visibility = 'hidden';
        turn = myJSON_Object[1].turn.toString();
        document.getElementById('ctl00_ContentPlaceHolder1_label1').innerHTML = 'View mode';

        var numOfCards = myJSON_Object[1].numOfCards.toString();
        var j = 0;
        for (var i = 0; i < numOfCards; i++, j++) {

            var number = myJSON_Object[1].cards[i].number;
            var color = myJSON_Object[1].cards[i].color;

            if (document.getElementById(number.toString() + ":" + color.toString()) == null) {
                var myButton = document.createElement('input');

                myButton.type = 'button';
                myButton.style.width = '90px';
                myButton.style.height = '120px ';
                myButton.style.fontSize = 'XX-Large';
                myButton.value = number;
                myButton.style.backgroundColor = color;
                myButton.style.animationName = move;
                myButton.style.animationDuration = '3s';
                myButton.id = number.toString() + ":" + color.toString();
                myButton.onclick = function () { myClick(this); };
                cards.appendChild(myButton);
            }

        }
        numOfCards = myJSON_Object[0].numOfCards.toString();
        for (var i = 0; i < numOfCards; i++) {

            var number = myJSON_Object[0].cards[i].number;
            var color = myJSON_Object[0].cards[i].color;
            if (document.getElementById(number.toString() + ":" + color.toString()) == null) {
                var myButton = document.createElement('input');
                myButton.type = 'button';
                myButton.style.width = '90px';
                myButton.style.height = '120px ';
                myButton.style.fontSize = 'XX-Large';
                myButton.value = number;
                myButton.style.backgroundColor = color;
                myButton.id = number.toString() + ":" + color.toString();
                myButton.onclick = function () { myClick(this); };
                opponent.appendChild(myButton);
            }
        }
    }
   

    var packOfCards = document.getElementById('packOfCards');
    if (packOfCards == null)
    {
        packOfCards = document.createElement('input');
        packOfCards.type = 'button';
        packOfCards.style.width = '90px';
        packOfCards.style.height = '120px ';
        packOfCards.style.fontSize = 'XX-Large';
        packOfCards.style.backgroundSize = 'cover';
        packOfCards.style.position = 'absolute';
        packOfCards.style.top = '400px';
        packOfCards.style.left = '400px';
        packOfCards.style.backgroundImage = 'url(Images/back.png)';
        packOfCards.id = 'packOfCards';
        packOfCards.onclick = function () { AddCard(this); };
        middlecards.appendChild(packOfCards);
    }
        
        var number = myJSON_Object[0].lastCard.number;
        var color = myJSON_Object[0].lastCard.color;

        var lastCard = document.getElementById("lastcard");
        if (lastCard == null)
        {
            lastCard = document.createElement('input');
            lastCard.type = 'button';
            lastCard.style.width = '90px';
            lastCard.style.height = '120px ';
            lastCard.style.fontSize = 'XX-Large';
            lastCard.style.padding = '5px';
            lastCard.id = 'lastcard';
            middlecards.appendChild(lastCard);
        }

            lastCard.value = number;
            lastCard.style.backgroundColor = color;
            


    
}

function myClick(myButton) {
    if (turn==GuID)
    {
        var lastCard = document.getElementById("lastcard");
        if (lastCard.value == myButton.value || lastCard.style.backgroundColor == myButton.style.backgroundColor) {
            myButton.className = 'PlayerCards';
            setTimeout(function () {
                var url = "Handler.ashx?cmd=move&guid=" + GuID + "&ID=" + myButton.id;
                xmlHttp.open("POST", url, true);
                xmlHttp.onreadystatechange = load2;
                xmlHttp.send();
                cards.removeChild(myButton);
            }, 1050);
            

        }
    }
}

function AddCard(myButton) {
    if (turn==GuID)
    {
        var packOfCards = document.getElementById('packOfCards');
        packOfCards.className = 'PlayCard';

        setTimeout(function () {
            var url = "Handler.ashx?cmd=addCard&guid=" + GuID;
            xmlHttp.open("POST", url, true);
            xmlHttp.onreadystatechange = load2;
            xmlHttp.send();
            packOfCards.className = "";
        }, 1050);
       
        

    }
}


function remove(myButton) {
    cards.removeChild(myButton);
}

function move2(a, myButton) {


    if (a == 0) {
        var url = "Handler.ashx?cmd=move&guid=" + GuID + "&ID=" + myButton.id;
        xmlHttp.open("POST", url, true);
        xmlHttp.onreadystatechange = load2;
        xmlHttp.send();
        cards.removeChild(myButton);
    }


    myButton.style.pixelTop += 100;

    window.setTimeout('move2(' + (a - 1).toString() + ',' + myButton + ')', 10);
}




window.onload = onLoadJavaScript;
window.onunload = myUnLoad;