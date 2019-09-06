

// Reference html canvas id
var ctx = document.getElementById("ctx").getContext("2d");


// Canvas setup
ctx.font = '30px Arial';
var WIDTH = 1280;
var HEIGHT = 720;


// GET a JSON from C# of Simuus
GetJSON = function (url) {
    const http = new XMLHttpRequest();
    http.open("GET", url, false);
    http.send();
    return http.response;
}


// Simuu Mapper
MapSimuu = function (entity) {
    var simuu = {
        SimuuID: entity.SimuuID,
        SimuuName: entity.SimuuName,
        SimuuAge: entity.SimuuAge,
        SimuuBirth: entity.SimuuBirth,
        SimuuDeath: entity.SimuuDeath,
        SimuuXCoordinate: entity.SimuuXCoordinate,
        SimuuYCoordinate: entity.SimuuYCoordinate,
        ImpulseToRest: entity.ImpulseToRest,
        ImpulseToDrink: entity.ImpulseToDrink,
        ImpulseToEat: entity.ImpulseToEat,
        StatEnergy: entity.StatEnergy,
        StatThirst: entity.StatThirst,
        StatHunger: entity.StatHunger,
        SimuuMovementSpeed: entity.SimuuMovementSpeed,
        SimuuSenseRadius: entity.SimuuSenseRadius,
        UserID: entity.UserID,
        SimuuIcon: "☺",
    };
    simuuList[entity.SimuuID] = simuu;
}


// ----- TEST CODE ----- //
// Get JSON string from C#
var simuuJson = GetJSON('/Simulation/GetSimulationSimuus');

// Console Log the JSON
console.log("Simuu List");
console.log(simuuJson);

// Parse the JSON string into an array of objects
var simuuArrayList = JSON.parse(simuuJson);

// Console log the new array of objects
console.log("Parsed List");
console.log(simuuArrayList);

// Create a new object to place simuus into later
var simuuList = {};

// Iterate through the list of objects- Call MapSimuu to place data in simuuList WITH an icon
for (var simuuObject in simuuArrayList) {
    MapSimuu(simuuArrayList[simuuObject]);
}

// Console log the new 
console.log("Final List");
console.log(simuuList);


// Update canvas- simuu graphic based on X and Y coord
UpdateSimuuGFX = function (entity) {
    ctx.fillText(entity.SimuuIcon, entity.SimuuXCoordinate, entity.SimuuYCoordinate);
}


// Update Entire Simulation
Update = function () {
    ctx.clearRect(0, 0, WIDTH, HEIGHT);

    for (var simuu in simuuList) {
        UpdateSimuuGFX(simuuList[simuu]);
    }
}


// Set update framerate
setInterval(Update, 25);

