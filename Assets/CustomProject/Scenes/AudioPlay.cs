using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using CustomProject;

public class AudioPlay : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Button playButton;
    private AudioManager _audioManager;

    private bool isPlaying = false;

    private AudioSource _backgroundMusicPlayer;

    void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        playButton.onClick.AddListener(TogglePlay);
        slider.onValueChanged.AddListener(ChangeMusicTime);

        FieldInfo fieldInfo = _audioManager.GetType().GetField("_backgroundMusicPlayer", BindingFlags.NonPublic | BindingFlags.Instance);
        _backgroundMusicPlayer = (AudioSource)fieldInfo.GetValue(_audioManager);
    }

    void Update()
    {
        if (isPlaying && _backgroundMusicPlayer.isPlaying)
        {
            slider.value = _backgroundMusicPlayer.time / _backgroundMusicPlayer.clip.length;
        }
    }

    void TogglePlay()
    {
        if (isPlaying)
        {
            _audioManager.PauseBackground();
        }
        else
        {
            _audioManager.PlayBackground();
        }

        isPlaying = !isPlaying;
    }

    void ChangeMusicTime(float newValue)
    {
        _backgroundMusicPlayer.time = newValue * _backgroundMusicPlayer.clip.length;
    }
}
