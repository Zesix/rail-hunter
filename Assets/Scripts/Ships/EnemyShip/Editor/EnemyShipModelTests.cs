using Zenject;
using NUnit.Framework;

[TestFixture]
public class EnemyShipModelTests : ZenjectUnitTestFixture
{
	[SetUp]
	public void CommonInstall()
	{
		Container.Bind<EnemyShipData>().FromScriptableObjectResource("ShipData/EnemyLongbowData").AsSingle();
		Container.Bind<EnemyShipModel>().AsSingle();
		Container.Inject(this);
	}

	[Inject] private EnemyShipModel _enemyModel;
	[Inject] private EnemyShipData _enemyData;
    
	[Test]
	public void EnemyShipTakesHits()
	{
		var previousHits = _enemyModel.CurrentHits;
		_enemyModel.IncrementHits(1);

		Assert.That(_enemyModel.CurrentHits == previousHits + 1, Is.True);
	}
    
	[Test]
	public void EnemyShipCurrentHitsIsReset()
	{
		_enemyModel.ClearHits();

		Assert.That(_enemyModel.CurrentHits == 0, Is.True);
	}
}
