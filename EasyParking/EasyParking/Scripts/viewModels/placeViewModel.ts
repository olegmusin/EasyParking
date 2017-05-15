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


}
export = Place