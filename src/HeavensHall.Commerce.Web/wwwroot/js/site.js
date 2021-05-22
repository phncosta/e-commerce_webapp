
// Base Global Script Usage
const homeRedirection = () => { window.location.href = '/' }
const show = field => field.style.display = 'block';
const hide = field => field.style.display = 'none';
const clean = field => field.value = '';

// Pop-up Global Warning Message
function showBox(messageType, message) {
    let boxClassType = {
        'warning': 'warning-box',
        'success': 'success-box'
    }

    let box = document.createElement('div');
    box.setAttribute("id", "meu_teste");
    box.innerHTML = message;
    box.classList.add(boxClassType[messageType]);
    document.body.appendChild(box);
    box.addEventListener('click', () => { box.style.display = 'none' });
    setTimeout(() => { box.remove() }, 3000);
}