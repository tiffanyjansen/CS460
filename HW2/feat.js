function error(){
    document.getElementById("error").style.visibility = "visible";
}
function enter(){
    var words = document.getElementById("function").value;
    console.log(words);
    if(match(words) == null){
        error();
    }
}
function match(s){
    var reg = /\d*x(?=\^?\+?\-?\d+){1,}/
    var found = s.match(reg);
    console.log(found);
    return found;
}