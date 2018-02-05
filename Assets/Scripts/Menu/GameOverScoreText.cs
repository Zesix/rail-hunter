using TMPro;
using UnityEngine;

public class GameOverScoreText : MonoBehaviour 
{
    // Internal
    private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = "Score: " + GameController.Score;
    }
}
