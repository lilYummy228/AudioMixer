using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class Switch : MonoBehaviour
{
    private const string MasterVolume = "Master";
    private const float Multiplier = 20f;

    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _slider;

    private float _minVolume = -80f;
    private float _volumeValue;
    private Toggle _toggle;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(Mute);        
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(Mute);
    }

    private void Mute(bool isMuted)
    {
        _volumeValue = Mathf.Log10(_slider.value) * Multiplier;

        if (isMuted)
            _mixer.audioMixer.SetFloat(MasterVolume, _minVolume);
        else
            _mixer.audioMixer.SetFloat(MasterVolume, _volumeValue);
    }
}
