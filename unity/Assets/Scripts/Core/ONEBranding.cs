/**
 * ONEBranding.cs - ONE World Metaverse
 * 
 * Brand constants and color definitions for the ONE ecosystem.
 * Reference for consistent branding across all components.
 * 
 * @author EXPL / ONE Ecosystem
 * @version 0.1.0
 */

using UnityEngine;

namespace ONEWorld.Core
{
    /// <summary>
    /// Brand constants for ONE World metaverse.
    /// </summary>
    public static class ONEBranding
    {
        #region Product Info
        
        public const string PRODUCT_NAME = "ONE World";
        public const string COMPANY_NAME = "EXPL";
        public const string ECOSYSTEM_NAME = "ONE Ecosystem";
        
        #endregion
        
        #region URLs
        
        public const string URL_MAIN = "https://expl.one";
        public const string URL_WORLD = "https://world.expl.one";
        public const string URL_NODES = "https://node.expl.one";
        public const string URL_DOCS = "https://docs.expl.one";
        public const string URL_GITHUB = "https://github.com/explorills";
        public const string URL_X = "https://x.com/explorills_main";
        public const string URL_DISCORD = "https://discord.gg/explorills";
        
        #endregion
        
        #region Colors - Primary Palette
        
        /// <summary>
        /// Primary pink color: #ec4899 / oklch(0.62 0.25 340)
        /// </summary>
        public static readonly Color Primary = new Color(0.925f, 0.282f, 0.600f);
        
        /// <summary>
        /// Accent blue color: oklch(0.75 0.15 200)
        /// </summary>
        public static readonly Color Accent = new Color(0.561f, 0.773f, 0.929f);
        
        /// <summary>
        /// Background dark: oklch(0.1 0 0)
        /// </summary>
        public static readonly Color Background = new Color(0.067f, 0.067f, 0.067f);
        
        /// <summary>
        /// Foreground light: oklch(0.98 0 0)
        /// </summary>
        public static readonly Color Foreground = new Color(0.965f, 0.965f, 0.965f);
        
        /// <summary>
        /// Card background: oklch(0.15 0 0)
        /// </summary>
        public static readonly Color Card = new Color(0.110f, 0.110f, 0.110f);
        
        /// <summary>
        /// Muted text: oklch(0.65 0 0)
        /// </summary>
        public static readonly Color MutedForeground = new Color(0.467f, 0.467f, 0.467f);
        
        /// <summary>
        /// Border color: oklch(0.25 0 0)
        /// </summary>
        public static readonly Color Border = new Color(0.184f, 0.184f, 0.184f);
        
        #endregion
        
        #region Colors - Extended Palette
        
        /// <summary>
        /// Success green
        /// </summary>
        public static readonly Color Success = new Color(0.298f, 0.686f, 0.314f);
        
        /// <summary>
        /// Warning yellow
        /// </summary>
        public static readonly Color Warning = new Color(1f, 0.757f, 0.027f);
        
        /// <summary>
        /// Error/destructive red
        /// </summary>
        public static readonly Color Error = new Color(0.898f, 0.224f, 0.208f);
        
        #endregion
        
        #region Tags
        
        public const string TAG_PLAYER = "Player";
        public const string TAG_INTERACTABLE = "Interactable";
        public const string TAG_SPAWN_POINT = "SpawnPoint";
        public const string TAG_PORTAL = "Portal";
        
        #endregion
        
        #region Layers
        
        public const string LAYER_DEFAULT = "Default";
        public const string LAYER_PLAYER = "Player";
        public const string LAYER_INTERACTABLE = "Interactable";
        public const string LAYER_UI = "UI";
        public const string LAYER_GROUND = "Ground";
        
        #endregion
        
        #region Analytics
        
        public const string GA_MEASUREMENT_ID = "G-3NM3XM3TX2";
        
        #endregion
    }
}
