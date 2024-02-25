using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
namespace CustomProject
{
    [CreateAssetMenu(fileName = "NewAudioManagerDataConfig", menuName = "InnerMobile/AudioManagerDataConfig")]
    public class AudioManagerDataConfig : ScriptableObject
    {
        [SerializeField] private AudioClip _backgroundMusic;
        [SerializeField] [Range(0f, 1f)] private float _backgroundMusicVolume;
        [SerializeField] [Range(0f, 1f)] private float _backgroundMuteVolume;

        [SerializeField] [Range(0f, 1f)] private float _voiceVolume;
        [SerializeField] [Range(0f, 1f)] private float _sfxVolume;
        
        [SerializeField] private AudioClip _swipeSound;
        [SerializeField] private AudioClip _clickSound;
        

        public AudioClip BackgroundMusic => _backgroundMusic;
        public float BackgroundMusicVolume => _backgroundMusicVolume;
        public float BackgroundMuteVolume => _backgroundMuteVolume;
        public float VoiceVolume => _voiceVolume;
        public float SfxVolume => _sfxVolume;

        public AudioClip SwipeSound => _swipeSound;
        public AudioClip ClickSound => _clickSound;
    }
}

