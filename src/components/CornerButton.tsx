import { ReactNode } from 'react'
import { motion } from 'framer-motion'

interface CornerButtonProps {
  position: 'top-left' | 'top-right' | 'bottom-left' | 'bottom-right'
  children: ReactNode
  onClick?: () => void
  disabled?: boolean
  /** Lift a bottom corner ~64px off the edge so it clears the package
   *  EcosystemFooter bar — pairs it visually with the package CHAT
   *  button on the opposite bottom corner. */
  lifted?: boolean
  className?: string
}

export function CornerButton({ position, children, onClick, disabled, lifted = false, className = '' }: CornerButtonProps) {
  const bottomClass = lifted ? 'bottom-16' : 'bottom-[var(--corner-inset)]'
  const positionClasses = {
    'top-left': 'top-[var(--corner-inset)] left-[var(--corner-inset)]',
    'top-right': 'top-[var(--corner-inset)] right-[var(--corner-inset)]',
    'bottom-left': `${bottomClass} left-[var(--corner-inset)]`,
    'bottom-right': `${bottomClass} right-[var(--corner-inset)]`,
  }

  return (
    <motion.button
      whileHover={!disabled ? { scale: 1.05 } : {}}
      whileTap={!disabled ? { scale: 0.95 } : {}}
      onClick={onClick}
      disabled={disabled}
      className={`
        fixed ${positionClasses[position]} ${lifted ? 'z-50' : 'z-40'}
        px-[var(--corner-padding-x)] py-[var(--corner-padding-y)]
        bg-black/70 backdrop-blur-md
        border border-primary/30
        rounded-lg
        text-foreground text-[length:var(--text-sm)] font-medium tracking-wide
        transition-all duration-200
        cursor-pointer
        hover:bg-black/80 hover:border-primary/60
        disabled:opacity-50 disabled:cursor-not-allowed
        shadow-lg shadow-primary/10
        ${className}
      `}
    >
      {children}
    </motion.button>
  )
}
