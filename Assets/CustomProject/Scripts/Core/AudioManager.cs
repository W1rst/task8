using System;
using System.Collections;
using CustomProject.Utils;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace CustomProject
{
    public class AudioManager : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField]
        private AudioManagerDataConfig _audioConfig;

        #endregion

        #region Private Variables

        private AudioSource _backgroundMusicPlayer;
        private AudioSource _commonPlayer;
        private AudioSource _effectPlayer;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            Initialize();
        }

        #endregion

        #region Public Methods

        public void Initialize()
        {
            _commonPlayer = CreatePlayer("CommonPlayer");
            _backgroundMusicPlayer = CreatePlayer("BackGroundMusicPlayer");
            _effectPlayer = CreatePlayer("EffectPlayer");
            SetBackgroundTheme(_audioConfig.BackgroundMusic);
            _backgroundMusicPlayer.Stop();
            _effectPlayer.volume = _audioConfig.SfxVolume;
            _effectPlayer.playOnAwake = false;

            _commonPlayer.volume = _audioConfig.VoiceVolume;
            _backgroundMusicPlayer.volume = _audioConfig.BackgroundMusicVolume;
        }
        
        public void PlayEffect(AudioClip effect, float volume = 0)
        {
            _effectPlayer.Stop();

            if(volume != 0)
            {
                _effectPlayer.volume = volume;
            }
            else
            {
                _effectPlayer.volume = _audioConfig.SfxVolume;
            }

            _effectPlayer.clip = effect;
            _effectPlayer.Play();
        }

        public float PlayCommon(AudioClip clip)
        {
            _commonPlayer.clip = clip;
            float duration = clip.length;
            _commonPlayer.Play();
            return duration;
        }

        public void PlayBackground()
        {
            _backgroundMusicPlayer.Play();
        }

        public void PauseBackground()
        {
            _backgroundMusicPlayer.Pause();
        }

        public void StopBackground()
        {
            _backgroundMusicPlayer.Stop();
        }

        public bool IsBackgroundMusicPlaying()
        {
            return _backgroundMusicPlayer.isPlaying;
        }
        public void StopCommon()
        {
            _commonPlayer.Stop();
            _commonPlayer.clip = null;
        }

        public void PlaySwipe()
        {
            PlayClip(_audioConfig.SwipeSound, _audioConfig.SfxVolume);
        }

        public void PlayClick()
        {
            PlayClip(_audioConfig.ClickSound, _audioConfig.SfxVolume);
        }

        public void SetBackgroundTheme(AudioClip clip, bool loop = true)
        {
            _backgroundMusicPlayer.Stop();
            if (_backgroundMusicPlayer.clip != clip)
            {
                _backgroundMusicPlayer.clip = clip;
            }
            _backgroundMusicPlayer.loop = loop;

            if(_backgroundMusicPlayer.isPlaying)
            {
                _backgroundMusicPlayer.Play();
            }
        }
        #endregion
        
        #region Pritave Methods

        public void PlayClip(AudioClip clip, float volume)
        {
            if (clip != null)
            {
                Vector3 cameraPos = Camera.main.transform.position;
                AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
            }
        }
        private AudioSource CreatePlayer(string playerName)
        {
            GameObject go = new GameObject(playerName)
            {
                transform =
                {
                    parent = transform
                }
            };
            return go.AddComponent<AudioSource>();
        }
        
        #endregion
    }
}