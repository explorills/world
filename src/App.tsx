import { useState } from 'react'
import {
  OneIdProvider,
  EcosystemNavbar,
  EcosystemContent,
  EcosystemFooter,
  getProjectByName,
} from '@explorills/one-ecosystem-ui'
import { VideoBackground } from '@/components/VideoBackground'
import { CornerButton } from '@/components/CornerButton'
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogDescription,
} from '@/components/ui/dialog'
import { Book } from '@phosphor-icons/react'
import logo from '@/assets/images/logo.png'
import bgMp4 from '@/assets/video/background.mp4'
import bgWebm from '@/assets/video/background.webm'
import bgPoster from '@/assets/video/poster.jpg'

// Reown / WalletConnect Cloud project ID — shared across the ONE ecosystem
// (same value one-id hardcodes). Powers the wallet/connect modal that
// OneIdProvider mounts internally.
const REOWN_PROJECT_ID = '1fe344d4623291d85ad7369cbc6d9ec8'

// world's identity (label + brand color) comes from the package registry —
// the single source of truth. The fallback keeps the page alive if a stale
// package build lacks the entry; world's identity is constant either way.
const world = getProjectByName('world') ?? {
  name: 'world',
  label: 'WORLD',
  url: 'https://world.expl.one',
  color: '#ec4899',
}

function App() {
  const [mechanicsOpen, setMechanicsOpen] = useState(false)

  return (
    <OneIdProvider
      projectId={REOWN_PROJECT_ID}
      projectName="world"
      platformColor={world.color}
      logo={logo}
    >
      {/* Background video — kept OUTSIDE EcosystemContent so it persists even
          during an under-construction takeover. */}
      <VideoBackground videoSrc={bgMp4} webmSrc={bgWebm} poster={bgPoster} />

      {/* Package top navbar — Resources dropdown + ONE ID connect/auth. */}
      <EcosystemNavbar
        logo={logo}
        projectName="world"
        themeColor={world.color}
        currentDomain="world.expl.one"
      />

      <EcosystemContent>
        {/* Center wordmark — absolute viewport center, mobile-first responsive.
            pointer-events-none so the full-screen layer never eats a click. */}
        <main className="fixed inset-0 z-0 flex flex-col items-center justify-center px-4 pointer-events-none">
          <h1
            className="font-bold leading-none tracking-tight text-[clamp(3.5rem,22vw,16rem)]"
            style={{ color: world.color, fontFamily: "'Space Grotesk', sans-serif" }}
          >
            {world.label}
          </h1>
          <p className="mt-2 sm:mt-4 uppercase tracking-[0.3em] text-foreground/70 text-[clamp(0.85rem,3vw,1.5rem)]">
            coming soon...
          </p>
        </main>

        {/* Mechanics — kept, moved to bottom-left and lifted above the footer
            bar (the package CHAT button owns the bottom-right corner). */}
        <CornerButton position="bottom-left" lifted onClick={() => setMechanicsOpen(true)}>
          <div className="flex items-center gap-2">
            <Book className="w-5 h-5" weight="duotone" />
            <span className="hidden sm:inline">Mechanics</span>
          </div>
        </CornerButton>

        <Dialog open={mechanicsOpen} onOpenChange={setMechanicsOpen}>
          <DialogContent className="bg-black/95 border-primary/50 backdrop-blur-xl max-w-[var(--modal-max-width-lg)]">
            <DialogHeader>
              <DialogTitle className="text-[length:var(--text-2xl)] font-bold text-primary flex items-center gap-2 sm:gap-3">
                <Book className="w-5 h-5 sm:w-7 sm:h-7 shrink-0" weight="duotone" />
                Game Mechanics
              </DialogTitle>
              <DialogDescription className="text-foreground/80 text-[length:var(--text-base)] leading-relaxed pt-2 sm:pt-4">
                Discover the innovative gameplay systems, progression mechanics, and player-driven
                economy that define our next-generation gaming experience.
              </DialogDescription>
            </DialogHeader>
            <div className="space-y-3 sm:space-y-4 pt-2 sm:pt-4">
              <div className="p-3 sm:p-4 bg-muted/30 rounded-lg border border-accent/20 hover:border-accent/40 transition-colors">
                <h3 className="font-semibold text-accent mb-2 sm:mb-3 text-[length:var(--text-base)]">Core Gameplay Loop</h3>
                <p className="text-[length:var(--text-sm)] text-muted-foreground leading-relaxed mb-2 sm:mb-3">
                  Engage in fast-paced strategic battles where every decision matters. Combine skill-based
                  combat with tactical resource management to outmaneuver opponents.
                </p>
                <ul className="text-[length:var(--text-xs)] text-muted-foreground space-y-1 sm:space-y-1.5 list-disc list-inside">
                  <li>Real-time PvP and PvE combat encounters</li>
                  <li>Dynamic ability combos with timing-based execution</li>
                  <li>Environmental hazards and strategic positioning</li>
                  <li>Match-based sessions with persistent meta-progression</li>
                </ul>
              </div>
              <div className="p-3 sm:p-4 bg-muted/30 rounded-lg border border-accent/20 hover:border-accent/40 transition-colors">
                <h3 className="font-semibold text-accent mb-2 sm:mb-3 text-[length:var(--text-base)]">Progression &amp; Upgrades</h3>
                <p className="text-[length:var(--text-sm)] text-muted-foreground leading-relaxed mb-2 sm:mb-3">
                  Level up your character through multiple interconnected progression systems. Unlock
                  powerful abilities, rare equipment, and exclusive cosmetics as you advance.
                </p>
                <ul className="text-[length:var(--text-xs)] text-muted-foreground space-y-1 sm:space-y-1.5 list-disc list-inside">
                  <li>Account level system with seasonal prestige ranks</li>
                  <li>Character-specific skill trees and specializations</li>
                  <li>Equipment rarity tiers: Common → Legendary</li>
                  <li>Achievement-based unlocks and challenge missions</li>
                </ul>
              </div>
              <div className="p-3 sm:p-4 bg-muted/30 rounded-lg border border-accent/20 hover:border-accent/40 transition-colors">
                <h3 className="font-semibold text-accent mb-2 sm:mb-3 text-[length:var(--text-base)]">Multiplayer &amp; Social</h3>
                <p className="text-[length:var(--text-sm)] text-muted-foreground leading-relaxed mb-2 sm:mb-3">
                  Team up with friends or compete against rivals in various multiplayer modes. Join
                  guilds, participate in tournaments, and climb ranked leaderboards.
                </p>
                <ul className="text-[length:var(--text-xs)] text-muted-foreground space-y-1 sm:space-y-1.5 list-disc list-inside">
                  <li>Solo queue, duo, and full squad matchmaking</li>
                  <li>Guild system with shared progression and battles</li>
                  <li>Seasonal competitive leagues with exclusive rewards</li>
                  <li>Spectator mode and replay system for matches</li>
                </ul>
              </div>
              <div className="p-3 sm:p-4 bg-muted/30 rounded-lg border border-accent/20 hover:border-accent/40 transition-colors">
                <h3 className="font-semibold text-accent mb-2 sm:mb-3 text-[length:var(--text-base)]">Economy &amp; NFT Integration</h3>
                <p className="text-[length:var(--text-sm)] text-muted-foreground leading-relaxed mb-2 sm:mb-3">
                  True ownership of in-game assets through blockchain technology. Trade, sell, and
                  collect rare items in a player-driven marketplace with transparent economics.
                </p>
                <ul className="text-[length:var(--text-xs)] text-muted-foreground space-y-1 sm:space-y-1.5 list-disc list-inside">
                  <li>Earn tokens through gameplay and tournaments</li>
                  <li>Craft and mint unique NFT weapons and skins</li>
                  <li>Peer-to-peer marketplace with low transaction fees</li>
                  <li>Staking mechanisms for passive rewards and governance</li>
                </ul>
              </div>
              <div className="p-3 sm:p-4 bg-gradient-to-br from-primary/20 to-accent/20 rounded-lg border border-primary/30">
                <h3 className="font-semibold text-primary mb-1.5 sm:mb-2 text-[length:var(--text-base)]">Launch Timeline 2026</h3>
                <p className="text-[length:var(--text-sm)] text-foreground/90 leading-relaxed">
                  <strong>Alpha Access:</strong> Q2 | <strong>Open Beta:</strong> Q3 | <strong>Full Launch:</strong> Q4
                </p>
              </div>
            </div>
          </DialogContent>
        </Dialog>
      </EcosystemContent>

      {/* Package footer — socials + EXPL.ONE + the floating CHAT button. */}
      <EcosystemFooter themeColor={world.color} currentDomain="world.expl.one" />
    </OneIdProvider>
  )
}

export default App
