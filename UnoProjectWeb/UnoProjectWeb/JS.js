var myJSON_Object;

var xmlHttp;
var xmlHttp2;
var xmlHttp3;

var GuID;


var User = "";


var xmlHttp_OneTime;
var xmlHttp_Process;

var xmlHttp_OneTime2;
var xmlHttp_Process2;

var turn;

var flag;

var Endgame = false;

function load() {
    document.getElementById("ctl00_ContentPlaceHolder1_ButtonHistory").style.visibility = 'hidden';
    document.getElementById("ctl00_ContentPlaceHolder1_ButtonScoreboard").style.visibility = 'hidden';
    User = document.getElementById("ctl00_ContentPlaceHolder1_User").value;
    document.getElementById("ctl00_LabelWelcome").innerHTML = "Welcome " + User + " to Uno game";
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


    try 
    {
        if (myJSON_Object[0].clientGuid == GuID)
        {
            if (document.getElementById("ctl00_ContentPlaceHolder1_ButtonHistory").style.visibility == 'hidden') {
                document.getElementById("ctl00_ContentPlaceHolder1_ButtonHistory").style.visibility = 'visible';
                document.getElementById("ctl00_ContentPlaceHolder1_ButtonScoreboard").style.visibility = 'visible';
            }
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
                var imageName = "";
                switch (color)
                {
                    case "Red":
                        imageName = number + "r";
                        break;
                    case "Blue":
                        imageName = number + "b";
                        break;
                    case "Yellow":
                        imageName = number + "y";
                        break;
                    case "Green":
                        imageName = number + "g";
                        break;
                }
                if (document.getElementById(number.toString() + ":" + color.toString()) == null)
                {
                    var myButton = document.createElement('input');
                    myButton.type = 'button';
                    myButton.style.width = '90px';
                    myButton.style.height = '130px ';
                    myButton.style.fontSize = 'XX-Large';
                    myButton.style.position = 'relative';
                    myButton.textContent = number;
                    myButton.style.backgroundColor = color;
                    myButton.style.backgroundSize = 'cover';
                    myButton.style.backgroundImage = 'url(Images/'+imageName+'.png)';
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
                myButton.style.height = '130px ';
                myButton.style.fontSize = 'XX-Large';
                myButton.style.backgroundSize = 'cover';
                myButton.style.backgroundImage = 'url(Images/back.png)';
                opponent.appendChild(myButton);
            }
        
        }
        else if (myJSON_Object[1].clientGuid == GuID) {
            if (document.getElementById("ctl00_ContentPlaceHolder1_ButtonHistory").style.visibility == 'hidden') {
                document.getElementById("ctl00_ContentPlaceHolder1_ButtonHistory").style.visibility = 'visible';
                document.getElementById("ctl00_ContentPlaceHolder1_ButtonScoreboard").style.visibility = 'visible';
            }
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
                var imageName = "";
                switch (color) {
                    case "Red":
                        imageName = number + "r";
                        break;
                    case "Blue":
                        imageName = number + "b";
                        break;
                    case "Yellow":
                        imageName = number + "y";
                        break;
                    case "Green":
                        imageName = number + "g";
                        break;
                }
                if (document.getElementById(number.toString() + ":" + color.toString()) == null) {
                    var myButton = document.createElement('input');

                    myButton.type = 'button';
                    myButton.style.width = '90px';
                    myButton.style.height = '130px ';
                    myButton.style.fontSize = 'XX-Large';
                    myButton.style.position = 'relative';
                    myButton.textContent = number;
                    myButton.style.backgroundColor = color;
                    myButton.style.backgroundSize = 'cover';
                    myButton.style.backgroundImage = 'url(Images/' + imageName + '.png)';
                    myButton.id = number.toString() + ":" + color.toString();
                    myButton.onclick = function () { myClick(this); return false; };
                    cards.appendChild(myButton);
                }

            }
            for (var i = 0; i < opponentCards; i++) {
                var myButton = document.createElement('input');
                myButton.type = 'button';
                myButton.style.width = '90px';
                myButton.style.height = '130px ';
                myButton.style.fontSize = 'XX-Large';
                myButton.style.backgroundSize = 'cover';
                myButton.style.backgroundImage = 'url(Images/back.png)';
                opponent.appendChild(myButton);
                left += 2;
            }


        }
        else {
            if (document.getElementById("ctl00_ContentPlaceHolder1_ButtonHistory").style.visibility == 'hidden')
            {
                document.getElementById("ctl00_ContentPlaceHolder1_ButtonHistory").style.visibility = 'visible';
                document.getElementById("ctl00_ContentPlaceHolder1_ButtonScoreboard").style.visibility = 'visible';
            }
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
                var imageName = "";
                switch (color) {
                    case "Red":
                        imageName = number + "r";
                        break;
                    case "Blue":
                        imageName = number + "b";
                        break;
                    case "Yellow":
                        imageName = number + "y";
                        break;
                    case "Green":
                        imageName = number + "g";
                        break;
                }
                if (document.getElementById(number.toString() + ":" + color.toString()) == null) {
                    var myButton = document.createElement('input');

                    myButton.type = 'button';
                    myButton.style.width = '90px';
                    myButton.style.height = '130px ';
                    myButton.style.fontSize = 'XX-Large';
                    myButton.textContent = number;
                    myButton.style.backgroundColor = color;
                    myButton.style.backgroundSize = 'cover';
                    myButton.style.backgroundImage = 'url(Images/' + imageName + '.png)';
                    myButton.id = number.toString() + ":" + color.toString();
                    myButton.onclick = function () { myClick(this); };
                    cards.appendChild(myButton);
                }

            }
            numOfCards = myJSON_Object[0].numOfCards.toString();
            for (var i = 0; i < numOfCards; i++) {

                var number = myJSON_Object[0].cards[i].number;
                var color = myJSON_Object[0].cards[i].color;
                var imageName = "";
                switch (color) {
                    case "Red":
                        imageName = number + "r";
                        break;
                    case "Blue":
                        imageName = number + "b";
                        break;
                    case "Yellow":
                        imageName = number + "y";
                        break;
                    case "Green":
                        imageName = number + "g";
                        break;
                }
                if (document.getElementById(number.toString() + ":" + color.toString()) == null) {
                    var myButton = document.createElement('input');
                    myButton.type = 'button';
                    myButton.style.width = '90px';
                    myButton.style.height = '130px ';
                    myButton.style.fontSize = 'XX-Large';
                    myButton.textContent = number;
                    myButton.style.backgroundColor = color;
                    myButton.style.backgroundSize = 'cover';
                    myButton.style.backgroundImage = 'url(Images/' + imageName + '.png)';
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
            packOfCards.style.height = '130px ';
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
        var imageName = "";
        switch (myJSON_Object[0].lastCard.color) {
            case "Red":
                imageName = number + "r";
                break;
            case "Blue":
                imageName = number + "b";
                break;
            case "Yellow":
                imageName = number + "y";
                break;
            case "Green":
                imageName = number + "g";
                break;
        }

        var lastCard = document.getElementById("lastcard");
        if (lastCard == null)
        {
            lastCard = document.createElement('input');
            lastCard.type = 'button';
            lastCard.style.width = '90px';
            lastCard.style.height = '130px ';
            lastCard.style.fontSize = 'XX-Large';
            lastCard.style.padding = '5px';
            lastCard.id = 'lastcard';
            middlecards.appendChild(lastCard);
        }
        lastCard.style.backgroundSize = 'cover';
        lastCard.style.backgroundImage = 'url(Images/' + imageName + '.png)';
        lastCard.textContent = number;
        lastCard.style.backgroundColor = color;
    }
    catch (e) {}
            


    
}

function myClick(myButton) {
    if (turn==GuID)
    {
        var lastCard = document.getElementById("lastcard");
        if (lastCard.textContent == myButton.textContent || lastCard.style.backgroundColor == myButton.style.backgroundColor) {
            myButton.className = 'PlayerCards';
            setTimeout(function () {
                var url = "Handler.ashx?cmd=move&guid=" + GuID + "&ID=" + myButton.id + "&user=" + User;
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
            var url = "Handler.ashx?cmd=addCard&guid=" + GuID + "&user=" + User;
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

function GetHistory() {
    try {
        xmlHttp2 = new ActiveXObject("Microsoft.XMLHTTP");

        xmlHttp_OneTime2 = new ActiveXObject("Microsoft.XMLHTTP");
        xmlHttp_Process2 = new ActiveXObject("Microsoft.XMLHTTP");
    }
    catch (e) {
        try {
            xmlHttp2 = new XMLHttpRequest();

            xmlHttp_OneTime2 = new XMLHttpRequest()
            xmlHttp_Process2 = new XMLHttpRequest()
        }
        catch (e) {
        }
    }
    if (document.getElementById("ctl00_ContentPlaceHolder1_ButtonHistory").value == "Show History")
    {
        document.getElementById("ctl00_ContentPlaceHolder1_ButtonHistory").value = "Hide History";
        document.getElementById("ctl00_ContentPlaceHolder1_ButtonScoreboard").value = "Show Scoreboard";
    }
    else
    {
        document.getElementById("ctl00_ContentPlaceHolder1_ButtonHistory").value = "Show History";
    }
    
    var myTable = document.getElementById("ctl00_ContentPlaceHolder1_TableMoveHistory");
    var rowCount = myTable.rows.length;
    if (rowCount > 0)
    {
        myTable.style.border = "hidden";
        while (myTable.hasChildNodes()) {
            myTable.removeChild(myTable.firstChild);
        }
    }
    else
    {
        myTable.style.border = "solid";
        url = "Handler.ashx?cmd=History&guid=" + GuID;
        xmlHttp2.open("POST", url, true);
        xmlHttp2.onreadystatechange = GetHistoryToTable;
        xmlHttp2.send();
    }

}
function GetHistoryToTable() {
    if (xmlHttp2.readyState == 4) {
        var myJSON_Text = xmlHttp2.responseText;
        myJSON_Object = eval(myJSON_Text);
        var table = document.getElementById('ctl00_ContentPlaceHolder1_TableMoveHistory');

        // Add header to table
        headerRow = document.createElement("tr");
        HeadelCol = document.createElement("th");
        HeadelCol.innerHTML = "Move Number";
        headerRow.appendChild(HeadelCol);
        HeadelCol = document.createElement("th");
        HeadelCol.innerHTML = "Player Name";
        headerRow.appendChild(HeadelCol);
        HeadelCol = document.createElement("th");
        HeadelCol.innerHTML = "Move Type";
        headerRow.appendChild(HeadelCol);
        HeadelCol = document.createElement("th");
        HeadelCol.innerHTML = "Card Chosen";
        headerRow.appendChild(HeadelCol);
        HeadelCol = document.createElement("th");
        HeadelCol.innerHTML = "Card Received";
        headerRow.appendChild(HeadelCol);
        HeadelCol = document.createElement("th");
        HeadelCol.innerHTML = "Card On Deck";
        headerRow.appendChild(HeadelCol);
        table.appendChild(headerRow);
        for (var i = 0; i < myJSON_Object.length ; i++) {

            new_row = document.createElement("tr");
            new_col = document.createElement("td");
            new_col.innerHTML = myJSON_Object[i].moveNumber;
            new_row.appendChild(new_col);
            new_col = document.createElement("td");
            new_col.innerHTML = myJSON_Object[i].player;
            new_row.appendChild(new_col);
            new_col = document.createElement("td");
            new_col.innerHTML = myJSON_Object[i].moveType;
            new_row.appendChild(new_col);
            new_col = document.createElement("td");
            new_col.innerHTML = myJSON_Object[i].cardChosen;
            new_row.appendChild(new_col);
            new_col = document.createElement("td");
            new_col.innerHTML = myJSON_Object[i].cardReceived;
            new_row.appendChild(new_col);
            new_col = document.createElement("td");
            new_col.innerHTML = myJSON_Object[i].cardOnDeck;
            new_row.appendChild(new_col);
            table.appendChild(new_row);
        }
    }
}

function GetScoreboard() {
    try {
        xmlHttp3 = new ActiveXObject("Microsoft.XMLHTTP");
    }
    catch (e) {
        try {
            xmlHttp3 = new XMLHttpRequest();
        }
        catch (e) {
        }
    }
    if (document.getElementById("ctl00_ContentPlaceHolder1_ButtonScoreboard").value == "Show Scoreboard") {
        document.getElementById("ctl00_ContentPlaceHolder1_ButtonScoreboard").value = "Hide Scoreboard";
        document.getElementById("ctl00_ContentPlaceHolder1_ButtonHistory").value = "Show History";
    }
    else {
        document.getElementById("ctl00_ContentPlaceHolder1_ButtonScoreboard").value = "Show Scoreboard";
    }

    var myTable = document.getElementById("ctl00_ContentPlaceHolder1_TableMoveHistory");
    var rowCount = myTable.rows.length;
    if (rowCount > 0) {
        myTable.style.border = "hidden";
        while (myTable.hasChildNodes()) {
            myTable.removeChild(myTable.firstChild);
        }
    }
    else {
        myTable.style.border = "solid";
        url = "Handler.ashx?cmd=Scoreboard&guid=" + GuID;
        xmlHttp3.open("POST", url, true);
        xmlHttp3.onreadystatechange = GetScoreboardToTable;
        xmlHttp3.send();
    }

}

function GetScoreboardToTable() {
    if (xmlHttp3.readyState == 4) {
        var myJSON_Text = xmlHttp3.responseText;
        myJSON_Object = eval(myJSON_Text);
        var table = document.getElementById('ctl00_ContentPlaceHolder1_TableMoveHistory');

        // Add header to table
        headerRow = document.createElement("tr");
        HeadelCol = document.createElement("th");
        HeadelCol.innerHTML = "Player Name";
        headerRow.appendChild(HeadelCol);
        HeadelCol = document.createElement("th");
        HeadelCol.innerHTML = "Total Wins";
        headerRow.appendChild(HeadelCol);
        table.appendChild(headerRow);
        for (var i = 0; i < myJSON_Object.length ; i++) {

            new_row = document.createElement("tr");
            new_col = document.createElement("td");
            new_col.innerHTML = myJSON_Object[i].playerName;
            new_row.appendChild(new_col);
            new_col = document.createElement("td");
            new_col.innerHTML = myJSON_Object[i].totalWins;
            new_row.appendChild(new_col);
            table.appendChild(new_row);
        }
    }
}




window.onload = onLoadJavaScript;
window.onunload = myUnLoad;