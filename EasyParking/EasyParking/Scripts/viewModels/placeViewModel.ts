class Place {

    row;
    column;
    isParkingAllowed;
    occupied;
    booked;
    activeBtn;

    constructor(placeBtn) {
        this.activeBtn = placeBtn;
        this.row = placeBtn.attr("data-row");
        this.column = placeBtn.attr("data-column");
        this.isParkingAllowed = placeBtn.hasClass("lot");
        this.booked = placeBtn.hasClass("booked");
        this.occupied = placeBtn.hasClass("occupied");
    }


}
export = Place