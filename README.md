# BeastGamesGameTask
Game task from Beast Games. First Person Shooter prototype.

## Manual
- H - check controls
- W - move forward
- S - move backward
- A - move left
- D - move right
- LMB (Left Mouse Button) - fire
- Space - jump
- 1 2 3 (not Numpad) - switch weapon
- Tab - show weapon info

## Objectives
This prototype assumes that in the game world exist objects made from
3 materials (Akai, Midori and Murasaki). For possibility of destroying
these object You have 3 different guns with 3 different projectiles named
respectively to the materials (Akai, Midori and Murasaki). So You can
destroy objects made from **Akai material only with Akai projectile**,
which can be shot **only with Akai gun**, etc.

From the Unity editor You can made a lot of Your own materials, which then
You can use later in the gameplay. Some of object to destroy (CombatTargets)
can be connected to the specific functionalities like opening the door.
That functionality will be triggered after player will destroy that
CombatTarget. For demonstration at that stage I have connected only one
Midori (green) object with one particle system.
