// Access the URLs from the data attributes in your JavaScript file
var $jq = jQuery.noConflict();
$jq(document).ready(function () {
    console.log('sulod');
    $jq('#movieModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        var modalType = button.data('modal-type');
        console.log(modalType)
        if (modalType === 'add-person') {
            console.log(modalType)
            //var addPersonUrl = $('#movieModal').data('add-person-url');
            var addPersonUrl = '/Home/AddPersonClicked'
            $.ajax({
                url: addPersonUrl,
                type: 'GET',
                success: function (data) {
                    $('#modalContent').html(data);
                },
                error: function (xhr, status, error) {
                    console.error('Error:', error);
                }
            });
        } else if (modalType === 'add-movie') {
            //var addMovieUrl = $('#movieModal').data('add-movie-url');
            var addMovieUrl = '/Home/AddMovieClicked';
            $.ajax({
                url: addMovieUrl,
                type: 'GET',
                success: function (data) {
                    $('#modalContent').html(data);
                },
                error: function (xhr, status, error) {
                    console.error('Error:', error);
                }
            });
        }
    });
});
