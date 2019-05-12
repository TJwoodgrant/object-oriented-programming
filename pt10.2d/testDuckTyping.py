class Duck:
    def swim(self):
        print("Duck is swimming!")
        
    def layEggs(self):
        print("Duck is laying eggs!")

class Fish:
    def swim(self):
        print("Fish is swimming!")
        
    def layEggs(self):
        print("Fish is laying eggs!")
        
class Diver:
    def swim(self):
        print("A human is waddling around in water!")
        
    def saySomethingFunny(self):
        print("MATLAB is a real programming language!")


def swim(entity):
    entity.swim()
    
def layEggs(entity):
    entity.layEggs()
    
    
duck = Duck()
fish = Fish()
diver = Diver()

duck.swim()
duck.layEggs()

fish.swim()
fish.layEggs()

diver.swim()
diver.layEggs()
