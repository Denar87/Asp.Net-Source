function onCalendarShown() {

    var cal = $find("calendar1");
    //Setting the default mode to month
    cal._switchMode("months", true);

    //Iterate every month Item and attach click event to it
    if (cal._monthsBody) {
        for (var i = 0; i < cal._monthsBody.rows.length; i++) {
            var row = cal._monthsBody.rows[i];
            for (var j = 0; j < row.cells.length; j++) {
                Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", call);
            }
        }
    }
}

function onCalendarHidden() {
    var cal = $find("calendar1");
    //Iterate every month Item and remove click event from it
    if (cal._monthsBody) {
        for (var i = 0; i < cal._monthsBody.rows.length; i++) {
            var row = cal._monthsBody.rows[i];
            for (var j = 0; j < row.cells.length; j++) {
                Sys.UI.DomEvent.removeHandler(row.cells[j].firstChild, "click", call);
            }
        }
    }

}

function call(eventElement) {
    var target = eventElement.target;
    switch (target.mode) {
        case "month":
            var cal = $find("calendar1");
            cal._visibleDate = target.date;
            cal.set_selectedDate(target.date);
            cal._switchMonth(target.date);
            cal._blur.post(true);
            cal.raiseDateSelectionChanged();
            break;
    }
}
 