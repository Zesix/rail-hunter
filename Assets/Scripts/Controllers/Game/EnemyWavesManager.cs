using UnityEngine;
using Zenject;

public class EnemyWavesManager : MonoBehaviour 
{
    // Internal
    private string _menuScreens;
    [SerializeField] private GameObject[] _enemyWaves;
    
    // Dependencies
    private GameStateChangedSignal _gameStateChangedSignal;

    [Inject]
    private void Construct(GameStateChangedSignal gameStateChangedSignal)
    {
        _gameStateChangedSignal = gameStateChangedSignal;
    }
    
    private void Awake()
    {
        _gameStateChangedSignal += OnGameStateChanged;
        DisableWaves();
    }
    
    private void OnDestroy()
    {
        _gameStateChangedSignal -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameStateBase gameState)
    {
        if (gameState is PlayState)
        {
            EnableWaves();
        }
        else
        {
            DisableWaves();
        }
    }

    private void DisableWaves()
    {
        foreach (GameObject enemyWave in _enemyWaves)
        {
            enemyWave.SetActive(false);
        }
    }

    private void EnableWaves()
    {
        foreach (GameObject enemyWave in _enemyWaves)
        {
            enemyWave.SetActive(true);
        }
    }
}
