"use strict";
var $ = require("jquery");
var Place = require("../viewModels/placeViewModel");
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
                place.activeBtn.toggleClass("occupied").toggle("O");
        };
        container.on("click", ".js-btn-lot", function (e) {
            e.stopPropagation();
            var place = new Place($(e.target));
            parkIt(place);
        });
    };
    return WorkshopController;
}());
module.exports = WorkshopController;
//# sourceMappingURL=workshopController.js.map