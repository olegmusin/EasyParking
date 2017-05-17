import * as $ from "jquery";

class ParkingService {

static parkVechicle(parkingMoniker, place, carNumber, done) {

    $.ajax({
        url: `/api/parking/${parkingMoniker}/ParkVechicle`,
        type: 'POST',
        contentType: 'application/json',
        data: { place: JSON.stringify(place), number: carNumber },
        success: done
    });

}

}

export = ParkingService;