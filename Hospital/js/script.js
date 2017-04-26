function modificarTituloModal(texto) {
    $(".modal-title").html("");
    $(".modal-title").html(texto);
}

function obtenerInputDate(fecha) {
    fecha = new Date(parseInt(fecha.replace("/Date(", "").replace(")/", "")));
    return fecha.getFullYear() + "-" + formatoFecha(fecha.getMonth() + 1) + "-" + formatoFecha(fecha.getDate());
}

function formatoFecha(numero) {
    if (numero < 10) {
        numero = "0" + numero;
    }
    return numero;
}