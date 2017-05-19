import * as $ from "jquery";

class ParkingService {

    static parkVechicle(parkingMoniker, place, carNumber, done) {

        $.ajax({
            url: `/api/parking/${parkingMoniker}/ParkVechicle/${carNumber}`,
            type: 'POST',
            contentType: 'application/json',
            data:  JSON.stringify(place),
            success: done
        });

    }

}

export = ParkingService;