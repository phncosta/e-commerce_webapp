
var form = document.querySelector('form');
var attacherInput = document.getElementById('attacher');

form.addEventListener('submit', event => {
    let attachedFiles = attacherInput.length;

    if (attachedFiles <= 0) {
        showBox('warning', 'Por favor, adicione uma imagem ao produto.');
        event.preventDefault();
        return;
    }
});