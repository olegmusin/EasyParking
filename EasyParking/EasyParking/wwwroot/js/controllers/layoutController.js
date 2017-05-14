"use strict";
var $ = require("jquery");
var LayoutService = require("../services/layoutService");
var createBtn = $(".js-btn-layout");
var saveBtn = $(".js-btn-save");
var columns = $("#columns");
var rows = $("#rows");
var places = new Array();
var Place = (function () {
    function Place(placeBtn) {
        this.activeBtn = placeBtn;
        this.row = placeBtn.attr("data-row");
        this.column = placeBtn.attr("data-column");
        this.isParkingAllowed = placeBtn.hasClass("lot");
    }
    Place.prototype.toggleAppearence = function () {
        var _this = this;
        if (this.activeBtn.hasClass("lot"))
            this.activeBtn.removeClass("lot").addClass("lane").text("L");
        else
            this.activeBtn.addClass("lot").removeClass("lane").text("P");
        this.isParkingAllowed = this.activeBtn.hasClass("lot");
        places.push(this);
        places = $.grep(places, function (el) {
            return (el.row === _this.row && el.column === _this.column);
        }, true);
        places.push(this);
    };
    return Place;
}());
exports.Place = Place;
var LayoutController = (function () {
    function LayoutController() {
    }
    LayoutController.init = function (container) {
        $(".js-btn-lot").each(function (idx, elem) {
            places.push(new Place($(elem)));
        });
        container.on("click", ".js-btn-lot", function (e) {
            e.stopPropagation();
            var place = new Place($(e.target));
            place.toggleAppearence();
        });
        var done = function (data) {
            container.html(data);
        };
        createBtn.click(function (e) {
            var button = $(e.target);
            var parkingMoniker = button.attr("data-parking-moniker");
            //re-initialize array to clear, if that's not first time creation of layout
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
exports.LayoutController = LayoutController;
//# sourceMappingURL=layoutController.js.map