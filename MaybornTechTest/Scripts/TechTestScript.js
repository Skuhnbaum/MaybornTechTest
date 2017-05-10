$(document).ready(function () {
    $('#saveData').click(function () {
        var firstName = $('#firstName').val();
        var lastName = $('#lastName').val();

        // Using AJAX to instead of using Razor to postback (No Refresh Nicer)
        $.ajax({
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            url: '/Main/AppendTextFile',
            data: "{'firstName':'" + firstName + "','lastName':'" + lastName + "'}",
            async: false,
            success: function (response) {

                // Instead of just appending the textarea - it gets the contents of the textfile and prints it back to the textarea
                $.get("/Main/GetTextFileContents", function (data) {
                    if (data != null) {
                        $(detailsHistory).text("");
                        for (var i = 0; i < data.length; i++) {
                            $(detailsHistory).append(data[i].Data);
                        }
                    }
                }, "json");

                // Sets values to nothing for clarity
                $('#firstName').val(''); $('#lastName').val('');
            },
            error: function () {
                alert("Error");
            }
        });
    });
});