import { ReactNode } from 'react'
import { motion } from 'framer-motion'

interface CornerButtonProps {
  position: 'top-left' | 'top-right' | 'bottom-left' | 'bottom-right'
  children: ReactNode
  onClick?: () => void
  disabled?: boolean
}

export function CornerButton({ position, children, onClick, disabled }: CornerButtonProps) {
  const positionClasses = {
    'top-left': 'top-6 left-6 sm:top-6 sm:left-6',
    'top-right': 'top-6 right-6 sm:top-6 sm:right-6',
    'bottom-left': 'bottom-6 left-6 sm:bottom-6 sm:left-6',
    'bottom-right': 'bottom-6 right-6 sm:bottom-6 sm:right-6',
  }

  return (
    <motion.button
      whileHover={!disabled ? { scale: 1.05 } : {}}
      whileTap={!disabled ? { scale: 0.95 } : {}}
      onClick={onClick}
      disabled={disabled}
      className={`
        fixed ${positionClasses[position]} z-40
        px-4 py-3 sm:px-6 sm:py-3
        bg-black/70 backdrop-blur-md
        border border-primary/30
        rounded-lg
        text-foreground text-sm sm:text-base font-medium tracking-wide
        transition-all duration-200
        hover:bg-black/80 hover:border-primary/60
        disabled:opacity-50 disabled:cursor-not-allowed
        shadow-lg shadow-primary/10
      `}
    >
      {children}
    </motion.button>
  )
}
