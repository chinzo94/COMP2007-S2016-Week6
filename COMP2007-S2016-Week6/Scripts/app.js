﻿/*custom js code goes here*/
$(document).ready(function () {
    $("a.btn.btn-danger.btn-sm").click(function () {
        return confirm('Are you sure you want to delete?');
    });
});