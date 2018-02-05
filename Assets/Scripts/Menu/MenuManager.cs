using UnityEngine;
using System.Collections;
using Zenject;

public class MenuManager : MonoBehaviour
{
    // Internal
    private string _menuScreens;
    [SerializeField] private MenuScreen _activeScreen;
    [SerializeField] private MenuScreen _firstScreen;
    [SerializeField] private MenuScreen _gameOverScreen;
    
    // Dependencies
    private GameStateChangedSignal _gameStateChangedSignal;
    private StartGameSignal _startGameSignal;
    private ReturnToMenuSignal _returnToMenuSignal;

    [Inject]
    private void Construct(GameStateChangedSignal gameStateChangedSignal, StartGameSignal startGameSignal, 
        ReturnToMenuSignal returnToMenuSignal)
    {
        _gameStateChangedSignal = gameStateChangedSignal;
        _startGameSignal = startGameSignal;
        _returnToMenuSignal = returnToMenuSignal;
    }
    
    private void Awake()
    {
        _firstScreen.gameObject.SetActive(true);
        _activeScreen = _firstScreen;
        _gameStateChangedSignal += OnGameStateChanged;
    }
    
    private void OnDestroy()
    {
        _gameStateChangedSignal -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameStateBase gameState)
    {
        if (gameState is MenuState)
        {
            ChangeMenu(_firstScreen);
        }
        if (gameState is PlayState)
        {
            _activeScreen.gameObject.SetActive(false);
        }
        if (gameState is GameOverState)
        {
            ChangeMenu(_gameOverScreen);
        }
    }

    public void StartGame()
    {
        _startGameSignal.Fire();
    }

    public void ReturnToMenu()
    {
        _returnToMenuSignal.Fire();
    }

    public void ChangeMenuAndFade(MenuScreen screen)
    {
        StartCoroutine(ChangeScreen(screen, true));
    }

    public void ChangeMenu(MenuScreen screen)
    {
        StartCoroutine(ChangeScreen(screen, false));
    }

    private IEnumerator ChangeScreen(MenuScreen target, bool animate)
    {
        _activeScreen.gameObject.SetActive(false);
        yield return null;
        _activeScreen = target;
        _activeScreen.gameObject.SetActive(true);
    }

    public void QuitRequest()
    {
        Application.Quit();
    }
}

