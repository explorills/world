# [ONE world](https://world.expl.one)

**// powered by [EXPL Nodes](https://node.expl.one)**

Game lobby and multiplayer interface for the ONE ecosystem metaverse platform.

## Overview

ONE world is an immersive metaverse platform connecting digital identity, virtual experiences, and blockchain economies. This repository contains the game lobby interface — the entry point for players accessing the ONE world multiplayer environment.

The lobby provides:
- User connection and authentication
- Multiplayer chat integration
- In-game marketplace access
- Game session management
- Resource and documentation links

## Project Structure

```
/
├── src/                    # Lobby interface (React/TypeScript)
│   ├── App.tsx             # Main application
│   ├── components/         # UI components
│   │   ├── VideoBackground.tsx
│   │   ├── ConnectButton.tsx
│   │   ├── CornerButton.tsx
│   │   └── ui/             # Shadcn UI components
│   ├── assets/
│   │   ├── images/         # Logo and graphics
│   │   └── video/          # Background video
│   └── lib/                # Utilities
│
└── unity/                  # Game client (Unity 6000.3.x LTS)
    ├── Assets/             # Game assets
    ├── Packages/           # Unity packages
    └── ProjectSettings/    # Unity configuration
```

## Technology Stack

### Lobby Interface
- React 19 with TypeScript
- Bun runtime and package manager
- Vite 7 build tool
- Tailwind CSS 4
- Framer Motion for animations
- Radix UI components
- Phosphor Icons

### Game Client
- Unity 6000.3.x LTS
- Universal Render Pipeline (URP)

## Development

### Prerequisites
- Bun v1.3+ ([bun.sh](https://bun.sh))
- Unity 6000.3.x LTS (for game client)

### Lobby Setup

```bash
# Install dependencies
bun install

# Start development server
bun dev

# Build for production
bun run build

# Type checking
bun run type-check
```

## Features

### Current
- Full-screen video background with responsive coverage
- Centered hero image with brand identity
- Connect button for user authentication
- Modal system for resources and game information
- Hot pink (#ec4899) theme with dark UI

### Planned
- Multiplayer chat integration (ONE chat)
- Wallet connection and ONE ID authentication
- In-game marketplace powered by EXPL
- Guild and team coordination
- Cross-platform session management

## ONE Ecosystem Integration

ONE world is part of the broader ONE ecosystem:

| Platform | Description |
|----------|-------------|
| [expl.one](https://expl.one) | Main ecosystem landing |
| [pump.expl.one](https://pump.expl.one) | Token sentiment platform |
| [network.expl.one](https://network.expl.one) | Blockchain infrastructure |
| [node.expl.one](https://node.expl.one) | EXPL Nodes purchase |
| [docs.expl.one](https://docs.expl.one) | Documentation |

## Community

- [Discord](https://discord.com/invite/RetTCVq7tJ)
- [Twitter](https://x.com/explorills_main)
- [GitHub](https://github.com/explorills)

## License

MIT

---

**[ONE world](https://world.expl.one)** // powered by [EXPL Nodes](https://node.expl.one)
