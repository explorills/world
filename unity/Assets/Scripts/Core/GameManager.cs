/**
 * GameManager.cs - ONE World Metaverse
 * 
 * Central game state manager and singleton for the ONE World lobby.
 * Handles initialization, scene management, and global game state.
 * 
 * @author EXPL / ONE Ecosystem
 * @version 0.1.0
 */

using UnityEngine;

namespace ONEWorld.Core
{
    /// <summary>
    /// Singleton GameManager - central control point for ONE World metaverse lobby.
    /// Persists across scene loads and manages global game state.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region Singleton
        
        private static GameManager _instance;
        
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<GameManager>();
                    
                    if (_instance == null)
                    {
                        GameObject go = new GameObject("GameManager");
                        _instance = go.AddComponent<GameManager>();
                    }
                }
                return _instance;
            }
        }
        
        #endregion
        
        #region Properties
        
        [Header("ONE World Configuration")]
        [SerializeField] private GameConfig gameConfig;
        
        [Header("Runtime State")]
        [SerializeField] private GameState currentState = GameState.Initializing;
        
        public GameConfig Config => gameConfig;
        public GameState CurrentState => currentState;
        
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
            
            Initialize();
        }
        
        private void Start()
        {
            TransitionToState(GameState.MainMenu);
        }
        
        #endregion
        
        #region Initialization
        
        private void Initialize()
        {
            Debug.Log("[ONE World] Initializing GameManager...");
            
            // Load configuration
            if (gameConfig == null)
            {
                gameConfig = Resources.Load<GameConfig>("Config/GameConfig");
            }
            
            // Initialize subsystems
            InitializeSubsystems();
            
            Debug.Log("[ONE World] GameManager initialized successfully.");
        }
        
        private void InitializeSubsystems()
        {
            // TODO: Initialize NetworkManager
            // TODO: Initialize AudioManager
            // TODO: Initialize UIManager
        }
        
        #endregion
        
        #region State Management
        
        public void TransitionToState(GameState newState)
        {
            if (currentState == newState) return;
            
            Debug.Log($"[ONE World] State transition: {currentState} -> {newState}");
            
            OnExitState(currentState);
            currentState = newState;
            OnEnterState(newState);
        }
        
        private void OnExitState(GameState state)
        {
            switch (state)
            {
                case GameState.Initializing:
                    break;
                case GameState.MainMenu:
                    break;
                case GameState.Lobby:
                    break;
                case GameState.InGame:
                    break;
            }
        }
        
        private void OnEnterState(GameState state)
        {
            switch (state)
            {
                case GameState.Initializing:
                    break;
                case GameState.MainMenu:
                    // TODO: Show main menu UI
                    break;
                case GameState.Lobby:
                    // TODO: Connect to lobby server
                    break;
                case GameState.InGame:
                    // TODO: Start gameplay
                    break;
            }
        }
        
        #endregion
        
        #region Public API
        
        public void EnterLobby()
        {
            TransitionToState(GameState.Lobby);
        }
        
        public void StartGame()
        {
            TransitionToState(GameState.InGame);
        }
        
        public void ReturnToMainMenu()
        {
            TransitionToState(GameState.MainMenu);
        }
        
        #endregion
    }
    
    /// <summary>
    /// Game state enumeration for ONE World metaverse.
    /// </summary>
    public enum GameState
    {
        Initializing,
        MainMenu,
        Lobby,
        InGame,
        Paused,
        Loading
    }
}
