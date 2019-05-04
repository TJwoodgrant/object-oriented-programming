# Artillery 3

**Warning: This repository is private. If you're reading this, you're in the wrong place. Check back once it's actually been cleaned of typos.**

by mikanwolfe, 03-2019, mikanwolfe@nekox.net.

---

**Artillery 3** is a 2D physics-based shooter where players take turns controlling vehicles on a map of of varying elevation. Players will be able to move their *artillery pieces* across the map and fire in large arcs towards enemy players, with the explicit goal of desytroying all other players.

Artillery 3 is a complete re-write of the original Artillery 2 project found [here](https://github.com/Mikanwolfe/artillery). 

**Features:**

* Mulitple vehicles (now *Characters* or *Mobiles*) with **art!!!**
* Improved projectile physics (projectiles have different dynamics such as lift)
* Fractal Terrain generation using the Midpoint Displacement Algorithm
* Destructable terrain!
* Aiming help (finally)
* Improved graphics and possibly animations! (Terrain textures and character animations)
* Scenes and proper menu Game States
* Saving character stats
* Multiplayer networking support, possibly.

The terrain in Artillery 3 will be generated based on various algorithms using the *strategy* design pattern. Vehicle dynamics will be incoporated using the *composite* design pattern and the UI will embody various themes using the *Factory* design patten.

**Roadmap:**

* [ ] Multiplayer Support (Local)
* [ ] Multiplayer Support (Network)
* [ ] Strategy Design Pattern
  * [ ] Random terrain generation
  * [ ] Algorithmic terrain generation
* [ ] Realistic Physics
* [ ] Wind
* [ ] Multiple Vehicles
  * [ ] Vehicle statistics
    * [ ] Restricted firing angles
    * [ ] Restricted firing power
* [ ] NPC/AI/""CPU"" enemies
* [ ] Effects (Mirror, Power, Duplicate/Cut)
* [ ] Support Modules (Satellite attacks)
* [ ] Environmental Effects

---

## Artillery 3 Development Documents

I've always found a development document that I can constantly write in to be rather useful when making something though the limitations of MarkDown often slow this down a little. On the other hand, it does make it easier to keep track of where ideas go. This will be the development docs for Artillery 3 ater 31/03/2019. The earlier docs can be found at nekox.net/posts, though I don't know if the page has been able to render properly.

## To do

Next up would be:

* Connecting players to characters
* Having multiple players
* Possibly a menu state to intialise players
* Handling moving between players
* Camera movement between players
* Health and damage for players
* Basic animations for now?

Started basic work on migrating stuff over to world, next is player management -- id assume they're created by the menu and then sent over? Either way, they need to be added in manually for now.







## 31/03/19: Lots Of Classes I Don't Take

Since Read/Write is one of those things I should include, I'll try to include proper support for reading/writing to JSON files since they're industry standard (and I have some experience here too).

Lots of development as thrown out the original UML docs since I'm quite unskilled in this. I've settled for a Composite design pattern for entities since they can contain each other and share similar base properties, though the pattern does loosen up since some entities are different to others. In the end, they may be defined by their type or interfaces, but we'll have to test to find out.



### Singleton Design Pattern

As there should only be one instance of the entity manager, I decided to go for the singleton design pattern here. I am justifying the use of this since it will always be a small program. It took a little bit to implement since a minor bug caused some oversight in some areas but it works since the newest commit.







---



http://blog.nuclex-games.com/tutorials/cxx/game-state-management/

https://gamedev.stackexchange.com/questions/13244/game-state-management-techniques

http://gameprogrammingpatterns.com/flyweight.html





---

The name "Artillery" will be used for Atillery 3 in this document and explicit mention will be made for Artillery 2, such as 'the original artillery' or 'artillery 2'.

