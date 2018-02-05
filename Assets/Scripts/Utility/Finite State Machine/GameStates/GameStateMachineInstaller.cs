using Impulse.FiniteStateMachine;
using System.Collections.Generic;
using Zenject;

public class GameStateMachineInstaller : MonoInstaller
{
	private List<State<GameStateMachine, GameStateId, GameStateTransition>> _states;
	
	public override void InstallBindings()
	{
		var menuState = new MenuState();
		var playState = new PlayState();
		var gameOverState = new GameOverState();

		Container.BindInstance(menuState);
		Container.BindInstance(playState);
		Container.BindInstance(gameOverState);
		Container.QueueForInject(menuState);
		Container.QueueForInject(playState);
		Container.QueueForInject(gameOverState);
		
		_states = new List<State<GameStateMachine, GameStateId, GameStateTransition>>
		{
			menuState,
			playState,
			gameOverState
		};
		Container.BindInstance(_states);
	}
}
