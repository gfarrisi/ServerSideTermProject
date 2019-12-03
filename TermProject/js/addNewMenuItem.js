
function chgControlType() {

    var optionContainer = document.getElementById("option-container");
    var controlType = document.getElementById("control-type").value;
    if (controlType == "Dropdown" || controlType == "RadioButton") {
        optionContainer.classList.add("d-block");
        optionContainer.classList.remove("d-none");
    }
    else {
        optionContainer.classList.remove("d-block");
        optionContainer.classList.add("d-none");
    }
}
var optionNumber = 2;


function addOption() {

    var optionDiv = document.getElementById("options");

    var optionPlaceholder = "Option " + optionNumber;
    var div = document.createElement("div");
    div.id = optionPlaceholder;

    var input = document.createElement('input');
    input.type = "text";
    input.classList.add("form-control");
    input.classList.add("mb-2");
    input.classList.add("input-option");
    input.placeholder = optionPlaceholder;
    input.name = optionPlaceholder;
    input.id = optionNumber;
    input.required = true;
    input.addEventListener("change", addOptionsToSession);
    div.appendChild(input);


    var iconDelete = document.createElement('i');
    iconDelete.classList.add("fa");
    iconDelete.classList.add("fa-times");
    iconDelete.classList.add("x-icon");
    iconDelete.setAttribute('aria-hidden', 'true');
    iconDelete.id = optionNumber;
    //iconDelete.addEventListener("click", removeOption(iconDelete.id));
    iconDelete.onclick = removeOption;
    div.appendChild(iconDelete);

    optionDiv.appendChild(div);

    optionNumber = optionNumber + 1;
    input.focus();

    resetOptionNumber();
    //addOptionsToSession();
}

function removeOption(clicked) {
    var optionPlaceholder = "Option " + this.id;
    var optionRemove = document.getElementById(optionPlaceholder);
    optionRemove.parentNode.removeChild(optionRemove);
    resetOptionNumber();
}

function resetOptionNumber() {

    var optionDiv = document.getElementById("options");
    var optionDiv = document.getElementById('options').getElementsByTagName('div');

    for (i = 0; i < optionDiv.length; i++) {

        var optionPlaceholder = "Option " + (i + 1);
        var childDiv = optionDiv[i];
        var input = document.getElementById(childDiv.id).firstElementChild;
        var icon = document.getElementById(childDiv.id).lastElementChild;
        input.placeholder = optionPlaceholder;
        icon.id = i + 1;
        childDiv.id = optionPlaceholder;
    }

}

function addOptionsToSession() {
    // alert("Added!");
    var optionDiv = document.getElementById("options");
    var optionDiv = document.getElementById('options').getElementsByTagName('div');

    var options = [];

    for (i = 0; i < optionDiv.length; i++) {

        var optionPlaceholder = "Option " + (i + 1);
        var childDiv = optionDiv[i];
        var input = document.getElementById(childDiv.id).firstElementChild;
        var inputText = input.value;
        options.push(inputText);
    }
    $(document).ready(function () {
        // all custom jQuery will go here
        if ($.cookie('token') == null) {
            var json = JSON.stringify(options);
            console.log(json);
            $.cookie('optioncookie', json);
        } else {
            var json = JSON.stringify(options);
            console.log(json);
            $.cookie('optioncookie', json);
        }
        var cookie = JSON.parse($.cookie("optioncookie"));
        console.log(cookie);
    });


}


//document.getElementById("btnAdd").addEventListener("click", addOptionsToSession);

function clearModal() {

}
