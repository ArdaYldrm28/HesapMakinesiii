document.addEventListener('DOMContentLoaded', (event) => {
    const display = document.getElementById('display');
    const historyList = document.querySelector('.list-group'); // History list elementini seç

    function appendToDisplay(value) {
        display.value += value;
    }

    function clearDisplay() {
        display.value = '';
    }

    function deleteLastCharacter() {
        display.value = display.value.slice(0, -1);
    }

    async function calculateAndAppend() {
        try {
            const expression = display.value;
            const result = eval(expression);
            display.value = result;

            console.log(expression);
            console.log(result);
            // Sunucuya hesaplama işlemini gönderme
            await saveCalculation(expression, result);
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

    async function saveCalculation(expression, result) {
        try {
            const response = await fetch('/Calculator/SaveCalculation', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ expression: expression, result: result }) // Küçük harflerle gönder
            });

            if (response.ok) {
                console.log('Calculation saved successfully:', response);
                // Sunucuya kaydettikten sonra history'i güncelle
                const newHistoryItem = document.createElement('li');
                newHistoryItem.className = 'list-group-item';
                newHistoryItem.textContent = `${expression} = ${result} at ${new Date().toLocaleString()}`;
                historyList.insertBefore(newHistoryItem, historyList.firstChild);
            } else {
                console.error('Failed to save calculation.');
                console.error('Status:', response.status);
                console.error('Status Text:', response.statusText);
            }
        } catch (error) {
            console.error('Error saving calculation:', error);
        }
    }

    window.appendToDisplay = appendToDisplay;
    window.clearDisplay = clearDisplay;
    window.deleteLastCharacter = deleteLastCharacter;
    window.calculateAndAppend = calculateAndAppend;
    window.calculatePercentage = calculatePercentage;
});
