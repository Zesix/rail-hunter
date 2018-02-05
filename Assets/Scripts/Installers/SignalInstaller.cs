using Zenject;

public class SignalInstaller : MonoInstaller 
{
    public override void InstallBindings()
    {
        Container.DeclareSignal<GameStateChangedSignal>();
        Container.DeclareSignal<StartGameSignal>();
        Container.DeclareSignal<ReturnToMenuSignal>();
        Container.DeclareSignal<InputReceivedSignal>();
        Container.DeclareSignal<ScoreSignal>();
        Container.DeclareSignal<PlayerDeathSignal>();
        Container.DeclareSignal<PlayerHitSignal>();
    }
}
