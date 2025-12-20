import { Button } from '@/components/ui/button'
import { motion } from 'framer-motion'

interface ConnectButtonProps {
  onClick?: () => void
}

export function ConnectButton({ onClick }: ConnectButtonProps) {
  return (
    <motion.div
      whileHover={{ scale: 1.05 }}
      whileTap={{ scale: 0.98 }}
      className="relative"
    >
      <Button
        onClick={onClick}
        className="relative px-[var(--btn-padding-x)] py-[var(--btn-padding-y)] text-[length:var(--btn-font-size)] font-bold tracking-wider uppercase bg-primary text-primary-foreground rounded-lg overflow-hidden group"
        style={{
          transformStyle: 'preserve-3d',
          boxShadow: `
            0 4px 12px rgba(236, 72, 153, 0.4),
            0 8px 24px rgba(236, 72, 153, 0.3),
            0 0 40px rgba(236, 72, 153, 0.2)
          `
        }}
      >
        <span className="relative z-10">Connect</span>
        <div className="absolute inset-0 bg-gradient-to-t from-black/20 to-transparent opacity-0 group-hover:opacity-100 transition-opacity duration-300" />
        <motion.div
          className="absolute inset-0 bg-accent/20"
          animate={{
            opacity: [0.2, 0.4, 0.2],
          }}
          transition={{
            duration: 2,
            repeat: Infinity,
            ease: 'easeInOut',
          }}
        />
      </Button>
    </motion.div>
  )
}
