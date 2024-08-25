Overview:

This project is a Unity-based obstacle course game where the player navigates through a series of challenges to collect keys and avoid hazards. The game ends when the player successfully collects all the keys or loses all their health.

Gameplay:

Objective:
-> The player's goal is to collect all the keys scattered across the level while avoiding various obstacles.
-> The game ends in victory when all keys are collected, and in defeat if the player's health reaches zero.
   Controls

Movement: 
-> Use the WASD keys or the left stick on a controller to move the player character.

Jump: 
-> Press the Spacebar or the "A" button on a controller to make the player character jump.

Obstacles:

Swinging Hammer: 
-> A pendulum-like obstacle that swings back and forth. If the player is hit, they are knocked back and take damage.

Molotov (Molly) Area: 
-> A burning area that deals damage over time if the player stays within it.

UI:
-> The UI displays the number of keys collected and the player's health bar.
-> A "Game Over" panel appears when the player's health reaches zero.
-> A "Victory" panel appears when all keys are collected.

Code Explanation:

Input_Handler.cs:
-> Handles the player's movement and input actions.
-> Locks the cursor and hides it during gameplay.
-> Provides methods to get player movement, rotation, and jump force based on input.

Player_Animator.cs:
-> Manages the player's animations, such as running, jumping, and dying.
-> Uses Animator parameters and triggers to control the animations.

Player_Controller.cs:
-> Controls the player's movement, including walking and jumping.
-> Handles the player's rotation based on the camera's direction.
-> Checks the player's health status and triggers the appropriate animations and game states (e.g., Game Over).

Player_Health.cs:
-> Manages the player's health and updates the health bar UI.
-> Provides methods to apply damage to the player and check their current health.

Game_Manager.cs:
-> Acts as a central point for game management.
-> Manages the game's state, such as updating the score, handling game over, and determining when the game is won.
-> Uses the Singleton pattern to ensure only one instance exists and is accessible globally.

Score_Manager.cs:
-> Tracks the number of keys collected by the player.
-> Updates the UI to reflect the player's progress.
-> Checks if the maximum number of keys has been collected, triggering the win condition.

UI_Manager.cs:
-> Controls the visibility and text of the game's UI panels, such as the Game Over and Victory screens.
-> Handles the buttons for restarting or quitting the game.

Collision_Detection.cs:
-> Detects when the player collects a key and updates the score.
-> Disables the key's collider and removes the key from the scene.

Hammer_Script.cs:
-> Controls the swinging motion of the hammer obstacle.
-> Detects collisions with the player and applies a force, as well as damage.

Molly_Script.cs:
-> Handles the burning area that deals damage to the player over time.
-> Starts and stops dealing damage when the player enters or exits the area.