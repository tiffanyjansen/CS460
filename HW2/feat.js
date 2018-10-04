function error(){
    var node = document.getElementById("error");
    var heading = document.createElement("h2");
    var message = document.createTextNode("ERROR! Input received was not a polynomial. Please try again.");
    node.style.background = "red";
    node.style.color = "white";
    node.style.padding = "10px";
    heading.appendChild(message);
    node.appendChild(heading);
}
function enter(){
    var words = document.getElementById("function").value;
    document.getElementById("function").value = "";
    console.log(words);
    if(check(words) == false){
        error();
    }
    else{
        matched(words);
    }
}
function check(s){
    var reg = /\d+x?\^?\d*(\+|\-)?/g;
    var found = reg.test(s);
    console.log(found);
    return found;
}
function matched(fx){
    document.getElementById("text").remove();
    document.getElementById("text2").remove();
    document.getElementById("func").remove();
    document.getElementById("error").remove();
    document.getElementById("note").remove();
    console.log(fx);
    var integral = findIntType(fx);
    var firstDer = findDerType(fx);
    var secondDer = findDerType(firstDer);
    if(firstDer === 0){
        fx = parseFunc(fx);
    }
    createTable(integral, fx, firstDer, secondDer);
}
function findPieces(fx){
    var splitReg = /(\+|\-)/;
    var func = fx.split(splitReg).map(String);
    console.log(func[0]);
    console.log("func = " + func);
    for(var i = 0; i<func.length; i++){
        var poly = /\d+x\^d+/;
        var spot = "" + func[i];
        console.log("spot = " + spot);
        console.log(poly);
        console.log(poly.test(spot));        
        if(poly.test(spot) == true){
            console.log("We found a match!");
            var coefficient = /\d+x/;
            var exponent = /\^d+/;
            var coef = spot.match(coefficient).map(String);
            var expo = spot.match(exponent).map(String);
        }
        console.log("expo = " + expo);
        console.log("coef = " + coef);
        var integral = findInt(coef, expo, func);
    }
}
function findInt(coef, expo, func){
    return 0;
}
function findIntType(fx){
    var reg = /x+/g;
    if(reg.test(fx)==true){
        findPieces(fx);
    }
    else{
        var numReg = /\d+/;
        var found = fx.match(numReg);
        if(found == 0){
            console.log(found);
            return found;
        }
        console.log(found + 'x');
        return found + 'x';
    }
}
function findDerType(fx){
    var reg = /x+/g;    
    if(reg.test(fx)==true){
        //JUST NEED TO DO THIS PART!!
    }
    else{
        console.log(0);
        return 0;
    }
}
function createTable(int, fx, firDer, secDer){
    var data =[{
        Integral: int,
        Function: fx,
        FirstDer: firDer,
        SecondDer: secDer
      }]
    var columnHead = ["Integral F(x)", "Function f(x)", "First Derivative f'(x)", "Second Derivative f''(x)"];
    var columnHeadings = Object.keys(data[0]);
    var columnCount = columnHeadings.length;
    var rowCount = data.length;
    var table = $('<table>').appendTo('#output');
    var header = $('<thead />').appendTo(table);
    for (var i = 0; i < columnCount; i++) {
        $('<th />', { text: columnHead[i] }).appendTo(header);
    }
    var tBody = $('<tbody />').appendTo(table);
    //get row set up right.
    // Add the data rows to the table body.
    for (var i = 0; i < rowCount; i++) { // each row
        var row = $('<tr />').appendTo(tBody);
        for (var j = 0; j < columnCount; j++) { // each column
            var obj = data[i];
            $('<td />', {
                text: obj[columnHeadings[j]]
            }).attr('data-label', columnHeadings[j].toUpperCase()).appendTo(row);
        }
    }
    document.getElementById("output").style.visibility = "visible";
    document.getElementById("Title").style.background = "lightgreen";
}
function parseFunc(func){
    var numReg = /\d+/;
    var found = func.match(numReg);
    return found;
}