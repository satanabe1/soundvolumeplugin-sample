using UnityEngine;
using UnityEngine.UI;

public class SampleVolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    void Start() => volumeSlider.onValueChanged.AddListener(SoundVolumePlugin.SetVolume);
    void Update() => volumeSlider.SetValueWithoutNotify(SoundVolumePlugin.GetVolume());
}