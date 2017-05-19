"use strict";
var $ = require("jquery");
var ParkingService = (function () {
    function ParkingService() {
    }
    ParkingService.parkVechicle = function (parkingMoniker, place, carNumber, done) {
        $.ajax({
            url: "/api/parking/" + parkingMoniker + "/ParkVechicle/" + carNumber,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(place),
            success: done
        });
    };
    return ParkingService;
}());
module.exports = ParkingService;
//# sourceMappingURL=parkingService.js.map