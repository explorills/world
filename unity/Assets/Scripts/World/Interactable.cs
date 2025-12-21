/**
 * Interactable.cs - ONE World Metaverse
 * 
 * Base class for all interactable objects in the lobby.
 * 
 * @author EXPL / ONE Ecosystem
 * @version 0.1.0
 */

using System;
using UnityEngine;

namespace ONEWorld.World
{
    /// <summary>
    /// Base class for interactable objects in ONE World.
    /// </summary>
    public abstract class Interactable : MonoBehaviour
    {
        #region Settings
        
        [Header("Interaction")]
        [SerializeField] protected string interactionPrompt = "Press E to interact";
        [SerializeField] protected float interactionRange = 2f;
        [SerializeField] protected bool requiresWallet = false;
        
        [Header("Highlight")]
        [SerializeField] protected bool highlightOnHover = true;
        [SerializeField] protected Color highlightColor = new Color(0.93f, 0.29f, 0.60f); // Pink
        
        #endregion
        
        #region Properties
        
        public string Prompt => interactionPrompt;
        public float Range => interactionRange;
        public bool RequiresWallet => requiresWallet;
        
        protected bool isHighlighted;
        protected Renderer[] renderers;
        protected Color[] originalColors;
        
        #endregion
        
        #region Events
        
        public event Action OnInteracted;
        public event Action OnHoverEnter;
        public event Action OnHoverExit;
        
        #endregion
        
        #region Unity Lifecycle
        
        protected virtual void Awake()
        {
            renderers = GetComponentsInChildren<Renderer>();
            CacheOriginalColors();
        }
        
        protected virtual void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, interactionRange);
        }
        
        #endregion
        
        #region Highlight
        
        private void CacheOriginalColors()
        {
            originalColors = new Color[renderers.Length];
            for (int i = 0; i < renderers.Length; i++)
            {
                if (renderers[i].material.HasProperty("_Color"))
                {
                    originalColors[i] = renderers[i].material.color;
                }
            }
        }
        
        public virtual void SetHighlight(bool highlight)
        {
            if (!highlightOnHover || isHighlighted == highlight) return;
            
            isHighlighted = highlight;
            
            for (int i = 0; i < renderers.Length; i++)
            {
                if (renderers[i].material.HasProperty("_Color"))
                {
                    renderers[i].material.color = highlight ? highlightColor : originalColors[i];
                }
            }
            
            if (highlight)
                OnHoverEnter?.Invoke();
            else
                OnHoverExit?.Invoke();
        }
        
        #endregion
        
        #region Interaction
        
        /// <summary>
        /// Called when player interacts with this object.
        /// </summary>
        public virtual bool TryInteract(GameObject interactor)
        {
            if (requiresWallet)
            {
                var wallet = Network.WalletConnector.Instance;
                if (wallet == null || !wallet.IsConnected)
                {
                    Debug.Log("[ONE World] Wallet required for this interaction");
                    return false;
                }
            }
            
            OnInteract();
            OnInteracted?.Invoke();
            return true;
        }
        
        /// <summary>
        /// Override to implement custom interaction logic.
        /// </summary>
        protected abstract void OnInteract();
        
        #endregion
    }
    
    /// <summary>
    /// Simple interactable that logs a message.
    /// </summary>
    public class SimpleInteractable : Interactable
    {
        [Header("Simple Interaction")]
        [SerializeField] private string message = "Interacted!";
        
        protected override void OnInteract()
        {
            Debug.Log($"[ONE World] {message}");
        }
    }
}
