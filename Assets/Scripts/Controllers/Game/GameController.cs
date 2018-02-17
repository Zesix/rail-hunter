using DG.Tweening;
using System;
using UnityEngine;
using Zenject;

public class GameController : IInitializable, IDisposable
{
    // Dependencies
    private GameStateChangedSignal _gameStateChangedSignal;
    private ScoreSignal _scoreSignal;
    
    // Internal
    public static int Score;

    [Inject]
    public void Construct(GameStateChangedSignal gameStateChangedSignal, ScoreSignal scoreSignal)
    {
        _gameStateChangedSignal = gameStateChangedSignal;
        _scoreSignal = scoreSignal;
    }
    
    public void Initialize()
    {
        DOTween.Init();
        _gameStateChangedSignal += OnGameStateChanged;
        _scoreSignal += OnScoreChanged;
    }

    private void OnGameStateChanged(GameStateBase gameState)
    {
        if (gameState is PlayState)
        {
            Score = 0;
        }

        if (gameState is GameOverState)
        {
            var topScore = 0;
            if (PlayerPrefs.HasKey("TopScore"))
            {
                topScore = PlayerPrefs.GetInt("TopScore");
            }
            if (Score > topScore)
            {
                topScore = Score;
                PlayerPrefs.SetInt("TopScore", topScore);
                PlayerPrefs.Save();
            }
        }
    }

    private void OnScoreChanged(int amount, EnemyShipPresenter enemyShipPresenter)
    {
        Score += amount;
    }

    public void Dispose()
    {
        _gameStateChangedSignal -= OnGameStateChanged;
        _scoreSignal -= OnScoreChanged;
    }

}
