/**
 * LobbyEnvironment.cs - ONE World Metaverse
 * 
 * Controls the lobby environment, lighting, and atmosphere.
 * 
 * @author EXPL / ONE Ecosystem
 * @version 0.1.0
 */

using UnityEngine;

namespace ONEWorld.World
{
    /// <summary>
    /// Manages the ONE World lobby environment and atmosphere.
    /// </summary>
    public class LobbyEnvironment : MonoBehaviour
    {
        #region Settings
        
        [Header("Lighting")]
        [SerializeField] private Light mainLight;
        [SerializeField] private Color dayColor = new Color(1f, 0.95f, 0.9f);
        [SerializeField] private Color nightColor = new Color(0.4f, 0.5f, 0.8f);
        
        [Header("Skybox")]
        [SerializeField] private Material daySkybox;
        [SerializeField] private Material nightSkybox;
        
        [Header("Ambient")]
        [SerializeField] private Color dayAmbient = new Color(0.4f, 0.4f, 0.5f);
        [SerializeField] private Color nightAmbient = new Color(0.1f, 0.1f, 0.2f);
        
        [Header("Time Settings")]
        [SerializeField] private bool useRealTime = false;
        [SerializeField] [Range(0f, 24f)] private float timeOfDay = 12f;
        [SerializeField] private float dayLength = 600f; // seconds for full day cycle
        
        #endregion
        
        #region Properties
        
        public float TimeOfDay => timeOfDay;
        public bool IsDay => timeOfDay >= 6f && timeOfDay < 18f;
        
        #endregion
        
        #region Unity Lifecycle
        
        private void Start()
        {
            if (useRealTime)
            {
                timeOfDay = System.DateTime.Now.Hour + System.DateTime.Now.Minute / 60f;
            }
            
            UpdateEnvironment();
        }
        
        private void Update()
        {
            if (!useRealTime)
            {
                // Progress time
                timeOfDay += (24f / dayLength) * Time.deltaTime;
                if (timeOfDay >= 24f) timeOfDay -= 24f;
            }
            else
            {
                timeOfDay = System.DateTime.Now.Hour + System.DateTime.Now.Minute / 60f;
            }
            
            UpdateEnvironment();
        }
        
        #endregion
        
        #region Environment
        
        private void UpdateEnvironment()
        {
            float dayProgress = CalculateDayProgress();
            
            // Update main light
            if (mainLight != null)
            {
                mainLight.color = Color.Lerp(nightColor, dayColor, dayProgress);
                mainLight.intensity = Mathf.Lerp(0.2f, 1f, dayProgress);
                
                // Rotate sun based on time
                float sunAngle = (timeOfDay / 24f) * 360f - 90f;
                mainLight.transform.rotation = Quaternion.Euler(sunAngle, 170f, 0f);
            }
            
            // Update ambient
            RenderSettings.ambientLight = Color.Lerp(nightAmbient, dayAmbient, dayProgress);
        }
        
        private float CalculateDayProgress()
        {
            // Returns 0 at midnight, 1 at noon
            if (timeOfDay < 6f)
            {
                return timeOfDay / 6f * 0.3f; // 0 to 0.3 (early morning)
            }
            else if (timeOfDay < 12f)
            {
                return 0.3f + (timeOfDay - 6f) / 6f * 0.7f; // 0.3 to 1.0 (morning to noon)
            }
            else if (timeOfDay < 18f)
            {
                return 1f - (timeOfDay - 12f) / 6f * 0.3f; // 1.0 to 0.7 (afternoon)
            }
            else
            {
                return 0.7f - (timeOfDay - 18f) / 6f * 0.7f; // 0.7 to 0 (evening to night)
            }
        }
        
        #endregion
        
        #region Public API
        
        /// <summary>
        /// Set time of day instantly.
        /// </summary>
        public void SetTimeOfDay(float hour)
        {
            timeOfDay = Mathf.Clamp(hour, 0f, 24f);
            UpdateEnvironment();
        }
        
        /// <summary>
        /// Toggle between real-time and simulated time.
        /// </summary>
        public void SetUseRealTime(bool useReal)
        {
            useRealTime = useReal;
        }
        
        #endregion
    }
}
