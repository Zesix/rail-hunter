using Zenject;

public class EnemyShipInstaller : MonoInstaller
 {
     public override void InstallBindings()
     {
         Container.Bind<EnemyShipModel>().AsSingle();
     }
 }
