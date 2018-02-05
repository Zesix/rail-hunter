using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private PlayableShip _playerShip;
    
    public override void InstallBindings()
    {
        BindManagers();
        BindPools();
        BindPlayer();
        BindEnemy();
    }

    private void BindManagers()
    {
        var menuManager = FindObjectOfType<MenuManager>();
        var musicManager = FindObjectOfType<MusicManager>();
        
        Container.BindInterfacesAndSelfTo<GameController>().AsSingle();
        Container.BindInstance(FindObjectOfType<GameStateMachine>());
        Container.BindInstance(musicManager);
        Container.QueueForInject(musicManager);
        Container.BindInstance(menuManager);
        Container.QueueForInject(menuManager);
        Container.BindInterfacesAndSelfTo<InputListener>().AsSingle();
    }

    private void BindPools()
    {
        Container.BindMemoryPool<ShipExplosion, ShipExplosion.Pool>()
            .WithInitialSize(10).ExpandByOneAtATime()
            .FromComponentInNewPrefabResource("HeavyDebrisExplosion")
            .UnderTransformGroup("ExplosionPool").NonLazy();
        
        Container.BindMemoryPool<MissileExplosion, MissileExplosion.Pool>()
            .WithInitialSize(20).ExpandByOneAtATime()
            .FromComponentInNewPrefabResource("MissileExplosion")
            .UnderTransformGroup("MissileExplosionPool").NonLazy();
        
        Container.BindMemoryPool<MissileWeapon, MissileWeapon.Pool>()
            .WithInitialSize(20).ExpandByOneAtATime()
            .FromComponentInNewPrefabResource("RednoseMissile")
            .UnderTransformGroup("MissilePool").NonLazy();
    }

    private void BindPlayer()
    {
        Container.Bind<PlayerData>().FromScriptableObjectResource("PlayerData/DefaultPlayerData").AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle();
        Container.BindInstance(_playerShip);
    }

    private void BindEnemy()
    {
        Container.Bind<EnemyShipData>().FromScriptableObjectResource("ShipData/EnemyLongbowData").AsSingle();
        Container.BindFactory<EnemyShipModel, EnemyShipModel.Factory>();
    }
}
