using System;
using UnityEngine;

[CreateAssetMenu(fileName = "VolumeSettingsConfig", menuName = "Config/Volume Settings")]
public class VolumeSettingsConfig : ScriptableObject
{
    [Range(0f, 1f)] public float soundVolume;
    [Range(0f, 1f)] public float musicVolume;

    public Action<float> musicVolumeChanged;
    public Action<float> soundVolumeChanged;
}