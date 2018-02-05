using Zenject;

public class GameOverState : GameStateBase
{
	// Dependencies
	private GameStateChangedSignal _gameStateChangedSignal;
	private ReturnToMenuSignal _returnToMenuSignal;
	
	public GameOverState()
	{
		stateId = GameStateId.GameOver;
	}
	
	[Inject]
	public void Construct(GameStateChangedSignal gameStateChangedSignal, ReturnToMenuSignal returnToMenuSignal)
	{
		_gameStateChangedSignal = gameStateChangedSignal;
		_returnToMenuSignal = returnToMenuSignal;
	}
	
	public override void BuildTransitions ()
	{
		AddTransition(GameStateTransition.NullTransition, GameStateId.Menu);
	}

	public override void Enter ()
	{
		_gameStateChangedSignal.Fire(this);
		_returnToMenuSignal += OnReturnToMenu;
	}

	public override void Exit()
	{
		_returnToMenuSignal -= OnReturnToMenu;
	}

	private void OnReturnToMenu()
	{
		MakeTransition(GameStateTransition.NullTransition);
	}
}
