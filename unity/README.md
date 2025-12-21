# ONE World - Metaverse Lobby

> Unity project for the ONE World metaverse lobby experience.

## Project Info

| Property | Value |
|----------|-------|
| Unity Version | 6000.3.2f1 (Unity 6) |
| Render Pipeline | Universal Render Pipeline (URP) |
| Platform Targets | WebGL, Windows, macOS, Android, iOS |
| Company | EXPL |
| Product | ONE World |

## Directory Structure

```
Assets/
├── Animations/          # Animation clips and controllers
├── Audio/
│   ├── Music/          # Background music tracks
│   └── SFX/            # Sound effects
├── Fonts/              # Custom fonts (Space Grotesk, Roboto Mono)
├── Materials/          # Materials and shaders
├── Prefabs/
│   ├── Environment/    # World objects, props
│   ├── Network/        # Networked prefabs
│   ├── Player/         # Player avatar prefabs
│   └── UI/             # UI prefabs
├── Resources/
│   ├── Config/         # Runtime-loadable configurations
│   └── Data/           # Runtime data files
├── Scenes/
│   └── Lobby.unity     # Main lobby scene
├── Scripts/
│   ├── Audio/          # Audio management
│   ├── Core/           # Core systems (GameManager, Config)
│   ├── Network/        # Networking, wallet connection
│   ├── Player/         # Player controller, avatar
│   ├── UI/             # UI management
│   ├── VFX/            # Visual effects
│   └── World/          # Environment, interactables
├── Settings/           # URP and render settings
└── Textures/           # Texture assets
```

## Core Systems

### GameManager
Central singleton managing game state and lifecycle.

```csharp
// Access game manager
GameManager.Instance.EnterLobby();
GameManager.Instance.CurrentState; // GameState.Lobby
```

### NetworkManager
Handles multiplayer connectivity and player synchronization.

```csharp
NetworkManager.Instance.Connect();
NetworkManager.Instance.OnConnected += () => Debug.Log("Connected!");
```

### WalletConnector
Blockchain wallet integration for the ONE ecosystem.

```csharp
WalletConnector.Instance.Connect();
WalletConnector.Instance.OnWalletConnected += (address) => Debug.Log($"Wallet: {address}");
```

### UIManager
Central UI state management.

```csharp
UIManager.Instance.ShowLobby();
UIManager.Instance.ShowSettings();
```

### AudioManager
Audio playback and volume control.

```csharp
AudioManager.Instance.PlayLobbyMusic();
AudioManager.Instance.SetMasterVolume(0.8f);
```

## Namespaces

| Namespace | Purpose |
|-----------|---------|
| `ONEWorld.Core` | Core game systems |
| `ONEWorld.Network` | Networking and wallet |
| `ONEWorld.Player` | Player controller and avatar |
| `ONEWorld.UI` | User interface |
| `ONEWorld.Audio` | Audio management |
| `ONEWorld.World` | Environment and interactables |
| `ONEWorld.VFX` | Visual effects |

## Getting Started

1. Open the project in Unity 6 (6000.0.42f1 or later)
2. Open `Assets/Scenes/Lobby.unity`
3. Enter Play mode to test

## Build Targets

### WebGL (Primary)
- Optimized for browser-based gameplay
- Integrates with web3 wallet adapters
- Deployed to expl.one

### Desktop (Windows/macOS)
- Standalone builds for development
- Higher graphical fidelity options

### Mobile (Android/iOS)
- Touch-optimized controls
- Mobile wallet integration

## Links

- [ONE World Landing](https://world.expl.one)
- [EXPL Nodes](https://node.expl.one)
- [Documentation](https://docs.expl.one)
- [GitHub](https://github.com/explorills)

---

© 2026 EXPL / ONE Ecosystem
