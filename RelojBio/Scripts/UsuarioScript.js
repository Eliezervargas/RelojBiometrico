$('.myDatepicker').datetimepicker({
    format: 'DD/MM/YYYY'
});


$('#PasswordIcono').mouseover(function () {
    $('#Password').attr('type', 'text');
});

$('#PasswordIcono').mouseout(function () {
    $('#Password').attr('type', 'password');
});
