/**
 * PoweredByExplNodes - Universal tagline component for ONE ecosystem
 * Customized for World game lobby with project theme colors (pink primary)
 */

import React from 'react'

interface PoweredByExplNodesProps {
  /** Size variant */
  size?: 'sm' | 'md' | 'lg' | 'xl'
  /** Additional CSS classes */
  className?: string
  /** Link URL */
  href?: string
  /** Open in new tab */
  newTab?: boolean
}

export function PoweredByExplNodes({
  size = 'lg',
  className = '',
  href = 'https://node.expl.one',
  newTab = true,
}: PoweredByExplNodesProps) {
  const [isHovered, setIsHovered] = React.useState(false)
  
  // Size variants with responsive clamp values for game lobby (bigger than standard)
  const sizeStyles = {
    sm: {
      fontSize: 'clamp(0.625rem, 2vw, 0.75rem)',
      paddingX: 'clamp(0.5rem, 2vw, 0.75rem)',
      paddingY: 'clamp(0.25rem, 1vw, 0.375rem)',
      borderRadius: '4px',
    },
    md: {
      fontSize: 'clamp(0.75rem, 2.5vw, 0.875rem)',
      paddingX: 'clamp(0.75rem, 3vw, 1rem)',
      paddingY: 'clamp(0.375rem, 1.5vw, 0.5rem)',
      borderRadius: '6px',
    },
    lg: {
      fontSize: 'clamp(0.875rem, 3vw, 1rem)',
      paddingX: 'clamp(1rem, 4vw, 1.25rem)',
      paddingY: 'clamp(0.5rem, 2vw, 0.625rem)',
      borderRadius: '8px',
    },
    xl: {
      fontSize: 'clamp(1rem, 3.5vw, 1.125rem)',
      paddingX: 'clamp(1.25rem, 5vw, 1.5rem)',
      paddingY: 'clamp(0.625rem, 2.5vw, 0.75rem)',
      borderRadius: '10px',
    },
  }[size]
  
  const baseStyles: React.CSSProperties = {
    // Display
    display: 'inline-flex',
    alignItems: 'center',
    whiteSpace: 'nowrap',
    
    // Typography - Roboto Mono for code aesthetic
    fontFamily: "'Roboto Mono', ui-monospace, SFMono-Regular, 'SF Mono', Menlo, Consolas, monospace",
    fontSize: sizeStyles.fontSize,
    fontWeight: 400,
    color: '#ffffff',
    textDecoration: 'none',
    
    // Spacing
    padding: `${sizeStyles.paddingY} ${sizeStyles.paddingX}`,
    
    // Background & Border - using project theme colors (pink primary)
    backgroundColor: isHovered ? 'oklch(0.15 0 0 / 0.9)' : 'oklch(0.15 0 0 / 0.95)',
    border: '1px solid oklch(0.62 0.25 340)', // primary pink
    borderRadius: sizeStyles.borderRadius,
    
    // 3D Effect & Shadow with pink glow
    boxShadow: isHovered 
      ? '0 4px 8px rgba(0,0,0,0.4), 0 0 16px oklch(0.62 0.25 340 / 0.5), inset 0 1px 0 rgba(255,255,255,0.15)'
      : '0 2px 4px rgba(0,0,0,0.3), inset 0 1px 0 rgba(255,255,255,0.1)',
    
    // Transform for 3D lift effect
    transform: isHovered ? 'translateY(-2px) scale(1.05)' : 'translateY(0) scale(1)',
    
    // Transitions
    transition: 'all 300ms cubic-bezier(0.4, 0, 0.2, 1)',
    
    // Interaction
    cursor: 'pointer',
    
    // GPU acceleration
    willChange: 'transform',
    backfaceVisibility: 'hidden',
  }

  return (
    <a
      href={href}
      target={newTab ? '_blank' : undefined}
      rel={newTab ? 'noopener noreferrer' : undefined}
      style={baseStyles}
      className={className}
      onMouseEnter={() => setIsHovered(true)}
      onMouseLeave={() => setIsHovered(false)}
    >
      // Powered by EXPL Nodes
    </a>
  )
}

export default PoweredByExplNodes
