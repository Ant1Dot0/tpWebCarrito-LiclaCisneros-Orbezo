function agregarAlertaAdd() {

    sessionStorage.setItem('AlertaAdded', 1);
}

function agregarAlertaSub() {
    sessionStorage.setItem('AlertaSubstract', 1);
}

function agregarAlertaPay() {
    sessionStorage.setItem('AlertaPayment', 1);
}

window.onload = function mostrarAlerta() {

    var auxAlert = sessionStorage.getItem('AlertaAdded');
    if (auxAlert == 1) {
        $('#alertAdd').show();
        sessionStorage.setItem('AlertaAdded', 0);
    }

    var auxAlert = sessionStorage.getItem('AlertaSubstract');
    if (auxAlert == 1) {
        $('#alertSub').show();
        sessionStorage.setItem('AlertaSubstract', 0);
    }

    var auxAlert = sessionStorage.getItem('AlertaPayment');
    if (auxAlert == 1) {
        $('#alertPay').show();
        sessionStorage.setItem('AlertaPayment', 0);
    }
}