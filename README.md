# Wings & Weather 2
In this game, players control a phoenix bird that:

- Flies across the screen, flapping its wings with a smooth animation.
- Gains new life by colliding with SunnyClouds and takes damage by colliding with StormyClouds.
- Resurrects from ashes when healed after damage, showcasing a unique animation.
- Plays different sound effects for interactions (thunderstorm, healing sounds).
- Navigates through multiple gameplay scenes with seamless transitions and asynchronous loading.

## How to Play
- The game starts at the Main Menu, where you can control all game sounds using the slider in the bottom-right corner.
- Click the Play button in the top-left corner to start the game.
- Press Escape during gameplay to open the Pause Menu, where you can return to the Main Menu.
- Navigate the phoenix to interact with clouds and avoid losing all lives.
- When bird dies, the game restarts from the Main Menu.

Survive as long as possible while enjoying the immersive animations and sounds!

## Features Demonstrated

### 1. Gameplay Mechanics
- **Phoenix Bird Controls:** <br>
  The bird moves with arrow keys, restricted to the game window boundaries.
- **Cloud Interactions:** <br>
  SunnyCloud: Adds a life point and plays a healing sound and shows a healing animation. <br>
  StormyCloud: Reduces a life point, plays a thunderstorm sound and shows a damage animation.
- **Phoenix Resurrection:** <br>
  After colliding with a SunnyCloud, the phoenix resurrects with a unique animation.
  <img src="scene.png" alt="" width="300">

### 2. Animations
- **Flapping Wings Animation:** Loops while the phoenix is flying.
- **Damage Animation:** Plays when colliding with a StormyCloud.
- **Resurrection Animation:** Plays when the colliding with a SunnyCloud.
- **Smooth Transitions:** Animations switch states immediately based on gameplay conditions using an Animation Controller.
  <img src="animator.png" alt="" width="300">

### 3. User Interface
- **Main Menu:**
  - Logo: Displays the game logo in the top-right corner.
  - Options: Located in the top-left corner.
  - Master Volume Slider: Adjusts all in-game sounds and music.
    <img src="main.png" alt="" width="300">
- **Pause Menu:**
  - Activated by pressing the Escape key.
  - Displays options in the center of the screen, including "Return to Main Menu."
  - Background is dimmed while the pause menu is active.
    <img src="pause.png" alt="" width="300">

### 4. Scene Management
The game includes two gameplay scenes.
- **Scene Transition Condition:**
  When the phoenix's lives reach 5, the game transitions from the first scene to the second. The gameplay continues seamlessly in the new scene with the same mechanics, but with a different background to signify progression.

- **Smooth Transition:**
  The transition between scenes is asynchronous, ensuring there are no interruptions or delays. The background music continues to play uninterrupted during the transition, maintaining immersion.
  <img src="scene1.png" alt="" width="300">

### 5. Audio System
- **Background Music:**
  - Plays from the main menu and continues seamlessly into gameplay scenes.
  - Loops without overlapping or interruptions.
- **Sound Effects:**
  - StormyCloud: Plays a thunderstorm sound on collision.
  - SunnyCloud: Plays a healing sound on collision.
  - Sounds are spatial, reflecting their position relative to the player.
 
## Contributers

  | İrem Aytaş - 21360859018      | Rojda Özevli - 22360859078    |
  |-------------------------------|-------------------------------|
  | Main Menu(30x)                | Animations(30x)               |
  | Pause Menu(20x)               | Sound and Music(30x)          |
  | Asynchronization(10x)         |                               |


 
