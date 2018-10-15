$(document).ready(function () {
    // Select all
    $('#selectAll').click(function () {
        var c = this.checked;
        $(':checkbox').prop('checked', c);
    });

    $('#deleteMulti').click(function () {
        var listId = [];
        $.each($("input[name='item']:checked"), function () {
            listId.push($(this).val());
        });
        $.ajax({
            url: '/CauHoi/DeleteMulti',
            data: {
                listId: listId
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
            }
        });
    })
});