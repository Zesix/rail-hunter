using TMPro;
using UnityEngine;

public class HighestScoreText : MonoBehaviour 
{
    // Internal
    private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = "Personal Record: " + PlayerPrefs.GetInt("TopScore");
    }
}
