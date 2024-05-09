using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    private const float Multiplier = 20f;

    [SerializeField] private AudioMixerGroup _mixer;

    public void ToggleAudio(string masterVolume)
    {
        Toggle toggle = GetComponent<Toggle>();

        if (toggle.isOn)
            _mixer.audioMixer.SetFloat(masterVolume, -80);
        else
            _mixer.audioMixer.SetFloat(masterVolume, 0);
    }

    public void ChangeVolume(string volumeParameter)
    {
        Slider slider = GetComponent<Slider>();

        _mixer.audioMixer.SetFloat(volumeParameter, Mathf.Log10(slider.value) * Multiplier);
    }
}
