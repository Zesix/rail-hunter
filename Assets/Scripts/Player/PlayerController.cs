using System;
using Zenject;

public class PlayerController : IInitializable, ITickable, IDisposable
{
    // Dependencies
    private PlayerModel _playerModel;
    private PlayableShip _shipView;
    private InputReceivedSignal _inputReceivedSignal;
    private PlayerHitSignal _playerHitSignal;
    private PlayerDeathSignal _playerDeathSignal;
    
    // Internal

    [Inject]
    public void Construct(
        PlayerModel playerModel, 
        PlayableShip shipView, 
        InputReceivedSignal inputReceivedSignal,
        PlayerHitSignal playerHitSignal,
        PlayerDeathSignal playerDeathSignal)
    {
        _playerModel = playerModel;
        _shipView = shipView;
        _inputReceivedSignal = inputReceivedSignal;
        _playerHitSignal = playerHitSignal;
        _playerDeathSignal = playerDeathSignal;
    }

    public void Initialize()
    {
        _inputReceivedSignal += OnReceiveInput;
        _playerHitSignal += _playerModel.TakeDamage;
    }

    public void Tick()
    {
        if (_playerModel.Health <= 0)
        {
            _shipView.StartCoroutine(nameof(_shipView.DespawnShip));
            _playerDeathSignal.Fire();
            _playerModel.ResetPlayerData();
        }
    }

    public void Dispose()
    {
        _inputReceivedSignal -= OnReceiveInput;
        _playerHitSignal -= _playerModel.TakeDamage;
    }

    private void OnReceiveInput(InputDataWrapper inputDataWrapper)
    {
        var inputData = inputDataWrapper;
        if (inputData.RollButtonPressed)
        {
            _shipView.AileronRoll(inputData.XThrow);
        }
        else
        {
            _shipView.TranslateShip(inputData.XThrow, inputData.YThrow);
        }

        _shipView.RotateShip(inputData.XThrow, inputData.YThrow);
        _shipView.LookAtPositionFromRay(inputData.MousePositionRay);
    }
}