/**
 * WalletConnector.cs - ONE World Metaverse
 * 
 * Handles blockchain wallet connection for the ONE ecosystem.
 * Integrates with web3 providers for authentication and asset ownership.
 * 
 * @author EXPL / ONE Ecosystem
 * @version 0.1.0
 */

using System;
using UnityEngine;

namespace ONEWorld.Network
{
    /// <summary>
    /// Wallet connection manager for ONE World metaverse.
    /// Handles Solana wallet integration for the ONE ecosystem.
    /// </summary>
    public class WalletConnector : MonoBehaviour
    {
        #region Singleton
        
        private static WalletConnector _instance;
        public static WalletConnector Instance => _instance;
        
        #endregion
        
        #region Events
        
        public event Action<string> OnWalletConnected;
        public event Action OnWalletDisconnected;
        public event Action<string> OnConnectionError;
        
        #endregion
        
        #region Properties
        
        [Header("Wallet State")]
        [SerializeField] private WalletState walletState = WalletState.Disconnected;
        [SerializeField] private string connectedAddress;
        
        public WalletState State => walletState;
        public string Address => connectedAddress;
        public bool IsConnected => walletState == WalletState.Connected;
        
        /// <summary>
        /// Returns shortened wallet address (e.g., "7xKX...4f2D")
        /// </summary>
        public string ShortAddress
        {
            get
            {
                if (string.IsNullOrEmpty(connectedAddress) || connectedAddress.Length < 8)
                    return connectedAddress;
                    
                return $"{connectedAddress.Substring(0, 4)}...{connectedAddress.Substring(connectedAddress.Length - 4)}";
            }
        }
        
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
        
        #region Connection
        
        /// <summary>
        /// Initiate wallet connection.
        /// </summary>
        public void Connect()
        {
            if (walletState == WalletState.Connecting || walletState == WalletState.Connected)
            {
                Debug.LogWarning("[ONE World Wallet] Already connected or connecting.");
                return;
            }
            
            Debug.Log("[ONE World Wallet] Initiating wallet connection...");
            walletState = WalletState.Connecting;
            
            // TODO: Implement actual wallet connection
            // This will use JavaScript interop for WebGL builds
            // or native SDK for mobile/desktop
            
            #if UNITY_WEBGL && !UNITY_EDITOR
            // Call JavaScript wallet adapter
            // Application.ExternalCall("connectWallet");
            #else
            // Simulate connection for development
            Invoke(nameof(SimulateConnection), 1.5f);
            #endif
        }
        
        /// <summary>
        /// Disconnect wallet.
        /// </summary>
        public void Disconnect()
        {
            if (walletState == WalletState.Disconnected)
            {
                return;
            }
            
            Debug.Log("[ONE World Wallet] Disconnecting wallet...");
            
            connectedAddress = null;
            walletState = WalletState.Disconnected;
            
            OnWalletDisconnected?.Invoke();
        }
        
        private void SimulateConnection()
        {
            // Generate fake Solana-style address for development
            connectedAddress = GenerateFakeAddress();
            walletState = WalletState.Connected;
            
            Debug.Log($"[ONE World Wallet] Connected: {ShortAddress}");
            OnWalletConnected?.Invoke(connectedAddress);
        }
        
        private string GenerateFakeAddress()
        {
            const string chars = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
            char[] address = new char[44];
            
            for (int i = 0; i < 44; i++)
            {
                address[i] = chars[UnityEngine.Random.Range(0, chars.Length)];
            }
            
            return new string(address);
        }
        
        #endregion
        
        #region JavaScript Callbacks (WebGL)
        
        /// <summary>
        /// Called from JavaScript when wallet connects successfully.
        /// </summary>
        public void OnWalletConnectSuccess(string address)
        {
            connectedAddress = address;
            walletState = WalletState.Connected;
            
            Debug.Log($"[ONE World Wallet] Connected: {ShortAddress}");
            OnWalletConnected?.Invoke(connectedAddress);
        }
        
        /// <summary>
        /// Called from JavaScript when wallet connection fails.
        /// </summary>
        public void OnWalletConnectError(string error)
        {
            walletState = WalletState.Disconnected;
            
            Debug.LogError($"[ONE World Wallet] Connection error: {error}");
            OnConnectionError?.Invoke(error);
        }
        
        #endregion
    }
    
    /// <summary>
    /// Wallet connection state.
    /// </summary>
    public enum WalletState
    {
        Disconnected,
        Connecting,
        Connected
    }
}
