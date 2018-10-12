$(document).ready(function () {
    var isSelectAll = false;
    // Select all
    $("input#selectAll").click(function () {
        if (isSelectAll == false) {
            $(" INPUT[type='checkbox']").attr('checked', true);
            isSelectAll = true;
        }
        else {
            $(" INPUT[type='checkbox']").attr('checked', false);
            isSelectAll = false;
        }
    });
});