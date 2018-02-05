using TMPro;
using UnityEngine;
using Zenject;

public class ScoreText : MonoBehaviour
{
    // Dependencies
    private GameStateChangedSignal _gameStateChangedSignal;
    private ScoreSignal _scoreSignal;
    
    // Internal
    private TextMeshProUGUI _text;

    [Inject]
    public void Construct(GameStateChangedSignal gameStateChangedSignal, ScoreSignal scoreSignal)
    {
        _gameStateChangedSignal = gameStateChangedSignal;
        _scoreSignal = scoreSignal;
    }
    
    private void Start()
    {
        _gameStateChangedSignal += OnGameStateChanged;
        _scoreSignal += ScoreUpdate;
        _text = GetComponent<TextMeshProUGUI>();
        
        _text.enabled = false;
    }

    private void OnGameStateChanged(GameStateBase gameState)
    {
        if (gameState is MenuState)
        {
            _text.enabled = false;
        }
        if (gameState is PlayState)
        {
            _text.enabled = true;
            _text.text = GameController.Score.ToString();
        }
        if (gameState is GameOverState)
        {
            _text.enabled = false;
        }
    }

    private void OnDestroy()
    {
        _gameStateChangedSignal -= OnGameStateChanged;
        _scoreSignal -= ScoreUpdate;
    }

    private void ScoreUpdate(int amount, EnemyShipPresenter enemyShipPresenter)
    {
        _text.text = GameController.Score.ToString();
    }
}
