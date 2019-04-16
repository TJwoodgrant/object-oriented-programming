
function Person(name) {
    this.name = name;
    this.greeting = function() {
        console.log("Hi!, I'm " + this.name + '.');
    };
}

var salva = new Person('Salva');
salva.name;
salva.greeting();

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

var secondsCounter = new Counter("Seconds");
while(secondsCounter.value < 50) {
    clock.tick();
    console.log( clock.name + " : " + clock.time);
}