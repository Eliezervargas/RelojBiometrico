
$("#CountryID").change(function () {
    var valor = $("#CountryID option:selected").val();
    $.ajax({
        type: "GET",
        url: "/Localidad/EstadoPais",
        datatype: "Json",
        data: { wCountryID: valor },
        success: function (data) {
            $("#StateID").empty();
            $('#StateID').append('<option value="" disabled>Seleccione...</option>');
            $.each(data, function (index, value) {
                $('#StateID').append('<option value="' + value.StateID + '">' + value.Name + '</option>');
            });
        }
    });
})

$("#StateID").change(function () {
    var valor = $("#StateID option:selected").val();
    $.ajax({
        type: "GET",
        url: "/Localidad/CiudadEstado",
        datatype: "Json",
        data: { wStateID: valor },
        success: function (data) {
            $("#CityID").empty();
            $('#CityID').append('<option value="" disabled>Seleccione...</option>');
            $.each(data, function (index, value) {
                $('#CityID').append('<option value="' + value.CityID + '">' + value.Name + '</option>');
            });
        }
    });
})


function CargarImagen() {
    var inputFile = document.getElementById('inputFile1');
    inputFile.addEventListener('change', mostrarImagen, false);
}


function mostrarImagen(event) {
    var file = event.target.files[0];
    var reader = new FileReader();
    reader.onload = function (event) {
        var img = document.getElementById('Img1');
        img.src = event.target.result;
    }
    reader.readAsDataURL(file);
}

window.addEventListener('load', CargarImagen, false);


function QuitarImagen() {
    $("#inputFile1").val("");
    $('#Img1').attr("src", "/Imagenes/Clientes/FondoImagenUsuario.png");
}

