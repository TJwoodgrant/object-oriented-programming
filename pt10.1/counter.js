function Counter(name) {
    this.name = name;
    this.value = 0;
    this.count = function() {
        this.value++;
    }
    this.reset = function(){
        this.value = 0;
    }
}

function Clock(name) {
    hoursCounter = new Counter("Hours");
    minutesCounter = new Counter("Minutes");
    secondsCounter = new Counter("Seconds");

    this.name = name;
    this.time = function() {
        return hoursCounter.value + ":" + minutesCounter.value + ":" + secondsCounter.value;
    };

    this.tick = function() {
        secondsCounter.count();
        if (secondsCounter.value >= 60) {
            secondsCounter.reset();
            minutesCounter.count();
        };

        if (minutesCounter.value >= 60) {
            minutesCounter.reset();
            hoursCounter.count();
        };

        if (hoursCounter.value >= 24) {
            hoursCounter.reset();
        };
    };


    this.seconds = function() {
        return secondsCounter.value;
    };

    this.minutes = function() {
        return minutesCounter.value;
    };

    this.hours = function() {
        return hoursCounter.value;
    };
    

}


var clock = new Clock("A javascript clock!");
console.log("starting clock");
console.log("ticking: " + clock.minutes());

while(clock.hours() < 20) {
    clock.tick();
    console.log(clock.time());
}
console.log(clock.name);