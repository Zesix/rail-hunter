using System.Collections.Generic;
using Impulse.FiniteStateMachine;
using UnityEngine;
using Zenject;

public class GameStateMachine : MonoBehaviour 
{
	// Configurable
	[SerializeField] private GameStateId _initialGameState;
	public GameStateId InitialGameState => _initialGameState;
	[SerializeField] private bool _debug;
	
	// Internal
	private StateMachine<GameStateMachine, GameStateId, GameStateTransition> GameFsm { get; set; }
	private List<State<GameStateMachine, GameStateId, GameStateTransition>> _states;

	[Inject]
	private void Construct(List<State<GameStateMachine, GameStateId, GameStateTransition>> states)
	{
		_states = states;
	}

	private void Awake()
	{
		GameFsm = new StateMachine<GameStateMachine, GameStateId, GameStateTransition>(
			this, _states, _initialGameState, _debug);
	}

	private void Update()
	{
		GameFsm.Update();
	}

	private void FixedUpdate()
	{
		GameFsm.FixedUpdate();
	}
	
	private void OnDestroy()
	{
		GameFsm.Destroy();
	}

#if UNITY_EDITOR
	private void OnGUI()
	{
		if (_debug)
		{
			GUI.color = Color.white;
			GUI.Label(new Rect(0.0f, 0.0f, 500.0f, 500.0f), 
				string.Format("Current State: {0}", GameFsm.CurrentStateName));
		}
	}
#endif
}
