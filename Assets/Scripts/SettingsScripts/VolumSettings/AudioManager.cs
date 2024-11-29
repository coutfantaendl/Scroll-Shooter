using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Volume Settings")]
    [SerializeField] private VolumeSettingsConfig _volumeSettingsConfig;
    [Space]
    [Header("Audio Sources")]
    [SerializeField] private List<AudioSource> _soundSources;
    [SerializeField] private List<AudioSource> _musicSources;

    private void Start()
    {
        UpdateVolumes();

        _volumeSettingsConfig.soundVolumeChanged += _ => _soundSources.ForEach(s => s.volume = _);
        _volumeSettingsConfig.musicVolumeChanged += _ => _musicSources.ForEach(s => s.volume = _);
    }

    private void UpdateVolumes()
    {
        foreach (var soundSource in _soundSources)
        {
            soundSource.volume = _volumeSettingsConfig.soundVolume;
        }

        foreach (var musicSource in _musicSources)
        {
            musicSource.volume = _volumeSettingsConfig.musicVolume;
        }
    }
}
