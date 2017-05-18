import * as $ from "jquery";
declare var bootbox: BootboxStatic;

import Place = require("../viewModels/placeViewModel");
import ParkingService = require("../services/parkingService");

let places = new Array<Place>();

class WorkshopController {

    static init(container) {

        $(".js-btn-lot").each((idx, elem) => {
            places.push(new Place($(elem)));
        });

        var parkIt = (place: Place) => {

            if (place.activeBtn.hasClass("lane")) return;
            else
                place.activeBtn
                    .toggleClass("lot")
                    .toggleClass("occupied")
                    .text((i, text) => text === "O" ? "P" : "O");
       

        }
        var done = () => {
            bootbox.alert("Parked!");
        }
        container.on("click", ".js-btn-lot",
            e => {
                            
                e.stopPropagation();

                let carNumber = $("#carNumber").val();
                let button = $(e.target);
                let parkingMoniker = (window.location.pathname).split("/")[3];

                var place = new Place(button);
                parkIt(place);

                ParkingService.parkVechicle(parkingMoniker,
                    {
                        row: place.row,
                        colomn: place.column
                    },
                    carNumber,
                    done
                );
            });


    }

}

export = WorkshopController