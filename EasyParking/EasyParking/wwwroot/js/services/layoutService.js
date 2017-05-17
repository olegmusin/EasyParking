"use strict";
var $ = require("jquery");
var LayoutService = (function () {
    function LayoutService() {
    }
    LayoutService.createLayout = function (parkingMoniker, size, done) {
        $.get("/api/parking/" + parkingMoniker + "/CreateLayout/", size)
            .done(done);
    };
    ;
    LayoutService.saveLayout = function (parkingMoniker, places, done) {
        $.ajax({
            url: "/api/parking/" + parkingMoniker + "/SaveLayout",
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(places),
            success: done
        });
    };
    ;
    return LayoutService;
}());
module.exports = LayoutService;
//# sourceMappingURL=layoutService.js.map