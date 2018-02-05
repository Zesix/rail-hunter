using Zenject;
using NUnit.Framework;

[TestFixture]
public class TestLogger : ZenjectUnitTestFixture
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
    public void PlayerHealthCannotDropBelowZero()
    {
        _playerModel.TakeDamage(200);

        Assert.That(_playerModel.Health == 0, Is.True);
    }
}
