document.addEventListener('DOMContentLoaded', (event) => {
    const display = document.getElementById('display');

    function appendToDisplay(value) {
        display.value += value;
    }

    function clearDisplay() {
        display.value = '';
    }

    function deleteLastCharacter() {
        display.value = display.value.slice(0, -1);
    }

    function calculateAndAppend() {
        try {
            display.value = eval(display.value);
        } catch (e) {
            display.value = 'Error';
        }
    }

    function calculatePercentage() {
        try {
            display.value = eval(display.value) / 100;
        } catch (e) {
            display.value = 'Error';
        }
    }

    // Bind functions to window object for use in inline onclick
    window.appendToDisplay = appendToDisplay;
    window.clearDisplay = clearDisplay;
    window.deleteLastCharacter = deleteLastCharacter;
    window.calculateAndAppend = calculateAndAppend;
    window.calculatePercentage = calculatePercentage;
});