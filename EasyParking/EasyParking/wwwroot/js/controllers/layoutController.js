"use strict";
var $ = require("jquery");
var LayoutService = require("../services/layoutService");
var Place = require("../viewModels/placeViewModel");
var createBtn = $(".js-btn-layout");
var saveBtn = $(".js-btn-save");
var columns = $("#columns");
var rows = $("#rows");
var places = new Array();
var LayoutController = (function () {
    function LayoutController() {
    }
    LayoutController.init = function (container) {
        $(".js-btn-lot").each(function (idx, elem) {
            places.push(new Place($(elem)));
        });
        var toggleAppearence = function (place) {
            if (place.activeBtn.hasClass("lot"))
                place.activeBtn.removeClass("lot").addClass("lane").text("L");
            else
                place.activeBtn.addClass("lot").removeClass("lane").text("P");
            place.isParkingAllowed = place.activeBtn.hasClass("lot");
            places.push(place);
            places = $.grep(places, function (el) {
                return (el.row === place.row && el.column === place.column);
            }, true);
            places.push(place);
        };
        var done = function (data) {
            container.html(data);
        };
        container.on("click", ".js-btn-lot", function (e) {
            e.stopPropagation();
            var place = new Place($(e.target));
            toggleAppearence(place);
        });
        createBtn.click(function (e) {
            var button = $(e.target);
            var parkingMoniker = button.attr("data-parking-moniker");
            places = new Array();
            LayoutService.createLayout(parkingMoniker, {
                columns: columns.val(),
                rows: rows.val()
            }, done);
        });
        saveBtn.click(function (e) {
            var button = $(e.target);
            var parkingMoniker = button.attr("data-parking-moniker");
            if (places.length === columns.val() * rows.val())
                LayoutService.saveLayout(parkingMoniker, places, done);
            else
                bootbox.alert("Not all places are checked!", function () { return; });
        });
    };
    ;
    return LayoutController;
}());
module.exports = LayoutController;
//# sourceMappingURL=layoutController.js.map