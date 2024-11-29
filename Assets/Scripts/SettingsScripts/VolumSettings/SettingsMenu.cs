using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("Volume Setting")]
    [SerializeField] private VolumeSettingsConfig _volumeSettingsConfig;
    [Space]
    [Header("UI Elements")]
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Slider _musicSlider;

    private void Start()
    {
        _soundSlider.value = _volumeSettingsConfig.soundVolume;
        _musicSlider.value = _volumeSettingsConfig.musicVolume;

        _soundSlider.onValueChanged.AddListener(OnSoundVolumeChanged);
        _musicSlider.onValueChanged.AddListener(OnMusikVolumeChanged);
    }

    private void OnSoundVolumeChanged(float value)
    {
        _volumeSettingsConfig.soundVolume = value;
        _volumeSettingsConfig.soundVolumeChanged?.Invoke(value);
    }

    private void OnMusikVolumeChanged(float value)
    {
        _volumeSettingsConfig.musicVolume = value;
        _volumeSettingsConfig.musicVolumeChanged?.Invoke(value);
    }
}

