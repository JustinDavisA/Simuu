// Reference html canvas id
var ctx = document.getElementById("ctx").getContext("2d");
ctx.font = '30px Arial';
var HEIGHT = 720;
var WIDTH = 1280;

// Note border collision
var message = 'Bouncing';

// Function to get random int
function getRandomInt(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

// Create a lisit of simuus
var simuuList = {};

// Generate Simuu COnstructor
function GenerateSimuu(id, xPosition, yPosition, speed, senseRadius, icon, energy, thirst, hunger, mood, restImpulse, drinkImpulse, eatImpulse, fightImpulse, befriendImpulse, reproduceImpulse) {
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
        befriendImpulse: befriendImpulse,
        reproduceImpulse: reproduceImpulse,
    };
    simuuList[id] = simuu;
}

// Loop and create some random Simuus
for (var i = 0; i < 15; i++) {
    var xPosition = getRandomInt(1, 1279);
    var yPosition = getRandomInt(1, 719);
    var speed = getRandomInt(.1, 1);
    var senseRadius = getRandomInt(50, 100);
    var energy = getRandomInt(75, 100);
    var thirst = getRandomInt(75, 100);
    var hunger = getRandomInt(75, 100);
    var mood = getRandomInt(75, 100);
    var restImpulse = getRandomInt(25, 75);
    var drinkImpulse = getRandomInt(25, 75);
    var eatImpulse = getRandomInt(25, 75);
    var fightImpulse = getRandomInt(0, 25);
    var befriendImpulse = getRandomInt(25, 50);
    var reproduceImpulse = getRandomInt(75, 100);
    GenerateSimuu(i, xPosition, yPosition, speed, senseRadius, '☺', energy, thirst, hunger, mood, restImpulse, drinkImpulse, eatImpulse, fightImpulse, befriendImpulse, reproduceImpulse);
}

// return distance between two entities 
function getDistanceBetweenTwoEntities(entity1, entity2) {
    var vx = entity1.x - entity2.x
    var vy = entity1.y - entity2.y
    return Math.sqrt(vx * vx + vy * vy);
}

// return true if in sense radius
function testSenseCollision(entity1, entity2) {
    var distance = getDistanceBetweenTwoEntities(entity1, entity2);
    return distance < 50;
}

// Wander movement loop
function EntityWander(entity) {
    // Get random facing direction Up, Right, Down, Left
    var facing = getRandomInt(1, 4);

    // Set move speed from 0 to entity speed randomly
    var moveSpeed = getRandomInt(0, entity.speed);

    // Steps taken in a direction
    var moveLength = getRandomInt(1, 5);

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
function UpdateEntityPosition(entity) {
    EntityWander(entity);

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

// Update Simuu art
function DrawEntity(entity) {
    ctx.fillText(entity.icon, entity.xPosition, entity.yPosition);
}

// Update Simuu
function UpdateEntity(entity) {
    UpdateEntityPosition(entity);
    DrawEntity(entity);
}

// Set update framerate
setInterval(Update, 25);

// Update Simulation
function Update() {
    ctx.clearRect(0, 0, WIDTH, HEIGHT);
    for (var simuu in simuuList) {
        UpdateEntity(simuuList[simuu]);
    }
}