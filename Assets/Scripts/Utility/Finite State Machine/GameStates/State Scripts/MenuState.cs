using Zenject;

public class MenuState : GameStateBase 
{
	// Dependencies
	private GameStateChangedSignal _gameStateChangedSignal;
	private StartGameSignal _startGameSignal;
	
	public MenuState()
	{
		stateId = GameStateId.Menu;
	}
	
	[Inject]
	public void Construct(GameStateChangedSignal gameStateChangedSignal, StartGameSignal startGameSignal)
	{
		_gameStateChangedSignal = gameStateChangedSignal;
		_startGameSignal = startGameSignal;
	}
	
	public override void BuildTransitions ()
	{
		AddTransition(GameStateTransition.NullTransition, GameStateId.Play);
	}

	public override void Enter ()
	{
		_gameStateChangedSignal.Fire(this);
		_startGameSignal += OnStartGame;
	}

	public override void Exit()
	{
		_startGameSignal -= OnStartGame;
	}

	private void OnStartGame()
	{
		MakeTransition(GameStateTransition.NullTransition);
	}
}
