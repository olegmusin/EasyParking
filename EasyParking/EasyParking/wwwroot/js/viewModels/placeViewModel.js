"use strict";
var Place = (function () {
    function Place(placeBtn) {
        this.activeBtn = placeBtn;
        this.row = placeBtn.attr("data-row");
        this.column = placeBtn.attr("data-column");
        this.isParkingAllowed = placeBtn.hasClass("lot");
        this.booked = placeBtn.hasClass("booked");
        this.occupied = placeBtn.hasClass("occupied");
    }
    return Place;
}());
module.exports = Place;
//# sourceMappingURL=placeViewModel.js.map