import * as $ from "jquery";

import LayoutService = require("../services/layoutService");
declare var bootbox: any;


let createBtn = $(".js-btn-layout");
let saveBtn = $(".js-btn-save");
let columns = $("#columns");
let rows = $("#rows");
let places = new Array<Place>();

class Place {

    row;
    column;
    isParkingAllowed;
    activeBtn;

    constructor(placeBtn) {
        this.activeBtn = placeBtn;
        this.row = placeBtn.attr("data-row");
        this.column = placeBtn.attr("data-column");
        this.isParkingAllowed = placeBtn.hasClass("lot");
    }

    toggleAppearence() {

        if (this.activeBtn.hasClass("lot"))
            this.activeBtn.removeClass("lot").addClass("lane").text("L");
        else
            this.activeBtn.addClass("lot").removeClass("lane").text("P");

        this.isParkingAllowed = this.activeBtn.hasClass("lot");
        places.push(this);
        places = $.grep(places, (el) => {
            return (el.row === this.row && el.column === this.column);
        }, true);
        places.push(this);

    }
}

class LayoutController {

    static init(container) {


        $(".js-btn-lot").each((idx, elem) => {
            places.push(new Place($(elem)));
        });

        container.on("click", ".js-btn-lot",
            e => {
                e.stopPropagation();
                var place = new Place($(e.target));
                place.toggleAppearence();
            });

        var done = (data) => {
            container.html(data);

        };
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
export { Place, LayoutController }
