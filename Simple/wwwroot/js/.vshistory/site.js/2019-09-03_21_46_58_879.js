$(function () {

    var gobtn = $('#go-btn');
    var addperson = $('#add-person');
    var modaltest = $('#add-person');
    gobtn.click(function (event) {
        $.get('/Home/TestModal').done(function (data) {
            modaltest.html(data);
            addperson.modal('show');
        });
    });

    //◘◘◘◘

    placeholderElement.find('.modal').modal('show');

    var placeholderElement = $('#modal-placeholder');

    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });
    });

    placeholderElement.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();

        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var dataToSend = form.serialize();
        console.log(dataToSend);

        //$.post(actionUrl, dataToSend).done(function (data, textStatus, jqXHR) {
        //    // determine what was returned from controller

        //    // and perform action e.g. reload modal contents or redirect page

        //});

        $.post(actionUrl, dataToSend).done(function (data) {
            var newBody = $('.modal-body', data);
            placeholderElement.find('.modal-body').replaceWith(newBody);

            var isValid = newBody.find('[name="IsValid"]').val() == 'True';
            if (isValid) {
                placeholderElement.find('.modal').modal('hide');
                //placeholderElement.modal('hide');
                //window.location.reload(true);
            }
        });
    });
});