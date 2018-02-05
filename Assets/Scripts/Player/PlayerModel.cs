using UnityEngine;
using Zenject;

public class PlayerModel : IInitializable
{
    private PlayerData _playerData;
    
    public int Health { get; private set; }

    [Inject]
    public PlayerModel(PlayerData playerData)
    {
        _playerData = playerData;
    }
    
    public void Initialize()
    {
        ResetPlayerData();
    }

    public void TakeDamage(int amount)
    {
        var newHealth = Mathf.RoundToInt(Mathf.Clamp(Health - amount, 0f, Mathf.Infinity));   
        Health = newHealth;
    }

    public void ResetPlayerData()
    {
        Health = _playerData.Health;
    }
}
