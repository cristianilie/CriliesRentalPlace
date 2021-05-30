
//Displays payment methods and their view elelemts
function displayPaymentMethod(id) {
    let cashPay = document.getElementById("cashPaymentArea");
    let cardPay = document.getElementById("cardPaymentArea");

    if (id === "cashPayment") {

        cashPay.style.display = "block";
        cardPay.style.display = "none";
    }

    if (id === "cardPayment") {

        cashPay.style.display = "none";
        cardPay.style.display = "block";
    }
}

