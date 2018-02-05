using Zenject;

public class PlayState : GameStateBase
{
	// Dependencies
	private GameStateChangedSignal _gameStateChangedSignal;
	private PlayerDeathSignal _playerDeathSignal;
	
	public PlayState()
	{
		stateId = GameStateId.Play;
	}
    
	[Inject]
	public void Construct(GameStateChangedSignal gameStateChangedSignal, PlayerDeathSignal playerDeathSignal)
	{
		_gameStateChangedSignal = gameStateChangedSignal;
		_playerDeathSignal = playerDeathSignal;
	}
	
	public override void BuildTransitions ()
	{
		AddTransition(GameStateTransition.NullTransition, GameStateId.GameOver);
	}

	public override void Enter ()
	{
		_gameStateChangedSignal.Fire(this);
		_playerDeathSignal += GameOverHelper;
	}

	public override void Exit()
	{
		_playerDeathSignal -= GameOverHelper;
	}

	private void GameOverHelper()
	{
		MakeTransition(GameStateTransition.NullTransition);
	}
}
