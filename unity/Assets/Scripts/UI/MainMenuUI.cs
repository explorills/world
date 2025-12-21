/**
 * MainMenuUI.cs - ONE World Metaverse
 * 
 * Main menu user interface controller.
 * 
 * @author EXPL / ONE Ecosystem
 * @version 0.1.0
 */

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ONEWorld.Core;
using ONEWorld.Network;

namespace ONEWorld.UI
{
    /// <summary>
    /// Main menu UI controller for ONE World.
    /// </summary>
    public class MainMenuUI : MonoBehaviour
    {
        #region References
        
        [Header("Buttons")]
        [SerializeField] private Button playButton;
        [SerializeField] private Button connectWalletButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button quitButton;
        
        [Header("Text")]
        [SerializeField] private TMP_Text versionText;
        [SerializeField] private TMP_Text walletAddressText;
        
        [Header("Panels")]
        [SerializeField] private GameObject walletConnectedPanel;
        [SerializeField] private GameObject walletDisconnectedPanel;
        
        #endregion
        
        #region Unity Lifecycle
        
        private void Start()
        {
            SetupButtons();
            UpdateWalletUI();
            UpdateVersionText();
            
            // Subscribe to wallet events
            if (WalletConnector.Instance != null)
            {
                WalletConnector.Instance.OnWalletConnected += OnWalletConnected;
                WalletConnector.Instance.OnWalletDisconnected += OnWalletDisconnected;
            }
        }
        
        private void OnDestroy()
        {
            if (WalletConnector.Instance != null)
            {
                WalletConnector.Instance.OnWalletConnected -= OnWalletConnected;
                WalletConnector.Instance.OnWalletDisconnected -= OnWalletDisconnected;
            }
        }
        
        #endregion
        
        #region Setup
        
        private void SetupButtons()
        {
            playButton?.onClick.AddListener(OnPlayClicked);
            connectWalletButton?.onClick.AddListener(OnConnectWalletClicked);
            settingsButton?.onClick.AddListener(OnSettingsClicked);
            quitButton?.onClick.AddListener(OnQuitClicked);
        }
        
        private void UpdateVersionText()
        {
            if (versionText != null && GameManager.Instance?.Config != null)
            {
                versionText.text = $"v{GameManager.Instance.Config.version}";
            }
        }
        
        private void UpdateWalletUI()
        {
            bool isConnected = WalletConnector.Instance?.IsConnected ?? false;
            
            if (walletConnectedPanel != null)
                walletConnectedPanel.SetActive(isConnected);
                
            if (walletDisconnectedPanel != null)
                walletDisconnectedPanel.SetActive(!isConnected);
                
            if (walletAddressText != null && isConnected)
                walletAddressText.text = WalletConnector.Instance.ShortAddress;
        }
        
        #endregion
        
        #region Button Handlers
        
        private void OnPlayClicked()
        {
            Debug.Log("[ONE World UI] Play clicked");
            GameManager.Instance?.EnterLobby();
        }
        
        private void OnConnectWalletClicked()
        {
            Debug.Log("[ONE World UI] Connect wallet clicked");
            WalletConnector.Instance?.Connect();
        }
        
        private void OnSettingsClicked()
        {
            Debug.Log("[ONE World UI] Settings clicked");
            UIManager.Instance?.ShowSettings();
        }
        
        private void OnQuitClicked()
        {
            Debug.Log("[ONE World UI] Quit clicked");
            
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
        
        #endregion
        
        #region Wallet Events
        
        private void OnWalletConnected(string address)
        {
            UpdateWalletUI();
        }
        
        private void OnWalletDisconnected()
        {
            UpdateWalletUI();
        }
        
        #endregion
    }
}
