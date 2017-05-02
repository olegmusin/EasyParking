$(document).ready(function () {

    var container = $("#parking-layout");
    var columns = $("#columns");
    var rows = $("#rows");
   
    var places = [];

    $(".js-btn-layout").click(
        function (e) {
            var button = $(e.target);

            $.get(`/api/parking/${button.attr("data-parking-moniker")}/CreateLayout/`,
                {
                    columns: columns.val(),
                    rows: rows.val()
                })
                .done(function (data) {
                    container.html(data);
                });

        });
    container.on("click", ".js-btn-lot", function () {
        var place = {};
        place.row = $(this).attr("data-row");
        place.column = $(this).attr("data-column");
        if ($(this).hasClass("lot"))
            $(this).removeClass("lot").addClass("lane").text("L");
        else
            $(this).addClass("lot").removeClass("lane").text("P");

        place.IsParkingAllowed = $(this).hasClass("lot");
        places.push(place);
        places = $.grep(places, (el) => {
            return (el.row === place.row && el.column === place.column);
        }, true);
        places.push(place);
    });

    $(".js-btn-save").click(
        function (e) {
            var button = $(e.target);
            $.ajax({
                url: `/api/parking/${button.attr("data-parking-moniker")}/SaveLayout`,
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(places),
                success: function(res) {

                    container.html("<div>Successfully saved!</div>");

                }
            });
        });
});

