
$(document).ready(function () {
    console.log('Document ready'); // Check if document ready event is firing

    $('#addPersonBtn').on('click', function () {
        console.log('Sulod');
        var firstName = $('#FirstName').val();
        var lastName = $('#LastName').val();

        if (firstName.trim() === '' || lastName.trim() === '') {
            alert('Please fill up both first name and last name fields.');
            return;
        }

        var data = {
            FirstName: firstName,
            LastName: lastName
        };

        fetch('/Home/RegisterPerson', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
            .then(response => {
                if (response.ok) {
                    // If the response is successful, redirect to the Index action
                    window.location.href = '/Home/Index';
                } else {
                    // If there's an error in the response, display an alert message
                    alert('Error occurred while adding person.');
                }
            })
            .catch(error => {
                // If there's an error in making the request, display an alert message
                console.error('Error:', error);
                alert('Error occurred while adding person.');
            });
    });

});
