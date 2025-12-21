/**
 * PortalVFX.cs - ONE World Metaverse
 * 
 * Portal visual effect controller for world transitions.
 * 
 * @author EXPL / ONE Ecosystem
 * @version 0.1.0
 */

using System;
using UnityEngine;

namespace ONEWorld.VFX
{
    /// <summary>
    /// Controls portal visual effects for world/zone transitions.
    /// </summary>
    public class PortalVFX : MonoBehaviour
    {
        #region Settings
        
        [Header("Portal Settings")]
        [SerializeField] private float rotationSpeed = 30f;
        [SerializeField] private float pulseSpeed = 1f;
        [SerializeField] private float pulseIntensity = 0.2f;
        
        [Header("Colors")]
        [SerializeField] private Color primaryColor = new Color(0.93f, 0.29f, 0.60f); // Pink #ec4899
        [SerializeField] private Color secondaryColor = new Color(0.56f, 0.77f, 0.93f); // Accent blue
        
        [Header("References")]
        [SerializeField] private Transform portalRing;
        [SerializeField] private ParticleSystem portalParticles;
        [SerializeField] private Light portalLight;
        
        #endregion
        
        #region Events
        
        public event Action OnPortalEntered;
        
        #endregion
        
        #region State
        
        private bool isActive = true;
        private float baseIntensity;
        private Vector3 baseScale;
        
        #endregion
        
        #region Unity Lifecycle
        
        private void Start()
        {
            if (portalLight != null)
            {
                baseIntensity = portalLight.intensity;
                portalLight.color = primaryColor;
            }
            
            baseScale = transform.localScale;
        }
        
        private void Update()
        {
            if (!isActive) return;
            
            // Rotate portal ring
            if (portalRing != null)
            {
                portalRing.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            }
            
            // Pulse effect
            float pulse = 1f + Mathf.Sin(Time.time * pulseSpeed) * pulseIntensity;
            transform.localScale = baseScale * pulse;
            
            if (portalLight != null)
            {
                portalLight.intensity = baseIntensity * pulse;
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnPlayerEnterPortal(other.gameObject);
            }
        }
        
        #endregion
        
        #region Portal Logic
        
        private void OnPlayerEnterPortal(GameObject player)
        {
            Debug.Log("[ONE World VFX] Player entered portal");
            OnPortalEntered?.Invoke();
            
            // TODO: Trigger transition effect
            // TODO: Load destination scene/zone
        }
        
        #endregion
        
        #region Public API
        
        /// <summary>
        /// Activate the portal.
        /// </summary>
        public void Activate()
        {
            isActive = true;
            portalParticles?.Play();
            
            if (portalLight != null)
                portalLight.enabled = true;
        }
        
        /// <summary>
        /// Deactivate the portal.
        /// </summary>
        public void Deactivate()
        {
            isActive = false;
            portalParticles?.Stop();
            
            if (portalLight != null)
                portalLight.enabled = false;
        }
        
        /// <summary>
        /// Set portal colors.
        /// </summary>
        public void SetColors(Color primary, Color secondary)
        {
            primaryColor = primary;
            secondaryColor = secondary;
            
            if (portalLight != null)
                portalLight.color = primaryColor;
                
            // TODO: Update material colors
            // TODO: Update particle colors
        }
        
        #endregion
    }
}
