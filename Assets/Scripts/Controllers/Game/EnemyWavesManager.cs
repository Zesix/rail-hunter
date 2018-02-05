using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyWavesManager : MonoBehaviour 
{
    // Configurable
    [SerializeField] private GameObject[] _enemyWaves;
    
    // Internal
    private string _menuScreens;
    private List<EnemyShipPresenter> _enemyShips;
    
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
        _enemyShips = new List<EnemyShipPresenter>();
        foreach (var enemyWave in _enemyWaves)
        {
            foreach (var enemyShip in enemyWave.GetComponentsInChildren<EnemyShipPresenter>())
            {
                _enemyShips.Add(enemyShip);
            }
        }
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
        foreach (var enemyWave in _enemyWaves)
        {
            enemyWave.SetActive(false);
        }
    }

    private void EnableWaves()
    {
        foreach (var enemyWave in _enemyWaves)
        {
            enemyWave.SetActive(true);
        }

        foreach (var enemyShip in _enemyShips)
        {
            enemyShip.gameObject.SetActive(true);
            enemyShip.ResetShip();
        }
    }
}
