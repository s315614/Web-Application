$(function () {
    $("#register-form").validate({
        rules: {
            email: {
                required: true,
                email: true
            }
        }
        
    });
    messages: {
        email: {
            required: 'Epost må oppgis.',
            email: '<em>Ugyldig<em> epost adresse.'
        }
    }

});