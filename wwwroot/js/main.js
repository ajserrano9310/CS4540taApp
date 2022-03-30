
/**
 * Author:    Alejandro Serrano
 * Partner:   None
 * Date:      11/21/2021
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Alejandro Serrano - This work may not be copied for use in Academic Coursework.
 *
 * I, Alejandro Serrano, certify that I wrote this code from scratch and did
 * not copy it in part or whole from another source.  Any references used
 * in the completion of the assignment are cited in my README file and in
 * the appropriate method header.
 *
 * File Contents
 *
 * Main program for the availability assignment. Creates a Pixi.js application which allows the user
 * to register their availability. 
 */
var app = null;
const daysOfTheWeek = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"];
const scheduleTimes = ["8:00", "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00"];
const times = generate_times(); // dictionary of coords and times
let savedDates = new Set(); // Saves the dates selected by the user
let savedRects = new Set(); // saves the drawn rectangles 
var userID;


var app = new PIXI.Application({
    backgroundColor: 0xFAEBD7,
    width: 750,
    height: 550
});

document.body.appendChild(app.view);

/**
 * Create lines for grid
 * */
let tracker = new AvailabilityTracker();

/**
 * 
 * Write the text (days and times) to the scene
 * */
writeToScene();

/**
 * Draw the background of the grid
 */
let box = new Selection(100, 40, 500, 480, true);

/*
 * Add to Scene
 * 
 * */
app.stage.addChild(box);
app.stage.addChild(tracker);



/*
Important functions for computations and updating
the main global variables. 
*/


/**
 * Main function that handles selections to the screen. Given a user click, 
 * grabs the x and y from event.
 * Saves the selections for the DB.  
 * If a square was previously drawn, it will hide it and remove it from savedDates. 
 * If the same space is selected again, it will make that selection visible. 
 * @param {any} event
 */
function draw_select(event) {
    vector = normalizeCoords(Math.floor(event.data.global.x), Math.floor(event.data.global.y));
    date = map_coord(vector);
    // We assume that the user wants to unselect their previous selection, hence
    // check if the coordinate is currently selected, if true unselect it and make it invisible
    // and remove it from the saved dates. 
    if (savedDates.has(date)) {
        savedDates.delete(date);
        let iterator = savedRects.values();
        for (entry of iterator) {
            if ((entry.x == vector.x) && (entry.y == vector.y)) {
                entry.rect.visible = false;
                saveToDB(userID);
                return;
            }
        }
    } else {
        // Check if the selection was previously drawn and make it visible
        // avoid drawing infinite rectangles. Re add it to the list of 
        // selections
        savedDates.add(date);
        let iterator = savedRects.values();
        for (entry of iterator) {
            if ((entry.x == vector.x) && (entry.y == vector.y)) {
                entry.rect.visible = true;
                return;
            }
        }
        drawSelection(vector.x, vector.y);
        saveToDB(userID);
    }
}

/**
 * Maps given coordinates to a string of the type '{Day} {Time}'
 * For instance 'Monday 10:30'
 * @param {any} v coordinates
 */

function map_coord(v) {
    mapX = (v.x / 100) - 1; 
    date = daysOfTheWeek[mapX] + " " + times[v.y];
    return date;
}

/**
 * Given a schedule of type string, will convert it to the x and y coordinates
 * and will draw it to the screen. 
 * @param {any} model given by the database
 */
function convert_dates_back_to_rect(model) {
    const parsedDates = model.split(" ");
    var index;
    var xValue;
    var yValue;
    
    for (index = 0; index < parsedDates.length - 1; index = index + 2) {
        var saveToSetofDates = parsedDates[index] + " " + parsedDates[index + 1];
        savedDates.add(saveToSetofDates);
        xValue = (daysOfTheWeek.indexOf(parsedDates[index]) + 1) * 100;
        yValue = getKeyByValue(times, parsedDates[index + 1]);
        yValue = parseInt(yValue);
        drawSelection(xValue, yValue);
    }
}

/**
 * Credits to Geeks for Geeks
 * Original post: https://www.geeksforgeeks.org/how-to-get-a-key-in-a-javascript-object-by-its-value/
 * Traverses dictionary to find the key of the given value. 
 * @param {any} object dictionary
 * @param {any} value of dictionary
 */
function getKeyByValue(object, value) {

    for (var prop in object) {
        if (object.hasOwnProperty(prop)) {
            var valueFromObject = object[prop].toString();
            if (valueFromObject.localeCompare(value) == 0)
                return prop;
        }
    }

}
/**
 * Normalizes the coordinates so that they can be drawn on the screen. 
 * @param {any} x x value
 * @param {any} y y value
 */
function normalizeCoords(x, y) {

    let x_m = x % 100;
    x = x - x_m;
    let y_m = y % 10;
    y = y - y_m;

    vector = {
        x: x,
        y: y
    };

    return vector;
}

/**
 * Converts the screen selection into a string that can be passed
 * into the database
 * @param {any} id id of the DB
 */
function saveToDB(id) {
    var convertedToString = "";
    for (var entry of savedDates) {
        convertedToString = convertedToString + " " + entry;
        console.log(entry);
    }
    convertedToString = convertedToString.substring(1);
    console.log(convertedToString);
    sendToPost(convertedToString, id);
}

/**
 * Sends the string to our C# model to be saved inside the DB. 
 * @param {any} sch string schedule
 * @param {any} id id in the DB. 
 */
function sendToPost(sch, id) {
    var url = "/Availability/SaveSchedule";
    var data =
    {
        sch: sch,
        id: id
    };
    $.post(url, data)
        .done(function (result) {
            alert("Schedule saved. Thank you for submitting!");
        }).always(function () {
            console.log("always");
        });

}
/**
 * Draws the graphic on the given selection coordinates. 
 * @param {any} x x coord
 * @param {any} y y coord
 */
function drawSelection(x, y) {

    let select = new PIXI.Graphics();
    select.beginFill(0xF5CF65);
    select.drawRect(x,y, 99, 10);
    select.alpha = 0.5;
    select.endFill();
    let ss = { x: x, y: y, rect: select };
    savedRects.add(ss);
    app.stage.addChild(select);
}

 /**
  * Writes the time and day text to the scene of the application
  * */
function writeToScene() {

    var t;
    for (t = 0; t < daysOfTheWeek.length; t++) {
        let day = new PIXI.Text(daysOfTheWeek[t], { fontFamily: 'Arial', fontSize: 14, align: 'center' });
        day.x = 100 + t * 100;
        day.y = 10;
        app.stage.addChild(day); // does not draw the same as the graphics
    }

    var d;
    var index = 0;
    for (d = 1; d < 14; d++) {
        let time = new PIXI.Text(scheduleTimes[index], { fontFamily: 'Arial', fontSize: 13, align: 'center' });
        time.x = 650;
        time.y = d * 39;
        app.stage.addChild(time);
        index++;
    }
}

function generate_times() {
    times_dictionary = {
        40: ["8:00"],
        50: ["8:15"],
        60: ["8:30"],
        70: ["8:45"],
        80: ["9:00"],
        90: ["9:15"],
        100: ["9:30"],
        110: ["9:45"],
        120: ["10:00"],
        130: ["10:15"],
        140: ["10:30"],
        150: ["10:45"],
        160: ["11:00"],
        170: ["11:15"],
        180: ["11:30"],
        190: ["11:45"],
        200: ["12:00"],
        210: ["12:15"],
        220: ["12:30"],
        230: ["12:45"],
        240: ["13:00"],
        250: ["13:15"],
        260: ["13:30"],
        270: ["13:45"],
        280: ["14:00"],
        290: ["14:15"],
        300: ["14:30"],
        310: ["14:45"],
        320: ["15:00"],
        330: ["15:15"],
        340: ["15:30"],
        350: ["15:45"],
        360: ["16:00"],
        370: ["16:15"],
        380: ["16:30"],
        390: ["16:45"],
        400: ["17:00"],
        410: ["17:15"],
        420: ["17:30"],
        430: ["17:45"],
        440: ["18:00"],
        450: ["18:15"],
        460: ["18:30"],
        470: ["18:45"],
        480: ["19:00"],
        490: ["19:15"],
        500: ["19:30"],
        510: ["19:45"]
    }
    return times_dictionary;
}


