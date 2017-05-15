import * as $ from "jquery";
declare var bootbox: BootboxStatic;

import Place = require("../viewModels/placeViewModel");

let places = new Array<Place>();

class WorkshopController {

    static init(container) {

        $(".js-btn-lot").each((idx, elem) => {
            places.push(new Place($(elem)));
        });

        var parkIt = (place: Place) => {

            if (place.activeBtn.hasClass("lane")) return;
            else 
                place.activeBtn.toggleClass("occupied");
            
        }

        container.on("click", ".js-btn-lot",
            e => {
                e.stopPropagation();
                var place = new Place($(e.target));
                parkIt(place);
            });


    }

}

export = WorkshopController