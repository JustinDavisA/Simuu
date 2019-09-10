
// Reference html canvas id
var ctx = document.getElementById("ctx").getContext("2d");

// Canvas setup
ctx.font = '10px Arial';
var WIDTH = 500;
var HEIGHT = 500;

var simuuImage = new Image();
simuuImage.src = "/Images/Simuu.png";

// GET a JSON from C# of Simuus function
GetJSON = function (url) {
    const http = new XMLHttpRequest();
    http.open("GET", url, false);
    http.send();
    return http.response;
}


// Simuu Mapper function- setup object for use in visual update
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
    };
    simuuList[entity.SimuuID] = simuu;
}


// Get JSON string from C#
var simuuJson = GetJSON('/Simulation/GetSimulationSimuus');

// Parse the JSON string into an array of objects
var simuuArrayList = JSON.parse(simuuJson);

// Create a new object to place simuus into later
var simuuList = {};

// Iterate through the list of objects- Call MapSimuu to place data in simuuList WITH an icon
for (var simuuObject in simuuArrayList) {
    MapSimuu(simuuArrayList[simuuObject]);
}


// Update canvas- simuu graphic and sense graphuc based on X and Y coord
UpdateSimuuGFX = function (entity) {
    ctx.save();

    ctx.globalAlpha = 0.3;
    ctx.beginPath();
    ctx.arc(entity.SimuuXCoordinate + 10, entity.SimuuYCoordinate + 12, entity.SimuuSenseRadius, 0, 2 * Math.PI);
    ctx.stroke();
    ctx.fillStyle = "red";
    ctx.fill();

    ctx.globalAlpha = 1;
    ctx.drawImage(simuuImage, 0, 0, 54, 44, entity.SimuuXCoordinate, entity.SimuuYCoordinate, 20, 20);
    ctx.fillStyle = "black";
    ctx.fillText(entity.SimuuName, entity.SimuuXCoordinate - 4, entity.SimuuYCoordinate - 5);
    ctx.restore();
}


// Update Entire Simulation
Update = function () {
    //window.location.reload();
    ctx.clearRect(0, 0, WIDTH, HEIGHT);
    for (var simuu in simuuList) {
        UpdateSimuuGFX(simuuList[simuu]);
    }
    //window.location.reload();
}


// Set update framerate
setInterval(Update, 300);

