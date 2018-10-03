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
    var tab = document.createElement("table");
    var node = document.getElementById("output");
    var head = tab.createTHead();
    var body = tab.createTBody();
    head.insertRow("F(x)", "f(x)", "f(x)", "f''(x)");
    body.insertRow(-1, int, fx, firDer, secDer);
    node.appendChild(tab);
}
