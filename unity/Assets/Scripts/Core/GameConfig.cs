/**
 * GameConfig.cs - ONE World Metaverse
 * 
 * ScriptableObject configuration asset for global game settings.
 * Create via: Assets > Create > ONE World > Game Config
 * 
 * @author EXPL / ONE Ecosystem
 * @version 0.1.0
 */

using UnityEngine;

namespace ONEWorld.Core
{
    /// <summary>
    /// Global configuration ScriptableObject for ONE World metaverse.
    /// Stores all configurable game parameters in a single asset.
    /// </summary>
    [CreateAssetMenu(fileName = "GameConfig", menuName = "ONE World/Game Config", order = 0)]
    public class GameConfig : ScriptableObject
    {
        #region Branding
        
        [Header("ONE World Branding")]
        [Tooltip("Game title displayed in UI")]
        public string gameTitle = "ONE World";
        
        [Tooltip("Game version string")]
        public string version = "0.1.0-alpha";
        
        [Tooltip("Build identifier for tracking")]
        public string buildId = "dev";
        
        #endregion
        
        #region Network
        
        [Header("Network Configuration")]
        [Tooltip("Primary lobby server endpoint")]
        public string lobbyServerUrl = "wss://lobby.expl.one";
        
        [Tooltip("Fallback server endpoint")]
        public string fallbackServerUrl = "wss://lobby-backup.expl.one";
        
        [Tooltip("Connection timeout in seconds")]
        public float connectionTimeout = 30f;
        
        [Tooltip("Maximum reconnection attempts")]
        public int maxReconnectAttempts = 5;
        
        #endregion
        
        #region Gameplay
        
        [Header("Gameplay Settings")]
        [Tooltip("Maximum players per lobby")]
        public int maxPlayersPerLobby = 100;
        
        [Tooltip("Player movement speed")]
        public float playerMoveSpeed = 5f;
        
        [Tooltip("Player rotation speed")]
        public float playerRotateSpeed = 180f;
        
        #endregion
        
        #region Audio
        
        [Header("Audio Defaults")]
        [Range(0f, 1f)]
        public float masterVolume = 1f;
        
        [Range(0f, 1f)]
        public float musicVolume = 0.7f;
        
        [Range(0f, 1f)]
        public float sfxVolume = 1f;
        
        #endregion
        
        #region Graphics
        
        [Header("Graphics Defaults")]
        [Tooltip("Target frame rate (0 = unlimited)")]
        public int targetFrameRate = 60;
        
        [Tooltip("Enable VSync")]
        public bool vSyncEnabled = true;
        
        #endregion
        
        #region Debug
        
        [Header("Debug Options")]
        [Tooltip("Enable debug logging")]
        public bool debugMode = true;
        
        [Tooltip("Show FPS counter")]
        public bool showFpsCounter = false;
        
        [Tooltip("Enable developer console")]
        public bool enableDevConsole = true;
        
        #endregion
    }
}
