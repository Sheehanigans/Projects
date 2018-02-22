$(document).ready(function(){
    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/contacts',
        success: function(contactArray){
            var contactsDiv = $('#allContacts');
        },
        error: function(){
            alert('FAILURE!');
        }
    });

    $('#add-button').on('click', function(){
        $.ajax({
            type: "POST",
            url: "http://localhost:8080/contact",
            data: JSON.stringify({
                firstName: $('#add-first-name').val(),
                lastName: $('#add-last-name').val(),
                company: $('#add-company').val(),
                phone: $('#add-phone').val(),
                email: $('#add-email').val()
            }),
            headers:{
                'Accept' : 'application/json',
                'Content-Type' : 'application/json'
            },
            'dataType' : 'json',
            success: function(){
                alert('SUCCESS');
            },
            error: function(){
                alert('FAILURE');
            }
        })
    });
})