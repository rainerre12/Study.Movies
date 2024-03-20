$(document).ready(function () {
    $('#addPersonBtn').on('click', function () {
        var firstName = $('#FirstName').val();
        var lastName = $('#LastName').val();

        // Validate input fields
        if (firstName.trim() === '' || lastName.trim() === '') {
            alert('Please fill up both first name and last name fields.');
            return;
        }

        //var data = {
        //    FirstName: firstName,
        //    LastName: lastName
        //};
        var data = {
            Persons: {
                FirstName: firstName,
                LastName: lastName
            }
        }

        console.log(data);
        $.ajax({
            url: '/Home/RegisterPerson',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function(response){
                // If the request is successful, redirect to the Index action
                window.location.href = '/Home/Index';
            },
            error: function (xhr, status, error) {
                // If there's an error, display an alert message
                if (xhr.status = 400) {
                    alert('Person with the same name already exists.');
                } else {
                    console.error('Error:', error);
                    alert('Error occurred while adding person.');
                }
            }
        });



        //// Send POST request
        //fetch('/Home/RegisterPerson', {
        //    method: 'POST',
        //    headers: {
        //        'Content-Type': 'application/json'
        //    },
        //    body: JSON.stringify(data)
        //})
        //    .then(response => {
        //        if (response.ok) {
        //            // Handle successful response
        //            // Optionally, update UI here without full page reload
        //            window.location.reload(); // Reload page to reflect changes
        //        } else {
        //            // Handle error response
        //            throw new Error('Failed to add person.');
        //        }
        //    })
        //    .catch(error => {
        //        // Handle fetch errors
        //        console.error('Error:', error);
        //        alert('An error occurred while adding person.');
        //    });
    });
});