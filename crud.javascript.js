function checkEmail() {
   let email = document.getElementById('txt_email');
    let filter = /[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}/;
    if (filter.test(email.value)) {
        alert('Formato de e-mail inválido');
        email.focus;
        return true;
    }
    return false;
}
function checkRamal() {
    let ramal = document.getElementById('txt_ramal');
    let filter = /^[0-9]*$/;
    if (!filter.test(ramal.value)) {
        alert('Formato de ramal inválido');
        ramal.focus;
        return true;
    }
    return false;
}
