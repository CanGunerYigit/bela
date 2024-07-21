function appendToDisplay(value) {
    const display = document.getElementById('display');
    display.value += value;
}

function clearDisplay() {
    const display = document.getElementById('display');
    display.value = '';
    display.classList.remove('negative');
}

function calculateAndAppend() {
    const display = document.getElementById('display');
    try {
        const result = eval(display.value.replace('x', '*').replace('÷', '/'));
        display.value = result;

        if (result < 0) {
            display.classList.add('negative');
        } else {
            display.classList.remove('negative');
        }
    } catch {
        display.value = 'Error';
        display.classList.remove('negative');
    }
}
