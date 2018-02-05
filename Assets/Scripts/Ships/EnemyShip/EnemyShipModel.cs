using UnityEngine;
using Zenject;

public class EnemyShipModel
{
	private readonly EnemyShipData _shipData;

	public int MaxHits { get; private set; }
	public int ScoreAmount { get; private set; }
	
	public int CurrentHits { get; private set; }
	public float WeaponFireRate { get; private set; }

	[Inject]
	public EnemyShipModel(EnemyShipData shipData)
	{
		_shipData = shipData;
		SetModelData();
		ClearHits();
	}

	private void SetModelData()
	{
		MaxHits = _shipData.MaxHits;
		ScoreAmount = MaxHits * _shipData.ScoreMultiplier;
		WeaponFireRate = _shipData.WeaponFireRate;
	}

	public void IncrementHits(int amount)
	{
		CurrentHits += amount;
	}
	
	public void ClearHits()
	{
		CurrentHits = 0;
	}
	
	public class Factory : Factory<EnemyShipModel> {}
}
