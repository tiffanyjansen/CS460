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
    var regs = /\d+x?\^?\d*(\+|\-)?/g
    var found = regs.test(s);
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
}