/**
 * AudioManager.cs - ONE World Metaverse
 * 
 * Central audio management system for music, SFX, and ambient sounds.
 * 
 * @author EXPL / ONE Ecosystem
 * @version 0.1.0
 */

using UnityEngine;
using UnityEngine.Audio;

namespace ONEWorld.Audio
{
    /// <summary>
    /// Singleton AudioManager - manages all audio for ONE World metaverse.
    /// </summary>
    public class AudioManager : MonoBehaviour
    {
        #region Singleton
        
        private static AudioManager _instance;
        public static AudioManager Instance => _instance;
        
        #endregion
        
        #region References
        
        [Header("Audio Mixer")]
        [SerializeField] private AudioMixer masterMixer;
        
        [Header("Audio Sources")]
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource ambientSource;
        [SerializeField] private AudioSource sfxSource;
        
        [Header("Default Clips")]
        [SerializeField] private AudioClip lobbyMusic;
        [SerializeField] private AudioClip lobbyAmbient;
        
        #endregion
        
        #region Settings
        
        private const string MASTER_VOLUME = "MasterVolume";
        private const string MUSIC_VOLUME = "MusicVolume";
        private const string SFX_VOLUME = "SFXVolume";
        
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
        
        private void Start()
        {
            LoadVolumeSettings();
        }
        
        #endregion
        
        #region Volume Control
        
        /// <summary>
        /// Set master volume (0-1).
        /// </summary>
        public void SetMasterVolume(float volume)
        {
            SetMixerVolume(MASTER_VOLUME, volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME, volume);
        }
        
        /// <summary>
        /// Set music volume (0-1).
        /// </summary>
        public void SetMusicVolume(float volume)
        {
            SetMixerVolume(MUSIC_VOLUME, volume);
            PlayerPrefs.SetFloat(MUSIC_VOLUME, volume);
        }
        
        /// <summary>
        /// Set SFX volume (0-1).
        /// </summary>
        public void SetSFXVolume(float volume)
        {
            SetMixerVolume(SFX_VOLUME, volume);
            PlayerPrefs.SetFloat(SFX_VOLUME, volume);
        }
        
        private void SetMixerVolume(string parameter, float volume)
        {
            if (masterMixer != null)
            {
                // Convert linear 0-1 to logarithmic dB scale
                float dB = volume > 0 ? Mathf.Log10(volume) * 20f : -80f;
                masterMixer.SetFloat(parameter, dB);
            }
        }
        
        private void LoadVolumeSettings()
        {
            SetMasterVolume(PlayerPrefs.GetFloat(MASTER_VOLUME, 1f));
            SetMusicVolume(PlayerPrefs.GetFloat(MUSIC_VOLUME, 0.7f));
            SetSFXVolume(PlayerPrefs.GetFloat(SFX_VOLUME, 1f));
        }
        
        #endregion
        
        #region Playback
        
        /// <summary>
        /// Play background music with crossfade.
        /// </summary>
        public void PlayMusic(AudioClip clip, float fadeTime = 1f)
        {
            if (musicSource == null || clip == null) return;
            
            // TODO: Implement crossfade
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }
        
        /// <summary>
        /// Play lobby music.
        /// </summary>
        public void PlayLobbyMusic()
        {
            if (lobbyMusic != null)
            {
                PlayMusic(lobbyMusic);
            }
        }
        
        /// <summary>
        /// Play one-shot sound effect.
        /// </summary>
        public void PlaySFX(AudioClip clip, float volumeScale = 1f)
        {
            if (sfxSource != null && clip != null)
            {
                sfxSource.PlayOneShot(clip, volumeScale);
            }
        }
        
        /// <summary>
        /// Play sound effect at position (3D).
        /// </summary>
        public void PlaySFXAtPosition(AudioClip clip, Vector3 position, float volumeScale = 1f)
        {
            if (clip != null)
            {
                AudioSource.PlayClipAtPoint(clip, position, volumeScale);
            }
        }
        
        /// <summary>
        /// Stop all audio.
        /// </summary>
        public void StopAll()
        {
            musicSource?.Stop();
            ambientSource?.Stop();
            sfxSource?.Stop();
        }
        
        #endregion
    }
}
