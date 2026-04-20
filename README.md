# Multiplayer Shoot Dodge Game
Shoot... or dodge!

## Setup

### Prerequisites
- Unity 2022.3 LTS or later
- Git

### Installation

1. Clone this repository:
```bash
git clone https://github.com/madygaga6/UnityMultiplayerShootDodgeGame.git
```
3. Open the project in Unity Hub
4. Open the StartScene scene in Assets/Scenes/
5. Press Play to test in the editor

## How to Play

### Controls
- Left/Right: Move
- Space: Shoot
- Escape: Pause menu

### Objective
Player 1: Hit Player 2 three times to win
Player 2: Successfully avoid projectiles until time runs out

## Testing Multiplayer

### Option 1: Build and Run Two Instances
1. Build the project (File → Build Settings → Build)
2. Run the built executable
3. Press Play in the Unity Editor
4. In one instance, click "Host Game"
5. In the other instance, click "Join Game" and enter 127.0.0.1

### Option 2: Using ParrelSync (if installed)
1. Open ParrelSync → Clones Manager
2. Create a clone of the project
3. Open the clone in a separate Unity Editor
4. Run both editors simultaneously

## Project Structure

UnityMultiplayerShootDodgeGame/
├── README.md
├── Assets/
│   ├── Scenes/
│   │   ├── StartScene.unity
│   │   ├── GameScene.unity
│   │   └── EndScene.unity
│   ├── Scripts/
│   │   ├── DatabaseManager/
│   │   ├── GameData/
│   │   ├── GameManager/
│   │   ├── GameOverUI/
│   │   ├── LivesUI/
│   │   ├── NetworkUI/
│   │   ├── ObjectPool/
│   │   ├── PauseMenu/
│   │   ├── PlayerController/
│   │   ├── ProjectileController/
│   │   └── SaveLoadManager/
│   ├── Prefabs/
│   └── Audio/
├── Packages/
└── ProjectSettings/

## Known Issues

- Client doesn't move
- Projectiles don't collide
- Lives UI text doesn't update as a result

## Future Enhancements 
- Fix bugs
- Enhance aestheics and gameplay

## Technologies Used

- **Unity 2022.3 LTS**: Game engine
- **Netcode for GameObjects**: Multiplayer networking
- **SQLite**: Database for persistent storage
- **TextMeshPro**: UI text rendering
