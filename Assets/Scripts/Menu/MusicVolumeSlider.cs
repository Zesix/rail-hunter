using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeSlider : MonoBehaviour
{
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            _slider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
    }
}
