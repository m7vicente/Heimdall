document.getElementById('btnCadastrar').onpointermove(NameChanger());

function NameChanger() {

    var string = document.getElementById('txtNome').textContent;
    var array = string.split(" ");

    for (i = 0; i < array.length; i++) {
        if (!array[i].length === 2) {
            array[i] = array[i].slice(0, 1).toUpperCase() + array[i].slice(1).toLowerCase();
        }
    }

