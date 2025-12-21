/**
 * UIManager.cs - ONE World Metaverse
 * 
 * Central UI management system for the ONE World lobby.
 * Handles UI state, transitions, and global UI operations.
 * 
 * @author EXPL / ONE Ecosystem
 * @version 0.1.0
 */

using System;
using UnityEngine;

namespace ONEWorld.UI
{
    /// <summary>
    /// Singleton UIManager - manages all UI for ONE World metaverse.
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        #region Singleton
        
        private static UIManager _instance;
        public static UIManager Instance => _instance;
        
        #endregion
        
        #region References
        
        [Header("UI Panels")]
        [SerializeField] private GameObject mainMenuPanel;
        [SerializeField] private GameObject lobbyPanel;
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private GameObject loadingPanel;
        [SerializeField] private GameObject hudPanel;
        
        [Header("Loading")]
        [SerializeField] private CanvasGroup loadingCanvasGroup;
        
        #endregion
        
        #region Events
        
        public event Action OnMainMenuOpened;
        public event Action OnLobbyOpened;
        public event Action OnSettingsOpened;
        
        #endregion
        
        #region Properties
        
        private UIState currentState = UIState.None;
        public UIState CurrentState => currentState;
        
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
        }
        
        private void Start()
        {
            HideAllPanels();
        }
        
        #endregion
        
        #region Panel Management
        
        private void HideAllPanels()
        {
            SetPanelActive(mainMenuPanel, false);
            SetPanelActive(lobbyPanel, false);
            SetPanelActive(settingsPanel, false);
            SetPanelActive(loadingPanel, false);
            SetPanelActive(hudPanel, false);
        }
        
        private void SetPanelActive(GameObject panel, bool active)
        {
            if (panel != null)
            {
                panel.SetActive(active);
            }
        }
        
        #endregion
        
        #region Public API
        
        /// <summary>
        /// Show the main menu UI.
        /// </summary>
        public void ShowMainMenu()
        {
            HideAllPanels();
            SetPanelActive(mainMenuPanel, true);
            currentState = UIState.MainMenu;
            OnMainMenuOpened?.Invoke();
        }
        
        /// <summary>
        /// Show the lobby UI.
        /// </summary>
        public void ShowLobby()
        {
            HideAllPanels();
            SetPanelActive(lobbyPanel, true);
            SetPanelActive(hudPanel, true);
            currentState = UIState.Lobby;
            OnLobbyOpened?.Invoke();
        }
        
        /// <summary>
        /// Show settings panel as overlay.
        /// </summary>
        public void ShowSettings()
        {
            SetPanelActive(settingsPanel, true);
            OnSettingsOpened?.Invoke();
        }
        
        /// <summary>
        /// Hide settings panel.
        /// </summary>
        public void HideSettings()
        {
            SetPanelActive(settingsPanel, false);
        }
        
        /// <summary>
        /// Show loading screen.
        /// </summary>
        public void ShowLoading(string message = "Loading...")
        {
            SetPanelActive(loadingPanel, true);
            // TODO: Set loading message text
        }
        
        /// <summary>
        /// Hide loading screen.
        /// </summary>
        public void HideLoading()
        {
            SetPanelActive(loadingPanel, false);
        }
        
        #endregion
    }
    
    /// <summary>
    /// UI state enumeration.
    /// </summary>
    public enum UIState
    {
        None,
        MainMenu,
        Lobby,
        InGame
    }
}
