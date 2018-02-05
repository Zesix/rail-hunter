using UnityEngine;
using UnityEngine.Playables;
using Zenject;

public class PlayerRigController : MonoBehaviour
{    
    // Dependencies
    private GameStateChangedSignal _gameStateChangedSignal;
    
    // Internal
    private PlayableDirector _playableDirector;
    
    [Inject]
    public void Construct(GameStateChangedSignal gameStateChangedSignal)
    {
        _gameStateChangedSignal = gameStateChangedSignal;
    }
    
    private void Start()
    {
        _playableDirector = GetComponent<PlayableDirector>();
        _gameStateChangedSignal += OnGameStateChanged;
    }

    private void OnGameStateChanged(GameStateBase gameState)
    {
        if (gameState is PlayState)
        {
            _playableDirector.Stop();
            _playableDirector.Play();
        }
    }

    private void OnDestroy()
    {
        _gameStateChangedSignal -= OnGameStateChanged;
    }
}
