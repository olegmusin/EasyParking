import * as $ from "jquery";
declare var bootbox: any;

import LayoutService = require("../services/layoutService");
import Place = require("../viewModels/placeViewModel");


//Global module variables
let createBtn = $(".js-btn-layout");
let saveBtn = $(".js-btn-save");
let columns = $("#columns");
let rows = $("#rows");
let places = new Array<Place>();



class LayoutController {

    static init(container) {


        $(".js-btn-lot").each((idx, elem) => {
            places.push(new Place($(elem)));
        });


        var toggleAppearence = (place: Place) => {

            if (place.activeBtn.hasClass("lot"))
                place.activeBtn.removeClass("lot").addClass("lane").text("L");
            else
                place.activeBtn.addClass("lot").removeClass("lane").text("P");

            place.isParkingAllowed = place.activeBtn.hasClass("lot");

            places.push(place);
            places = $.grep(places, (el) => {
                return (el.row === place.row && el.column === place.column);
            }, true);
            places.push(place);

        };

        var done = (data) => {
            container.html(data);

        };

        container.on("click", ".js-btn-lot",
            e => {
                e.stopPropagation();
                var place = new Place($(e.target));
                toggleAppearence(place);
            });
          
        createBtn.click(e => {
            let button = $(e.target);
            let parkingMoniker = button.attr("data-parking-moniker");
            //re-initialize array to clear, if that's not first time creation of layout
            places = new Array<Place>(); 
            LayoutService.createLayout(
                parkingMoniker,
                {
                    columns: columns.val(),
                    rows: rows.val()
                },
                done);

        });

        saveBtn.click(e => {
            let button = $(e.target);
            let parkingMoniker = button.attr("data-parking-moniker");
            if (places.length === columns.val() * rows.val())
                LayoutService.saveLayout(
                    parkingMoniker,
                    places,
                    done);
            else
                bootbox.alert("Not all places are checked!", () => { return });
        });


    };


}
export = LayoutController
