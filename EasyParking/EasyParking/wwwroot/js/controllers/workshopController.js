"use strict";
var $ = require("jquery");
var Place = require("../viewModels/placeViewModel");
var ParkingService = require("../services/parkingService");
var places = new Array();
var WorkshopController = (function () {
    function WorkshopController() {
    }
    WorkshopController.init = function (container) {
        $(".js-btn-lot").each(function (idx, elem) {
            places.push(new Place($(elem)));
        });
        var parkIt = function (place) {
            if (place.activeBtn.hasClass("lane"))
                return;
            else
                place.activeBtn
                    .toggleClass("lot")
                    .toggleClass("occupied")
                    .text(function (i, text) { return text === "O" ? "P" : "O"; });
        };
        var done = function () {
            bootbox.alert("Parked!");
        };
        container.on("click", ".js-btn-lot", function (e) {
            var carNumber = $("#carNumber").val();
            e.stopPropagation();
            var button = $(e.target);
            var parkingMoniker = button.attr("data-parking-moniker");
            var place = new Place(button);
            parkIt(place);
            ParkingService.parkVechicle(parkingMoniker, place, carNumber, done);
        });
    };
    return WorkshopController;
}());
module.exports = WorkshopController;
//# sourceMappingURL=workshopController.js.map