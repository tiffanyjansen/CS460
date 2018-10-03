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
    var integral = findInt(fx);
    var firstDer = findDer(fx);
    var secondDer = findDer(firstDer);
    createTable(integral, fx, firstDer, secondDer);
}
function findInt(fx){
    var reg = /x+/g;
    if(reg.test(fx)==true){

    }
    else{
        var numReg = /\d+/;
        var found = fx.match(numReg);
        console.log(found + 'x');
        return found + 'x';
    }
}
function findDer(fx){
    var reg = /x+/g;    
    if(reg.test(fx)==true){

    }
    else{
        console.log(0);
        return 0;
    }
}
function createTable(int, fx, firDer, secDer){
    var data = [int, fx, firDer, secDer];
    var columnHeadings = ["Integral F(x)", "Function f(x)", "First Derivative f'(x)", "Second Derivative f''(x)"];
    var columnCount = columnHeadings.length;
    var rowCount = data.length;
    var table = $('<table>').appendTo('#output');
    var header = $('<thead />').appendTo(table);
    for (var i = 0; i < columnCount; i++) {
        $('<th />', { text: columnHeadings[i] }).appendTo(header);
    }
    var tBody = $('<tbody />').appendTo(table);
    //get row set up right.
    document.getElementById("output").style.visibility = "visible";
    document.getElementById("Title").style.background = "lightgreen";
}
