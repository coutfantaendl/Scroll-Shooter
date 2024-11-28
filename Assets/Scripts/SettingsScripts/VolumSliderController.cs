using UnityEngine;
using UnityEngine.UI;

public class VolumSliderController : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(MusicSound);
        _slider.value = _audioSource.volume;
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(MusicSound);
    }

    private void MusicSound(float volum)
    {
        _audioSource.volume = volum;
    }
}
