$("#words").keypress(function (e) {
    var word = $("#words").value;
    console.log(word);

    if (e.keyCode == 0 || e.keyCode == 32)
    {
        console.log("space");
    }
});

