# Asteroids
Proof that I can make a video game 🌈

Windows build available under [releases](https://github.com/malyvsen/Asteroids/releases).

Total wall time taken: 14h

## Potential improvements

### Game modes

It should be fairly easy to add game modes like "survive without shooting at all" or "every shot must hit".

### Collision detection

- Could use the fact that collisions are symmetric (A collides with B ⇒ B collides with A) for a 2x speedup
- Could cache children/parent colliders instead of calling `GetComponentIn...` every frame
- Could use entirely different system based on overlapping pixels on the screen

### Customizable controls & volume

### Bounding box

The world could span a bit less than the entire screen - the edges of the screen could then show the other side of the world. This could(?) improve understandability of the wrapping world mechanic?

## Failed experiments

### Controlling with the mouse

- Spaceship faces the mouse (optionally rotates to face the mouse at some given speed)
- Right-clicking causes the spaceship to move forward (optionally: accelerate)

Proved difficult to balance - either the spaceship wasn't always going towards the mouse on right click (counterintuitive), or was too easy to control