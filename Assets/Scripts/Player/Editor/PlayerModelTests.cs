using Zenject;
using NUnit.Framework;

[TestFixture]
public class PlayerModelTests : ZenjectUnitTestFixture
{
    [SetUp]
    public void CommonInstall()
    {
        Container.Bind<PlayerData>().FromScriptableObjectResource("PlayerData/DefaultPlayerData").AsSingle();
        Container.Bind<PlayerModel>().AsSingle();
        Container.Inject(this);
    }

    [Inject] private PlayerModel _playerModel;
    [Inject] private PlayerData _playerData;
    
    [Test]
    public void PlayerHealthDecreases()
    {
        _playerModel.TakeDamage(_playerModel.Health / 2);

        Assert.That(_playerModel.Health == _playerModel.Health / 2, Is.True);
    }

    [Test]
    public void PlayerHealthCannotDropBelowZero()
    {
        Assume.That(_playerModel.Health < 1000, Is.True);
        _playerModel.TakeDamage(1000);

        Assert.That(_playerModel.Health == 0, Is.True);
    }
    
    [Test]
    public void PlayerHealthIsReset()
    {
        _playerModel.ResetPlayerData();

        Assert.That(_playerModel.Health == _playerData.Health, Is.True);
    }
}
