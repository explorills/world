/**
 * NetworkManager.cs - ONE World Metaverse
 * 
 * Handles all network connectivity for the ONE World lobby.
 * Manages WebSocket connections, player synchronization, and lobby state.
 * 
 * @author EXPL / ONE Ecosystem
 * @version 0.1.0
 */

using System;
using UnityEngine;

namespace ONEWorld.Network
{
    /// <summary>
    /// Singleton NetworkManager - handles all multiplayer networking for ONE World.
    /// Manages lobby connections, player state sync, and real-time communication.
    /// </summary>
    public class NetworkManager : MonoBehaviour
    {
        #region Singleton
        
        private static NetworkManager _instance;
        public static NetworkManager Instance => _instance;
        
        #endregion
        
        #region Events
        
        public event Action OnConnected;
        public event Action OnDisconnected;
        public event Action<string> OnConnectionError;
        public event Action<PlayerData> OnPlayerJoined;
        public event Action<string> OnPlayerLeft;
        
        #endregion
        
        #region Properties
        
        [Header("Connection Status")]
        [SerializeField] private ConnectionState connectionState = ConnectionState.Disconnected;
        [SerializeField] private string currentLobbyId;
        
        public ConnectionState State => connectionState;
        public string CurrentLobbyId => currentLobbyId;
        public bool IsConnected => connectionState == ConnectionState.Connected;
        
        #endregion
        
        #region Unity Lifecycle
        
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        #endregion
        
        #region Connection Management
        
        /// <summary>
        /// Connect to the ONE World lobby server.
        /// </summary>
        public void Connect()
        {
            if (connectionState == ConnectionState.Connecting || 
                connectionState == ConnectionState.Connected)
            {
                Debug.LogWarning("[ONE World Network] Already connected or connecting.");
                return;
            }
            
            Debug.Log("[ONE World Network] Connecting to lobby server...");
            connectionState = ConnectionState.Connecting;
            
            // TODO: Implement WebSocket connection
            // For now, simulate connection
            Invoke(nameof(SimulateConnection), 1f);
        }
        
        /// <summary>
        /// Disconnect from the lobby server.
        /// </summary>
        public void Disconnect()
        {
            if (connectionState == ConnectionState.Disconnected)
            {
                return;
            }
            
            Debug.Log("[ONE World Network] Disconnecting from lobby server...");
            
            // TODO: Implement proper disconnection
            connectionState = ConnectionState.Disconnected;
            currentLobbyId = null;
            
            OnDisconnected?.Invoke();
        }
        
        private void SimulateConnection()
        {
            connectionState = ConnectionState.Connected;
            currentLobbyId = Guid.NewGuid().ToString().Substring(0, 8);
            
            Debug.Log($"[ONE World Network] Connected to lobby: {currentLobbyId}");
            OnConnected?.Invoke();
        }
        
        #endregion
        
        #region Player Sync
        
        /// <summary>
        /// Send local player position to server.
        /// </summary>
        public void SendPlayerPosition(Vector3 position, Quaternion rotation)
        {
            if (!IsConnected) return;
            
            // TODO: Implement position sync
        }
        
        /// <summary>
        /// Send player action to server.
        /// </summary>
        public void SendPlayerAction(string actionType, string payload)
        {
            if (!IsConnected) return;
            
            // TODO: Implement action sync
        }
        
        #endregion
    }
    
    /// <summary>
    /// Network connection state.
    /// </summary>
    public enum ConnectionState
    {
        Disconnected,
        Connecting,
        Connected,
        Reconnecting,
        Error
    }
    
    /// <summary>
    /// Network player data structure.
    /// </summary>
    [Serializable]
    public class PlayerData
    {
        public string playerId;
        public string displayName;
        public string walletAddress;
        public Vector3 position;
        public Quaternion rotation;
        public string avatarId;
    }
}
