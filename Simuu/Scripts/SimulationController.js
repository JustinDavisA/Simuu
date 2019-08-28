﻿// Reference html canvas id
var ctx = document.getElementById("ctx").getContext("2d");
ctx.font = '30px Arial';
var HEIGHT = 720;
var WIDTH = 1280;

// Note border collision
var message = 'Bouncing';

// Function to get random int including min and max values
function getRandomInt(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

// Create a lisit of simuus
var simuuList = {};

// Generate Simuu Constructor
GenerateSimuu = function (id, xPosition, yPosition, speed, senseRadius, icon, energy, thirst, hunger, mood, restImpulse, drinkImpulse, eatImpulse, fightImpulse, flightImpulse, befriendImpulse, reproduceImpulse) {
    var simuu = {
        id: id,
        xPosition: xPosition,
        yPosition: yPosition,
        speed: speed,
        senseRadius: senseRadius,
        icon: icon,
        energy: energy,
        thirst: thirst,
        hunger: hunger,
        mood: mood,
        restImpulse: restImpulse,
        drinkImpulse: drinkImpulse,
        eatImpulse: eatImpulse,
        fightImpulse: fightImpulse,
        flightImpulse: flightImpulse,
        befriendImpulse: befriendImpulse,
        reproduceImpulse: reproduceImpulse,
    };
    simuuList[id] = simuu;
}

// Loop and create some random Simuus
for (var i = 0; i < 15; i++) {
    var xPosition = getRandomInt(1, 1279);
    var yPosition = getRandomInt(1, 719);
    var speed = getRandomInt(1, 5);
    var senseRadius = getRandomInt(50, 100);
    var icon = '☺';
    var energy = getRandomInt(75, 100);
    var thirst = getRandomInt(75, 100);
    var hunger = getRandomInt(75, 100);
    var mood = getRandomInt(75, 100);
    var restImpulse = getRandomInt(25, 75);
    var drinkImpulse = getRandomInt(25, 75);
    var eatImpulse = getRandomInt(25, 75);
    var fightImpulse = getRandomInt(0, 25);
    var flightImpulse = getRandomInt(0, 25);
    var befriendImpulse = getRandomInt(25, 50);
    var reproduceImpulse = getRandomInt(75, 100);
    GenerateSimuu(i, xPosition, yPosition, speed, senseRadius, icon, energy, thirst, hunger, mood, restImpulse, drinkImpulse, eatImpulse, fightImpulse, flightImpulse, befriendImpulse, reproduceImpulse);
}

// return distance between two entities 
DistanceBetweenSimuus = function (entity1, entity2) {
    var vx = entity1.xPosition - entity2.xPosition;
    var vy = entity1.yPosition - entity2.yPosition;
    return Math.sqrt(vx * vx + vy * vy);
}

// return true if in sense radius
TestSenseCollision = function (entity1, entity2) {
    var distance = DistanceBetweenSimuus(entity1, entity2);
    return distance < 50;
}

// Wander movement loop
SimuuWander = function (entity) {
    // Get random facing direction Up, Right, Down, Left
    var facing = getRandomInt(1, 4);

    // Set move speed from 0 to entity speed randomly
    var moveSpeed = getRandomInt(0, entity.speed);

    // Steps taken in a direction
    var moveLength = getRandomInt(0, 10);

    // check facing and move
    if (facing == 1) {
        for (var i = 0; i < moveLength; i++) {
            entity.yPosition += moveSpeed;
        }
    } else if (facing == 2) {
        for (var i = 0; i < moveLength; i++) {
            entity.xPosition += moveSpeed;
        }
    } else if (facing == 3) {
        for (var i = 0; i < moveLength; i++) {
            entity.yPosition -= moveSpeed;
        }
    } else if (facing == 4) {
        for (var i = 0; i < moveLength; i++) {
            entity.xPosition -= moveSpeed;
        }
    }
}

// Update Simuu Position
UpdateSimuuPosition = function (entity) {
    SimuuWander(entity);

    // Bounce off of left and right edge if leaving bounds
    if (entity.xPosition < 0 || entity.xPosition > WIDTH) {
        console.log(message);
        entity.speed = -entity.speed;
    }
    // Bounce off of top and bottom edge if leaving bounds
    if (entity.yPosition < 0 || entity.yPosition > HEIGHT) {
        console.log(message);
        entity.speed = -entity.speed;
    }
}

// Check all simuu collision states
CheckSimuuCollision = function (entity1, entity2) {
    if ((TestSenseCollision(entity1, entity2) === false) && (entity1 != entity2)) {
        simuu1.icon = "X";
        simuu2.icon = "X";
        simuu1.speed = 0;
        simuu2.speed = 0;
    }
}

// Update Simuu graphics
UpdateSimuuGFX = function (entity) {
    ctx.fillText(entity.icon, entity.xPosition, entity.yPosition);
}

// Update Simuu
UpdateSimuu = function (entity) {
    UpdateSimuuPosition(entity);
    UpdateSimuuGFX(entity);
}

// Update Entire Simulation
Update = function () {
    ctx.clearRect(0, 0, WIDTH, HEIGHT);

    for (var simuu1 in simuuList) {
        UpdateSimuu(simuuList[simuu1]);


    }

    for (var sim1 in simuuList) {
        console.log(sim1.xPosition);
        for (var sim2 in simuuList) {
            DistanceBetweenSimuus(sim1, sim2);
        }
    }
}

// Set update framerate
setInterval(Update, 1125);