"use strict";
var $ = require("jquery");
function createLayout(parkingMoniker, size, done) {
    $.get("/api/parking/" + parkingMoniker + "/CreateLayout/", size)
        .done(done);
}
exports.createLayout = createLayout;
;
function saveLayout(parkingMoniker, places, done) {
    $.ajax({
        url: "/api/parking/" + parkingMoniker + "/SaveLayout",
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(places),
        success: done
    });
}
exports.saveLayout = saveLayout;
;
//# sourceMappingURL=layoutService.js.map