using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeController : MonoBehaviour
{
    private const float Multiplier = 20f;

    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Toggle _toggle;
    [SerializeField] private string _volumeParameter = "Master";

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume(float sliderValue)
    {
        if (_toggle.isOn == false)
            _mixer.audioMixer.SetFloat(_volumeParameter, Mathf.Log10(sliderValue) * Multiplier);
    }
}
