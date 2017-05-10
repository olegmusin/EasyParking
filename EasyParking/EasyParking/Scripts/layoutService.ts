import * as $ from "jquery";

function createLayout(parkingMoniker, size, done) {

    $.get(`/api/parking/${parkingMoniker}/CreateLayout/`, size)
        .done(done);

};

function saveLayout(parkingMoniker, places, done) {

    $.ajax({
        url: `/api/parking/${parkingMoniker}/SaveLayout`,
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(places),
        success: done
    });
};

export { createLayout, saveLayout }