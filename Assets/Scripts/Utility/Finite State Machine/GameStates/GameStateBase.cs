using Impulse.FiniteStateMachine;

public enum GameStateId
{
	Menu,
	Play,
	GameOver
}

public enum GameStateTransition
{
	NullTransition
}

public abstract class GameStateBase : State<GameStateMachine, GameStateId, GameStateTransition>
{
	public override void BuildTransitions () {}
	public override void Enter () {}
	public override void Exit () {}
	public override void FixedUpdate () {}
	public override void Update () {}
}
