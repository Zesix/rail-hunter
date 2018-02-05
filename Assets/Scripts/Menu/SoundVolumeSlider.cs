using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeSlider : MonoBehaviour 
{
    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        if (PlayerPrefs.HasKey("SoundVolume"))
        {
            _slider.value = PlayerPrefs.GetFloat("SoundVolume");
        }
    }

    public void SetSoundVolume(float amount)
    {
        PlayerPrefs.SetFloat("SoundVolume", amount);
        PlayerPrefs.Save();
    }
}
