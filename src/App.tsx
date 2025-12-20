import { useState } from 'react'
import { VideoBackground } from '@/components/VideoBackground'
import { ConnectButton } from '@/components/ConnectButton'
import { CornerButton } from '@/components/CornerButton'
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogDescription,
} from '@/components/ui/dialog'
import { FolderOpen, Book } from '@phosphor-icons/react'
import { toast } from 'sonner'
import logoImage from '@/assets/images/logo.png'
import backgroundVideo from '@/assets/video/background.mp4'

function App() {
  const [resourcesOpen, setResourcesOpen] = useState(false)
  const [mechanicsOpen, setMechanicsOpen] = useState(false)

  const handleConnect = () => {
    toast.info('Connection functionality coming soon!')
  }

  return (
    <div className="fixed inset-0 overflow-hidden bg-black">
      <VideoBackground videoSrc={backgroundVideo} />

      <CornerButton position="top-left" onClick={() => setResourcesOpen(true)}>
        <div className="flex items-center gap-2">
          <FolderOpen className="w-5 h-5" weight="duotone" />
          <span className="hidden sm:inline">Resources</span>
        </div>
      </CornerButton>

      <CornerButton position="top-right" disabled>
        <span className="text-muted-foreground">No Address Connected</span>
      </CornerButton>

      <CornerButton position="bottom-left" disabled>
        <div className="w-5 h-5 opacity-30" />
      </CornerButton>

      <CornerButton position="bottom-right" onClick={() => setMechanicsOpen(true)}>
        <div className="flex items-center gap-2">
          <Book className="w-5 h-5" weight="duotone" />
          <span className="hidden sm:inline">Mechanics</span>
        </div>
      </CornerButton>

      <div className="absolute inset-0 flex flex-col items-center justify-center gap-6 sm:gap-12 p-4">
        <div className="relative w-full max-w-[90vw] sm:max-w-4xl aspect-[1920/700] flex items-center justify-center">
          <div className="absolute inset-0 bg-gradient-to-r from-primary/20 via-accent/20 to-primary/20 rounded-2xl blur-2xl animate-pulse" />
          <div className="relative w-full h-full flex items-center justify-center">
            <img 
              src={logoImage} 
              alt="Logo" 
              className="w-full h-full object-contain"
            />
          </div>
        </div>

        <ConnectButton onClick={handleConnect} />

        <p className="text-xl sm:text-2xl font-normal tracking-widest uppercase text-foreground/80">
          coming soon...
        </p>
      </div>

      <Dialog open={resourcesOpen} onOpenChange={setResourcesOpen}>
        <DialogContent className="bg-black/95 border-primary/50 backdrop-blur-xl max-w-2xl">
          <DialogHeader>
            <DialogTitle className="text-2xl font-bold text-primary flex items-center gap-3">
              <FolderOpen className="w-7 h-7" weight="duotone" />
              Resources
            </DialogTitle>
            <DialogDescription className="text-foreground/80 text-base leading-relaxed pt-4">
              Access the ONE ecosystem resources, documentation, and community channels.
            </DialogDescription>
          </DialogHeader>
          <div className="space-y-6 pt-4">
            <div>
              <h3 className="font-bold text-lg text-primary mb-3">ONE Ecosystem</h3>
              <div className="space-y-2">
                <a 
                  href="https://expl.one/" 
                  target="_blank" 
                  rel="noopener noreferrer"
                  className="block p-4 bg-muted/30 rounded-lg border border-primary/20 hover:border-primary/40 transition-colors"
                >
                  <div className="font-semibold text-primary flex items-center justify-between">
                    EXPL.ONE
                    <span className="text-xs text-accent">Visit →</span>
                  </div>
                </a>
                <div className="pl-4 space-y-2">
                  <a 
                    href="https://pump.expl.one" 
                    target="_blank" 
                    rel="noopener noreferrer"
                    className="block p-3 bg-muted/20 rounded-lg border border-accent/20 hover:border-accent/40 transition-colors"
                  >
                    <div className="text-sm text-foreground/90 flex items-center justify-between">
                      ONE pump
                      <span className="text-xs text-accent">→</span>
                    </div>
                  </a>
                  <a 
                    href="https://network.expl.one" 
                    target="_blank" 
                    rel="noopener noreferrer"
                    className="block p-3 bg-muted/20 rounded-lg border border-accent/20 hover:border-accent/40 transition-colors"
                  >
                    <div className="text-sm text-foreground/90 flex items-center justify-between">
                      ONE network
                      <span className="text-xs text-accent">→</span>
                    </div>
                  </a>
                </div>
                <a 
                  href="https://node.expl.one/" 
                  target="_blank" 
                  rel="noopener noreferrer"
                  className="block p-4 bg-muted/30 rounded-lg border border-primary/20 hover:border-primary/40 transition-colors"
                >
                  <div className="font-semibold text-primary flex items-center justify-between">
                    EXPL Nodes
                    <span className="text-xs text-accent">Visit →</span>
                  </div>
                </a>
                <a 
                  href="https://docs.expl.one/" 
                  target="_blank" 
                  rel="noopener noreferrer"
                  className="block p-4 bg-muted/30 rounded-lg border border-primary/20 hover:border-primary/40 transition-colors"
                >
                  <div className="font-semibold text-primary flex items-center justify-between">
                    ONE documentation
                    <span className="text-xs text-accent">View Docs →</span>
                  </div>
                </a>
              </div>
            </div>

            <div>
              <h3 className="font-bold text-lg text-accent mb-3">Socials</h3>
              <div className="flex gap-4">
                <a 
                  href="https://discord.gg/DMSSuPPrTV/" 
                  target="_blank" 
                  rel="noopener noreferrer"
                  className="flex-1 p-4 bg-muted/30 rounded-lg border border-accent/20 hover:border-accent/40 transition-all hover:scale-105 flex items-center justify-center gap-2"
                >
                  <svg className="w-6 h-6" fill="currentColor" viewBox="0 0 24 24">
                    <path d="M20.317 4.37a19.791 19.791 0 0 0-4.885-1.515a.074.074 0 0 0-.079.037c-.21.375-.444.864-.608 1.25a18.27 18.27 0 0 0-5.487 0a12.64 12.64 0 0 0-.617-1.25a.077.077 0 0 0-.079-.037A19.736 19.736 0 0 0 3.677 4.37a.07.07 0 0 0-.032.027C.533 9.046-.32 13.58.099 18.057a.082.082 0 0 0 .031.057a19.9 19.9 0 0 0 5.993 3.03a.078.078 0 0 0 .084-.028a14.09 14.09 0 0 0 1.226-1.994a.076.076 0 0 0-.041-.106a13.107 13.107 0 0 1-1.872-.892a.077.077 0 0 1-.008-.128a10.2 10.2 0 0 0 .372-.292a.074.074 0 0 1 .077-.01c3.928 1.793 8.18 1.793 12.062 0a.074.074 0 0 1 .078.01c.12.098.246.198.373.292a.077.077 0 0 1-.006.127a12.299 12.299 0 0 1-1.873.892a.077.077 0 0 0-.041.107c.36.698.772 1.362 1.225 1.993a.076.076 0 0 0 .084.028a19.839 19.839 0 0 0 6.002-3.03a.077.077 0 0 0 .032-.054c.5-5.177-.838-9.674-3.549-13.66a.061.061 0 0 0-.031-.03zM8.02 15.33c-1.183 0-2.157-1.085-2.157-2.419c0-1.333.956-2.419 2.157-2.419c1.21 0 2.176 1.096 2.157 2.42c0 1.333-.956 2.418-2.157 2.418zm7.975 0c-1.183 0-2.157-1.085-2.157-2.419c0-1.333.955-2.419 2.157-2.419c1.21 0 2.176 1.096 2.157 2.42c0 1.333-.946 2.418-2.157 2.418z"/>
                  </svg>
                  <span className="text-sm font-medium">Discord</span>
                </a>
                <a 
                  href="https://x.com/explorills_main" 
                  target="_blank" 
                  rel="noopener noreferrer"
                  className="flex-1 p-4 bg-muted/30 rounded-lg border border-accent/20 hover:border-accent/40 transition-all hover:scale-105 flex items-center justify-center gap-2"
                >
                  <svg className="w-5 h-5" fill="currentColor" viewBox="0 0 24 24">
                    <path d="M18.244 2.25h3.308l-7.227 8.26 8.502 11.24H16.17l-5.214-6.817L4.99 21.75H1.68l7.73-8.835L1.254 2.25H8.08l4.713 6.231zm-1.161 17.52h1.833L7.084 4.126H5.117z"/>
                  </svg>
                  <span className="text-sm font-medium">X</span>
                </a>
                <a 
                  href="https://github.com/explorills" 
                  target="_blank" 
                  rel="noopener noreferrer"
                  className="flex-1 p-4 bg-muted/30 rounded-lg border border-accent/20 hover:border-accent/40 transition-all hover:scale-105 flex items-center justify-center gap-2"
                >
                  <svg className="w-6 h-6" fill="currentColor" viewBox="0 0 24 24">
                    <path d="M12 0c-6.626 0-12 5.373-12 12 0 5.302 3.438 9.8 8.207 11.387.599.111.793-.261.793-.577v-2.234c-3.338.726-4.033-1.416-4.033-1.416-.546-1.387-1.333-1.756-1.333-1.756-1.089-.745.083-.729.083-.729 1.205.084 1.839 1.237 1.839 1.237 1.07 1.834 2.807 1.304 3.492.997.107-.775.418-1.305.762-1.604-2.665-.305-5.467-1.334-5.467-5.931 0-1.311.469-2.381 1.236-3.221-.124-.303-.535-1.524.117-3.176 0 0 1.008-.322 3.301 1.23.957-.266 1.983-.399 3.003-.404 1.02.005 2.047.138 3.006.404 2.291-1.552 3.297-1.23 3.297-1.23.653 1.653.242 2.874.118 3.176.77.84 1.235 1.911 1.235 3.221 0 4.609-2.807 5.624-5.479 5.921.43.372.823 1.102.823 2.222v3.293c0 .319.192.694.801.576 4.765-1.589 8.199-6.086 8.199-11.386 0-6.627-5.373-12-12-12z"/>
                  </svg>
                  <span className="text-sm font-medium">GitHub</span>
                </a>
              </div>
            </div>
          </div>
        </DialogContent>
      </Dialog>

      <Dialog open={mechanicsOpen} onOpenChange={setMechanicsOpen}>
        <DialogContent className="bg-black/95 border-primary/50 backdrop-blur-xl max-h-[90vh] overflow-y-auto">
          <DialogHeader>
            <DialogTitle className="text-2xl font-bold text-primary flex items-center gap-3">
              <Book className="w-7 h-7" weight="duotone" />
              Game Mechanics
            </DialogTitle>
            <DialogDescription className="text-foreground/80 text-base leading-relaxed pt-4">
              Discover the innovative gameplay systems, progression mechanics, and player-driven
              economy that define our next-generation gaming experience.
            </DialogDescription>
          </DialogHeader>
          <div className="space-y-4 pt-4">
            <div className="p-4 bg-muted/30 rounded-lg border border-accent/20 hover:border-accent/40 transition-colors">
              <h3 className="font-semibold text-accent mb-3 text-base">Core Gameplay Loop</h3>
              <p className="text-sm text-muted-foreground leading-relaxed mb-3">
                Engage in fast-paced strategic battles where every decision matters. Combine skill-based
                combat with tactical resource management to outmaneuver opponents.
              </p>
              <ul className="text-xs text-muted-foreground space-y-1.5 list-disc list-inside">
                <li>Real-time PvP and PvE combat encounters</li>
                <li>Dynamic ability combos with timing-based execution</li>
                <li>Environmental hazards and strategic positioning</li>
                <li>Match-based sessions with persistent meta-progression</li>
              </ul>
            </div>
            <div className="p-4 bg-muted/30 rounded-lg border border-accent/20 hover:border-accent/40 transition-colors">
              <h3 className="font-semibold text-accent mb-3 text-base">Progression & Upgrades</h3>
              <p className="text-sm text-muted-foreground leading-relaxed mb-3">
                Level up your character through multiple interconnected progression systems. Unlock
                powerful abilities, rare equipment, and exclusive cosmetics as you advance.
              </p>
              <ul className="text-xs text-muted-foreground space-y-1.5 list-disc list-inside">
                <li>Account level system with seasonal prestige ranks</li>
                <li>Character-specific skill trees and specializations</li>
                <li>Equipment rarity tiers: Common → Legendary</li>
                <li>Achievement-based unlocks and challenge missions</li>
              </ul>
            </div>
            <div className="p-4 bg-muted/30 rounded-lg border border-accent/20 hover:border-accent/40 transition-colors">
              <h3 className="font-semibold text-accent mb-3 text-base">Multiplayer & Social</h3>
              <p className="text-sm text-muted-foreground leading-relaxed mb-3">
                Team up with friends or compete against rivals in various multiplayer modes. Join
                guilds, participate in tournaments, and climb ranked leaderboards.
              </p>
              <ul className="text-xs text-muted-foreground space-y-1.5 list-disc list-inside">
                <li>Solo queue, duo, and full squad matchmaking</li>
                <li>Guild system with shared progression and battles</li>
                <li>Seasonal competitive leagues with exclusive rewards</li>
                <li>Spectator mode and replay system for matches</li>
              </ul>
            </div>
            <div className="p-4 bg-muted/30 rounded-lg border border-accent/20 hover:border-accent/40 transition-colors">
              <h3 className="font-semibold text-accent mb-3 text-base">Economy & NFT Integration</h3>
              <p className="text-sm text-muted-foreground leading-relaxed mb-3">
                True ownership of in-game assets through blockchain technology. Trade, sell, and
                collect rare items in a player-driven marketplace with transparent economics.
              </p>
              <ul className="text-xs text-muted-foreground space-y-1.5 list-disc list-inside">
                <li>Earn tokens through gameplay and tournaments</li>
                <li>Craft and mint unique NFT weapons and skins</li>
                <li>Peer-to-peer marketplace with low transaction fees</li>
                <li>Staking mechanisms for passive rewards and governance</li>
              </ul>
            </div>
            <div className="p-4 bg-gradient-to-br from-primary/20 to-accent/20 rounded-lg border border-primary/30">
              <h3 className="font-semibold text-primary mb-2 text-base">Launch Timeline</h3>
              <p className="text-sm text-foreground/90 leading-relaxed">
                <strong>Alpha Access:</strong> Q2 2024 | <strong>Open Beta:</strong> Q3 2024 | <strong>Full Launch:</strong> Q4 2024
              </p>
            </div>
          </div>
        </DialogContent>
      </Dialog>
    </div>
  )
}

export default App
